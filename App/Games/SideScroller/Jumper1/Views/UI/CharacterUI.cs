using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumper1.Views.UI
{
   public class CharacterUI
   {
      private SpriteUI sprite;
      public CharacterUI(SpriteUI sprite)
      {
         this.sprite = sprite;
      }

      public void Draw(SpriteBatch spriteBatch)
      {
         spriteBatch.Draw(sprite.Image, sprite.Rectangle, Color.White);
      }
   }

}
