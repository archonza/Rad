using Jumper1.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumper1.Controllers.States
{
   class MoveCharacterState : State
   {
      public MoveCharacterState(State nextState)
          : base(nextState) { }

      public override void Execute()
      {
         if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Right))
         {
            Character.SetPositionX(Character.CurrentPositionX + 1);
         }
      }
   }
}
