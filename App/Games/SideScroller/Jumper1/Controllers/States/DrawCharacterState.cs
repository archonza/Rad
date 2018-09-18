using Jumper1.Models;
using Jumper1.Views.Renderers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumper1.Controllers.States
{
   class DrawCharacterState : State
   {
      private Character character;
      public DrawCharacterState(State nextState, Character character)
          : base(nextState)
      {
         this.character = character;
      }

      public override void Execute(GameTime gameTime)
      {
      }

      public override void Draw(GameTime gameTime, MonoGameRenderer renderer)
      {
         //NextState = StateController.States["DrawCompleteState"];
         //StateController.ChangeState();
         renderer.DrawCharacter(character.CurrentPositionX, character.CurrentPositionY);
         NextState = StateController.States["DrawCompleteState"];
         StateController.ChangeState();
      }

      //public void Draw(MonoGameRenderer renderer)
      //{
      //   renderer.DrawCharacter(character.CurrentPositionX, character.CurrentPositionY);
      //   NextState = StateController.States["DrawCompleteState"];
      //   StateController.ChangeState();
      //}
   }
}
