using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Jumper1.Models.Levels;
using Jumper1.Models.CollisionDetection;

namespace Jumper1.Models
{
   public enum EJumpState
   {
      Initial,
      JumpInitiate,
      JumpProgress,
      JumpComplete
   }

   public enum EHorizontalMoveState
   {
      Stop,
      TurnLeft,
      TurnRight
   }

   public class Character : ICollider
   {
      private static AbstractLevel Level { get; set; }
      public float CurrentPositionX { get; private set; }
      public float CurrentPositionY { get; private set; }
      public float PreviousPositionX { get; private set; }
      public float PreviousPositionY { get; private set; }
      public uint CurrentScore { get; private set; } = 0;
      public string Name { get; set; } = "Player1";
      readonly static double START_VELOCITY_X = 0.5;
      readonly static double MAX_VELOCITY_X = 3.0;
      public double CurrentVelocityX { get; private set; } = START_VELOCITY_X;
      readonly static double START_VELOCITY_Y = 0.0;
      public double CurrentVelocityY { get; private set; } = START_VELOCITY_Y;
      public EJumpState JumpState { get; set; } = EJumpState.Initial;
      public EHorizontalMoveState HorizontalMoveState { get; set; } = EHorizontalMoveState.Stop;
      public double MoveLeftActionDuration { get; set; } = 0.0;
      public double MoveRightActionDuration { get; set; } = 0.0;
      public float Width { get; private set; } = 16f;
      public float Height { get; private set; } = 31f;
      private CollusionManager collusionManager;

      public Character(AbstractLevel level, CollusionManager collusionManager)
      {
         Level = level;
         CurrentPositionX = Level.BoundaryLeft;
         CurrentPositionY = Level.BoundaryBottom - Height;
         PreviousPositionX = CurrentPositionX;
         PreviousPositionY = CurrentPositionY;
         this.collusionManager = collusionManager;
         AddCollider();
      }

      public void Update()
      {
         PreviousPositionY = CurrentPositionY;
         CurrentVelocityX = CalculateCurrentVelocityX();

         if ((HorizontalMoveState == EHorizontalMoveState.TurnLeft) &&
             ((CurrentPositionX - (float)CurrentVelocityX) < Level.BoundaryLeft))
         {
            HorizontalMoveState = EHorizontalMoveState.Stop;
         }
         else if ((HorizontalMoveState == EHorizontalMoveState.TurnRight) &&
                  (((CurrentPositionX + (float)CurrentVelocityX) + Width > Level.BoundaryRight)))
         {
            HorizontalMoveState = EHorizontalMoveState.Stop;
         }

         if (HorizontalMoveState == EHorizontalMoveState.TurnLeft)
         {
            PreviousPositionX = CurrentPositionX;
            CurrentPositionX = CurrentPositionX - (float)CurrentVelocityX;
         }

         if (HorizontalMoveState == EHorizontalMoveState.TurnRight)
         {
            PreviousPositionX = CurrentPositionX;
            /* Ensure we don't scroll off right side of screen */
            CurrentPositionX = CurrentPositionX + (float)CurrentVelocityX;
         }

         CurrentPositionY = CurrentPositionY + (float)CurrentVelocityY;

         if (JumpState == EJumpState.JumpInitiate)
         {
            CurrentPositionY -= 10.0f;
            CurrentVelocityY = -5.0;
            JumpState = EJumpState.JumpProgress;
         }

         if (JumpState == EJumpState.JumpProgress)
         {
            double i = 1;
            CurrentVelocityY += (double)Level.GravitationalAcceleration * i;

            /* If jump is in progress and left/right movement has stopped, save previous 
             * position as jump will have some affect on left/right movement */
            if (HorizontalMoveState == EHorizontalMoveState.Stop)
            {
               PreviousPositionX = CurrentPositionX;
            }
         }

         /* If pos y is passed ground, restore it to original */
         if (CurrentPositionY > Level.BoundaryBottom - Height)
         {
            JumpState = EJumpState.JumpComplete;
            CurrentPositionY = Level.BoundaryBottom - Height;
         }

         if ((JumpState == EJumpState.JumpComplete) || (JumpState == EJumpState.Initial))
         {
            CurrentVelocityY = START_VELOCITY_Y;
            JumpState = EJumpState.Initial;
         }

         UpdateCollider();

         if (collusionManager.HasCollided(0) == true)
         {
            CurrentPositionX = PreviousPositionX;
            CurrentPositionY = PreviousPositionY;
            UpdateCollider();
         }
      }

      public void UpdateCollider()
      {
         collusionManager.Update(
            0,
            CurrentPositionX,
            CurrentPositionY,
            CurrentPositionX + Width,
            CurrentPositionY,
            CurrentPositionX,
            CurrentPositionY + Height,
            CurrentPositionX + Width,
            CurrentPositionY + Height
            );
      }

      public void UpdateScore(uint elapsedTime)
      {
         CurrentScore = CurrentScore + elapsedTime;
      }

      private double CalculateCurrentVelocityX()
      {
         double actionDuration;
         double tempVelocity;

         if (HorizontalMoveState == EHorizontalMoveState.TurnLeft)
         {
            actionDuration = MoveLeftActionDuration;
         }
         else if (HorizontalMoveState == EHorizontalMoveState.TurnRight)
         {
            actionDuration = MoveRightActionDuration;
         }
         else
         {
            actionDuration = 0.0;
         }

         tempVelocity = START_VELOCITY_X + (actionDuration / 1000);
         if (tempVelocity > MAX_VELOCITY_X)
         {
            tempVelocity = MAX_VELOCITY_X;
         }
         return tempVelocity;
      }

      public void AddCollider()
      {
         collusionManager.AddCollider(new Collider(
            0,
            EColliderType.Character,
            CurrentPositionX,
            CurrentPositionY,
            CurrentPositionX + Width,
            CurrentPositionY,
            CurrentPositionX,
            CurrentPositionY + Height,
            CurrentPositionX + Width,
            CurrentPositionY + Height));
      }
   }
}
