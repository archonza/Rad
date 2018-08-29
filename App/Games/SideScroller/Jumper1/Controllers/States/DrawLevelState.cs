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
      public DrawLevelState(State nextState)
          : base(nextState) { }

      public override void Execute(GameTime gameTime)
      {
      }
   }
}
