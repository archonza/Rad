using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Jumper1.Views.UI
{
   public class SpriteUI
   {
      public SpriteUI(Rectangle rectangle, Texture2D image)
      {
         this.Rectangle = rectangle;
         this.Image = image;
      }

      public Rectangle Rectangle;
      public Texture2D Image { get; set; }
   }
}
