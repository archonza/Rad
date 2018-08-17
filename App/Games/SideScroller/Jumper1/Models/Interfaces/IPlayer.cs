using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumper1.Models.Interfaces
{
   public interface IPlayer
   {
      uint CurrentPosition { get; }
      uint CurrentScore { get; }
      string Name { get; set; }
      void SetPosition(uint newPosition);
      void UpdateScore(uint elapsedTime);
   }
}
