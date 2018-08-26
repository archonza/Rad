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
   public class LevelBuilderUI
   {
      private List<SpriteUI> sprites;
      public LevelBuilderUI(List<SpriteUI> sprites)
      {
         this.sprites = sprites;
      }

      public void Draw(SpriteBatch spriteBatch)
      {
         foreach (SpriteUI sprite in sprites)
         {
            spriteBatch.Draw(sprite.Image, sprite.Rectangle, Color.White);
         }
      }
   }
}
