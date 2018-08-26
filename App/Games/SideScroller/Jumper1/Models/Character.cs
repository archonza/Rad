using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumper1.Models
{
   public class Character
   {
      public static int CurrentPositionX { get; private set; } = 0; // This initialises the property to zero, states that it can publically be retrieved and privately set.
      public static int CurrentPositionY { get; private set; } = 0;
      public static uint CurrentScore { get; private set; } = 0; // Default score is 0, this can be publicly retrieved and privately set
      public static string Name { get; set; } = "Player1"; // Default name is Player1

      public static void SetPositionX(int newPositionX) => CurrentPositionX = newPositionX; // this just sets CurrentPosition property
      public static void SetPositionY(int newPositionY) => CurrentPositionY = newPositionY;

      public void UpdateScore(uint elapsedTime)
      {
         CurrentScore = CurrentScore + elapsedTime;
      }
   }
}
