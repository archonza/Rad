using Jumper1.Models;
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

      public override void Execute()
      {
         Level.NextLevel();
      }
   }
}
