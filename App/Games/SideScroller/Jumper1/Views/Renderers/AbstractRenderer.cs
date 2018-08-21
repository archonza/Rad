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
      public abstract void DrawMainMenu(List<string> textList, List<int> positionXList, List<int> positionYList);
      public abstract void MovePlayer(int currentPosition, int newPosition);
   }
}
