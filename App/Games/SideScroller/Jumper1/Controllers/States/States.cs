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
   public abstract class State
   {
      public State(State nextState)
      {
         this.NextState = nextState;
      }

      public State NextState { get; set; }

      public abstract void Execute(GameTime gameTime);
      public abstract void Draw(GameTime gameTime, MonoGameRenderer renderer);
      //{
         //if (StateController.CurrentState == StateController.States["DrawMainMenuState"])
         //{
         //   renderer.DrawMainMenu(MainMenu.ItemTextList, MainMenu.ItemPositionXList, MainMenu.ItemPositionYList);
         //}
         //else if (StateController.CurrentState == StateController.States["DrawLevelBuilderState"])
         //{
         //   renderer.DrawLevelBuilder();
         //}
         //else if (StateController.CurrentState == StateController.States["DrawLevelState"])
         //{
         //   renderer.DrawLevel(LevelManager.Number);
         //   NextState = StateController.States["DrawCharacterState"];
         //   StateController.ChangeState();
         //   //NextState = StateController.States["MoveCharacterState"];
         //   //StateController.ChangeState();
         //   //renderer.DrawCharacter(Character.CurrentPositionX, Character.CurrentPositionY);
         //   //renderer.DrawCharacter();
         //}
         //else if (StateController.CurrentState == StateController.States["DrawCharacterState"])
         //{
         //   NextState = StateController.States["DrawCompleteState"];
         //   StateController.ChangeState();
         //}
         //else if (StateController.CurrentState == StateController.States["GameInProgressState"])
         //{
         //   renderer.ClearCharacter(Character.PreviousPositionX, Character.PreviousPositionY);
         //   renderer.DrawCharacter(Character.CurrentPositionX, Character.CurrentPositionY);
         //}

         //renderer.DrawLevel(Level.Number);
      //}
   }
}
