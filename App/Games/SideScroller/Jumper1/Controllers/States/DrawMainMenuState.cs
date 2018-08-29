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
   public class DrawMainMenuState : State
   {
      public DrawMainMenuState(State nextState)
          : base(nextState) { }

      public override void Execute(GameTime gameTime)
      {
         /* Do nothing for now */
         if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.D1))
         {
            NextState = StateController.States["DrawLevelState"];
            StateController.ChangeState();
         }
         else if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.D2))
         {
            NextState = StateController.States["DrawLevelBuilderState"];
            StateController.ChangeState();
         }
      }
   }
}
