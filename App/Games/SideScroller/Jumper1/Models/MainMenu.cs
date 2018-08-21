using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumper1.Models
{
   public class MainMenu
   {
      private static List<string> itemTextList;
      private static List<int> itemPositionXList;
      private static List<int> itemPositionYList;

      public static List<string> ItemTextList { get => itemTextList; private set => itemTextList = value; }
      public static List<int> ItemPositionXList { get => itemPositionXList; private set => itemPositionXList = value; }
      public static List<int> ItemPositionYList { get => itemPositionYList; private set => itemPositionYList = value; }

      public static void InitialiseMainMenu()
      {
         ItemTextList = new List<string>()
         {
            "1. New Game",
            "2. Level Builder",
            "X. Exit"
         };

         ItemPositionXList = new List<int>()
         {
            0,
            0,
            0,
         };

         ItemPositionYList = new List<int>()
         {
            0,
            20,
            40
         };
      }
   }
}
