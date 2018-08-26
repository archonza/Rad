using Jumper1.Controllers.States;
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
      private static DisplayMainMenuState displayMainMenuState;
      private static DisplayLevelBuilderState displayLevelBuilderState;
      private static DisplayLevelState displayLevelState;
      private static MoveCharacterState moveCharacterState;
      //private static LevelInProgressState levelInProgressState;
      //private static LevelCompleteState levelCompleteState;
      //private static NextLevelState nextLevelState;

      public static void Initialise()
      {
         //levelInProgressState = new LevelInProgressState(levelCompleteState);
         //levelCompleteState = new LevelCompleteState(nextLevelState);
         //nextLevelState = new NextLevelState(levelInProgressState);
         displayMainMenuState = new DisplayMainMenuState(initialState);
         displayLevelState = new DisplayLevelState(initialState);
         displayLevelBuilderState = new DisplayLevelBuilderState(initialState);
         initialState = new InitialState(displayMainMenuState);
         moveCharacterState = new MoveCharacterState(initialState);
         //displayMainMenuState.NextState = displayLevelBuilderState;
         //displayLevelBuilderState.NextState = initialState;
         //displayLevelState.NextState = initialState;
         //levelInProgressState.NextState = levelCompleteState;
         //levelCompleteState.NextState = nextLevelState;
         //nextLevelState.NextState = levelInProgressState;

         States.Add("InitialState", initialState);
         States.Add("DisplayMainMenuState", displayMainMenuState);
         States.Add("DisplayLevelBuilderState", displayLevelBuilderState);
         States.Add("DisplayLevelState", displayLevelState);
         States.Add("MoveCharacterState", moveCharacterState);
         //States.Add("LevelInProgressState", levelInProgressState);
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
