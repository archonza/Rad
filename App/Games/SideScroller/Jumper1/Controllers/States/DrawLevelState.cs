using Jumper1.Models;
using Jumper1.Models.Levels;
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
   class DrawLevelState : State
   {
      private AbstractLevel level;
      public DrawLevelState(State nextState, AbstractLevel level)
          : base(nextState)
      {
         this.level = level;
      }

      public override void Execute(GameTime gameTime)
      {
         level.Start();
      }

      public override void Draw(GameTime gameTime, MonoGameRenderer renderer)
      {
         renderer.DrawLevel(LevelManager.Number);
         NextState = StateController.States["DrawCharacterState"];
         StateController.ChangeState();
         //NextState = StateController.States["MoveCharacterState"];
         //StateController.ChangeState();
         //renderer.DrawCharacter(Character.CurrentPositionX, Character.CurrentPositionY);
         //renderer.DrawCharacter();
      }
   }
}
