using Jumper1.Models;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumper1.Controllers.States
{
   public class LevelCompleteState : State
   {
      public LevelCompleteState(State nextState)
          : base(nextState) { }

      public override void Execute(GameTime gameTime)
      {
         if (Level.Number == 3)
         {
            Level.ResetLevel();
            StateController.ResetState();
         }
      }
   }
}
