using Jumper1.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumper1.Models
{
   class Player : IPlayer
   {
      public uint CurrentPosition { get; private set; } = 0; // This initialises the property to zero, states that it can publically be retrieved and privately set.
      public uint CurrentScore { get; private set; } = 0; // Default score is 0, this can be publicly retrieved and privately set
      public string Name { get; set; } = "Player1"; // Default name is Player1

      public void SetPosition(uint newPosition) => CurrentPosition = newPosition; // this just sets CurrentPosition property

      public void UpdateScore(uint elapsedTime)
      {
         CurrentScore = CurrentScore + elapsedTime;
      }
   }
}
