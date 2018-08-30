using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

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

   public class Character
   {
      public static float CurrentPositionX { get; private set; } = 0f;
      public static float CurrentPositionY { get; private set; } = 447f - 31f;
      public static float PreviousPositionX { get; private set; } = CurrentPositionX;
      public static float PreviousPositionY { get; private set; } = CurrentPositionY;
      public static uint CurrentScore { get; private set; } = 0;
      public static string Name { get; set; } = "Player1";
      readonly static double START_VELOCITY_X = 0.5;
      readonly static double MAX_VELOCITY_X = 3.0;
      public static double CurrentVelocityX { get; private set; } = START_VELOCITY_X;
      readonly static double START_VELOCITY_Y = 0.0;
      public static double CurrentVelocityY { get; private set; } = START_VELOCITY_Y;
      public static EJumpState JumpState { get; set; } = EJumpState.Initial;
      public static EHorizontalMoveState HorizontalMoveState { get; set; } = EHorizontalMoveState.Stop;
      public static double MoveLeftActionDuration { get; set; } = 0.0;
      public static double MoveRightActionDuration { get; set; } = 0.0;

      public static void Update()
      {
         PreviousPositionY = CurrentPositionY;
         CurrentVelocityX = CalculateCurrentVelocityX();

         if ((HorizontalMoveState == EHorizontalMoveState.TurnLeft) &&
             ((CurrentPositionX - (float)CurrentVelocityX) < 0))
         {
            HorizontalMoveState = EHorizontalMoveState.Stop;
         }
         else if ((HorizontalMoveState == EHorizontalMoveState.TurnRight) &&
             (((CurrentPositionX + (float)CurrentVelocityX) + 16 > 800)))
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
            CurrentVelocityY += 0.20 * i;

            /* If jump is in progress and left/right movement has stopped, save previous 
             * position as jump will have some affect on left/right movement */
            if (HorizontalMoveState == EHorizontalMoveState.Stop)
            {
               PreviousPositionX = CurrentPositionX;
            }
         }

         /* If pos y is passed ground, restore it to original */
         if (CurrentPositionY > 447.0f - 31f)
         {
            JumpState = EJumpState.JumpComplete;
            CurrentPositionY = 447.0f - 31f;
         }

         if ((JumpState == EJumpState.JumpComplete) || (JumpState == EJumpState.Initial))
         {
            CurrentVelocityY = START_VELOCITY_Y;
            JumpState = EJumpState.Initial;
         }
      }

      public void UpdateScore(uint elapsedTime)
      {
         CurrentScore = CurrentScore + elapsedTime;
      }

      private static double CalculateCurrentVelocityX()
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
   }
}
