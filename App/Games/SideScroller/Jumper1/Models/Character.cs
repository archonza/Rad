using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Jumper1.Models
{
   public class Character
   {
      public static float CurrentPositionX { get; private set; } = 0; // This initialises the property to zero, states that it can publically be retrieved and privately set.
      public static float CurrentPositionY { get; private set; } = 447-31;
      public static float PreviousPositionX { get; private set; } = CurrentPositionX;
      public static float PreviousPositionY { get; private set; } = CurrentPositionY;
      public static uint CurrentScore { get; private set; } = 0; // Default score is 0, this can be publicly retrieved and privately set
      public static string Name { get; set; } = "Player1"; // Default name is Player1
      readonly static double START_VELOCITY_X = 0.5;
      readonly static double MAX_VELOCITY_X = 3.0;
      static double currentVelocityX = START_VELOCITY_X;
      readonly static double START_VELOCITY_Y = 0.0;
      public static double CurrentVelocityY { get; private set; } = START_VELOCITY_Y;

      public static void MoveLeft(double actionDuration)
      {
         PreviousPositionX = CurrentPositionX;
         PreviousPositionY = CurrentPositionY;
         currentVelocityX = CalculateCurrentVelocityX(actionDuration);
         CurrentPositionX = CurrentPositionX - (float)currentVelocityX;
      }

      public static void MoveRight(double actionDuration)
      {
         PreviousPositionX = CurrentPositionX;
         PreviousPositionY = CurrentPositionY;
         currentVelocityX = CalculateCurrentVelocityX(actionDuration);
         CurrentPositionX = CurrentPositionX + (float)currentVelocityX;
      }

      public static void Update()
      {
         CurrentPositionY = CurrentPositionY + (float)CurrentVelocityY;
      }

      public static void JumpInitiate()
      {
         PreviousPositionY = CurrentPositionY;
         CurrentPositionY -= 10.0f;
         CurrentVelocityY = -5.0;
      }

      public static void JumpProgress()
      {
         double i = 1;
         CurrentVelocityY += 0.15 * i;
      }

      public static void JumpComplete()
      {
         CurrentVelocityY = START_VELOCITY_Y;
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
