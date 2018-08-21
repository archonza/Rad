using Jumper1.Views.Renderers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumper1.Views.UI
{
   public class MainMenuUI
   {
      SpriteFont font;
      Color color;

      public MainMenuUI(SpriteFont font, Color color)
      {
         this.font = font;
         this.color = color;
      }

      public void Draw(SpriteBatch spriteBatch, List<string> items, List<int> itemsPositionX, List<int> itemPositionY)
      {
         for (int i = 0; i < items.Count; i++)
         {
            spriteBatch.DrawString(font, items.ElementAt(i), new Vector2((float)itemsPositionX.ElementAt(i), (float)itemPositionY.ElementAt(i)), color);
         }
      }
   }
}
