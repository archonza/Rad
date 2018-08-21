using Jumper1.Views.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumper1.Views
{
   public static class UIInitialiser
   {
      public static LevelUI CreateLevelUI(ContentManager content, GraphicsDevice graphicsDevice, string backgroundPath)
      {
         Texture2D backgroundTexture = content.Load<Texture2D>(backgroundPath);
         Rectangle backgroundTextureBox = new Rectangle(0, 0, graphicsDevice.Viewport.Width, graphicsDevice.Viewport.Height);
         SpriteUI backgroundSprite = new SpriteUI(backgroundTextureBox, backgroundTexture);
         LevelUI level = new LevelUI(backgroundSprite);

         return level;
      }

      public static MainMenuUI CreateMainMenuUI(ContentManager content, string fontPath)
      {
         MainMenuUI mainMenuUI = new MainMenuUI(content.Load<SpriteFont>(fontPath), Color.White);
         return mainMenuUI;
      }
   }
}
