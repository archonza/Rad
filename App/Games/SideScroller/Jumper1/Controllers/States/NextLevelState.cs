using Jumper1.Models;
using Jumper1.Views.Renderers;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumper1.Controllers.States
{
   class NextLevelState : State
   {
      public NextLevelState(State nextState)
          : base(nextState) { }

      public override void Execute(GameTime gameTime)
      {
         LevelManager.NextLevel();
      }

      public override void Draw(GameTime gameTime, MonoGameRenderer renderer)
      {
         throw new NotImplementedException();
      }
   }
}
