using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumper1.Controllers.States
{
   public class LevelInProgressState : State
   {
      public LevelInProgressState(State nextState)
          : base(nextState) { }

      public override void Execute()
      {
         /* Do nothing */
      }
   }
}
