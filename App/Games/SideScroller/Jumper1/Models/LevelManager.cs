using Jumper1.Models.Levels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumper1.Models
{
   public static class LevelManager
   {

      public static void Initialise()
      {

      }


      public static int Number { get; private set; } = 1; // level number is 1 by default

      public static void NextLevel() => Number++; // increment level number by 1 if called

      public static void ResetLevel() => Number = 1; // reset level to default if called
   }
}
