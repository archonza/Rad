using Jumper1.Controllers.States;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumper1.Controllers
{
   public static class StateController
   {
      public static State CurrentState;
      public static Dictionary<string, State> States = new Dictionary<string, State>();
      private static InitialState initialState;
      private static DrawMainMenuState drawMainMenuState;
      private static DrawLevelBuilderState drawLevelBuilderState;
      private static DrawLevelState drawLevelState;
      private static DrawCharacterState drawCharacterState;
      private static DrawCompleteState drawCompleteState;
      private static GameInProgressState gameInProgressState;
      //private static LevelCompleteState levelCompleteState;
      //private static NextLevelState nextLevelState;

      public static void Initialise()
      {
         //levelCompleteState = new LevelCompleteState(nextLevelState);
         //nextLevelState = new NextLevelState(levelInProgressState);
         gameInProgressState = new GameInProgressState(initialState);
         drawCompleteState = new DrawCompleteState(initialState);
         drawCharacterState = new DrawCharacterState(initialState);
         drawLevelState = new DrawLevelState(initialState);
         drawLevelBuilderState = new DrawLevelBuilderState(initialState);
         drawMainMenuState = new DrawMainMenuState(initialState);
         initialState = new InitialState(drawMainMenuState);
         //displayMainMenuState.NextState = displayLevelBuilderState;
         //displayLevelBuilderState.NextState = initialState;
         //displayLevelState.NextState = initialState;
         //levelInProgressState.NextState = levelCompleteState;
         //levelCompleteState.NextState = nextLevelState;
         //nextLevelState.NextState = levelInProgressState;

         States.Add("InitialState", initialState);
         States.Add("DrawMainMenuState", drawMainMenuState);
         States.Add("DrawLevelBuilderState", drawLevelBuilderState);
         States.Add("DrawLevelState", drawLevelState);
         States.Add("DrawCharacterState", drawCharacterState);
         States.Add("DrawCompleteState", drawCompleteState);
         States.Add("GameInProgressState", gameInProgressState);
         //States.Add("LevelCompleteState", levelCompleteState);
         //States.Add("NextLevelState", nextLevelState);

      }
      public static void ChangeState()
      {
         CurrentState = CurrentState.NextState;
      }
      public static void ResetState()
      {
         CurrentState = initialState;
      }
   }
}
