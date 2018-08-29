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

      public static CharacterUI CreateCharacterUI(ContentManager content)
      {
         Texture2D characterTexture = content.Load<Texture2D>("Character/BoxCharacter1_17x31");
         Rectangle characterTextureBox = new Rectangle(0, 447-31, 17, 31);
         SpriteUI characterSprite = new SpriteUI(characterTextureBox, characterTexture);
         CharacterUI character = new CharacterUI(characterSprite);

         return character;
      }

      public static MainMenuUI CreateMainMenuUI(ContentManager content, string fontPath)
      {
         MainMenuUI mainMenuUI = new MainMenuUI(content.Load<SpriteFont>(fontPath), Color.White);
         return mainMenuUI;
      }

      public static LevelBuilderUI CreateLevelBuilderUI(ContentManager content)
      {
         Texture2D tool1Texture = content.Load<Texture2D>("LevelBuilder/Brick1_16x10");
         Rectangle tool1TextureBox = new Rectangle(0, 0, 16, 10);

         Texture2D tool2Texture = content.Load<Texture2D>("LevelBuilder/Brick1_32x20");
         Rectangle tool2TextureBox = new Rectangle(0, 10, 32, 20);

         Texture2D tool3Texture = content.Load<Texture2D>("LevelBuilder/Brick1_64x40");
         Rectangle tool3TextureBox = new Rectangle(0, 30, 64, 40);

         Texture2D tool4Texture = content.Load<Texture2D>("LevelBuilder/Brick2_294x171");
         Rectangle tool4TextureBox = new Rectangle(0, 70, 294, 171);

         List<SpriteUI> toolSprites = new List<SpriteUI>()
         {
            new SpriteUI(tool1TextureBox, tool1Texture),
            new SpriteUI(tool2TextureBox, tool2Texture),
            new SpriteUI(tool3TextureBox, tool3Texture),
            new SpriteUI(tool4TextureBox, tool4Texture),
         };
         LevelBuilderUI levelBuilderUI = new LevelBuilderUI(toolSprites);
         return levelBuilderUI;
      }
   }
}
