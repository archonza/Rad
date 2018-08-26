using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jumper1.Models;

namespace Jumper1.Controllers.States
{
   public class DisplayLevelBuilderState : State
   {
      public DisplayLevelBuilderState(State nextState)
          : base(nextState) { }

      public override void Execute()
      {
         /* Do nothing for now */
      }
   }
}
