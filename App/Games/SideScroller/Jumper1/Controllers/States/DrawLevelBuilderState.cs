using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jumper1.Models;
using Jumper1.Views.Renderers;
using Microsoft.Xna.Framework;

namespace Jumper1.Controllers.States
{
   public class DrawLevelBuilderState : State
   {
      public DrawLevelBuilderState(State nextState)
          : base(nextState) { }

      public override void Execute(GameTime gameTime)
      {
         /* Do nothing for now */
      }

      public override void Draw(GameTime gameTime, MonoGameRenderer renderer)
      {
         renderer.DrawLevelBuilder();
      }
   }
}
