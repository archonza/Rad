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
   public class Character
   {
      public static float CurrentPositionX { get; private set; } = 0f; // This initialises the property to zero, states that it can publically be retrieved and privately set.
      public static float CurrentPositionY { get; private set; } = 447f-31f;
      public static float PreviousPositionX { get; private set; } = CurrentPositionX;
      public static float PreviousPositionY { get; private set; } = CurrentPositionY;
      public static uint CurrentScore { get; private set; } = 0; // Default score is 0, this can be publicly retrieved and privately set
      public static string Name { get; set; } = "Player1"; // Default name is Player1
      readonly static double START_VELOCITY_X = 0.5;
      readonly static double MAX_VELOCITY_X = 3.0;
      public static double CurrentVelocityX { get; private set; } = START_VELOCITY_X;
      readonly static double START_VELOCITY_Y = 0.0;
      public static double CurrentVelocityY { get; private set; } = START_VELOCITY_Y;
      public static EJumpState JumpState { get; set; } = EJumpState.Initial;

      public static void Update(double actionDuration, bool turnLeft, bool turnRight)
      {
         PreviousPositionX = CurrentPositionX;
         PreviousPositionY = CurrentPositionY;
         CurrentVelocityX = CalculateCurrentVelocityX(actionDuration);

         if (turnLeft == true)
         {
            CurrentPositionX = CurrentPositionX - (float)CurrentVelocityX;
         }

         if (turnRight == true)
         {
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
         }

         /* If pos y is passed ground, restore it to original */
         if (Character.CurrentPositionY >= 447.0f - 31f)
         {
            JumpState = EJumpState.JumpComplete;
            Character.CurrentPositionY = 447.0f - 31f;
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

      private static double CalculateCurrentVelocityX(double actionDuration)
      {
         double tempVelocity = START_VELOCITY_X + (actionDuration / 1000);
         if (tempVelocity > MAX_VELOCITY_X)
         {
            tempVelocity = MAX_VELOCITY_X;
         }
         return tempVelocity;
      }
   }
}
