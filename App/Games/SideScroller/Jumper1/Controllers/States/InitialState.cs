using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jumper1.Models;

namespace Jumper1.Controllers.States
{
   public class InitialState : State
   {
      public InitialState(State nextState)
          : base(nextState) { }

      public override void Execute()
      {
         //Level.InitialiseLevel();
         MainMenu.InitialiseMainMenu();
      }
   }
}
