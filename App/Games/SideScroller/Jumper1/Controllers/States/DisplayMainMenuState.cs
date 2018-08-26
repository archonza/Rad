using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jumper1.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Jumper1.Controllers.States
{
   public class DisplayMainMenuState : State
   {
      public DisplayMainMenuState(State nextState)
          : base(nextState) { }

      public override void Execute()
      {
         /* Do nothing for now */
         if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.D1))
         {
            NextState = StateController.States["DisplayLevelState"];
            StateController.ChangeState();
         }
         else if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.D2))
         {
            NextState = StateController.States["DisplayLevelBuilderState"];
            StateController.ChangeState();
         }
      }
   }
}
