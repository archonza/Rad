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
      private static LevelInProgressState levelInProgressState;
      private static LevelCompleteState levelCompleteState;
      private static NextLevelState nextLevelState;

      public static void Initialise()
      {
         levelInProgressState = new LevelInProgressState(levelCompleteState);
         levelCompleteState = new LevelCompleteState(nextLevelState);
         nextLevelState = new NextLevelState(levelInProgressState);
         initialState = new InitialState(levelInProgressState);
         levelInProgressState.NextState = levelCompleteState;
         levelCompleteState.NextState = nextLevelState;
         nextLevelState.NextState = levelInProgressState;

         States.Add("InitialState", initialState);
         States.Add("LevelInProgressState", levelInProgressState);
         States.Add("LevelCompleteState", levelCompleteState);
         States.Add("NextLevelState", nextLevelState);
         
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
