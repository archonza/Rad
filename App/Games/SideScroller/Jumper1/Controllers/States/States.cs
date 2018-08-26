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
         if (StateController.CurrentState == StateController.States["DisplayMainMenuState"])
         {
            renderer.DrawMainMenu(MainMenu.ItemTextList, MainMenu.ItemPositionXList, MainMenu.ItemPositionYList);
         }
         else if (StateController.CurrentState == StateController.States["DisplayLevelBuilderState"])
         {
            renderer.DrawLevelBuilder();
         }
         else if (StateController.CurrentState == StateController.States["DisplayLevelState"])
         {
            renderer.DrawLevel(Level.Number);
            //renderer.DrawCharacter();
         }
         else if (StateController.CurrentState == StateController.States["MoveCharacterState"])
         {
            renderer.DrawCharacter(Character.CurrentPositionX, Character.CurrentPositionY);
         }

         //renderer.DrawLevel(Level.Number);
      }
   }
}
