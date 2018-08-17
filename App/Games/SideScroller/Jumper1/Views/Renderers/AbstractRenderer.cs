using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumper1.Views.Renderers
{
   public abstract class AbstractRenderer
   {
      public abstract void Draw();
      public abstract void DrawLevel(int levelNumber);
      public abstract void MovePlayer(int currentPosition, int newPosition);
   }
}
