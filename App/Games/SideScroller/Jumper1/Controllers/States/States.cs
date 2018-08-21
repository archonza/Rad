using Jumper1.Models;
using Jumper1.Views.Renderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumper1.Controllers.States
{
   public abstract class State
   {
      public State(State nextState)
      {
         this.NextState = nextState;
      }

      public State NextState { get; set; }

      public abstract void Execute();
      public void Draw(MonoGameRenderer renderer)
      {
         renderer.DrawMainMenu(MainMenu.ItemTextList, MainMenu.ItemPositionXList, MainMenu.ItemPositionYList);
         //renderer.DrawLevel(Level.Number);
      }
   }
}
