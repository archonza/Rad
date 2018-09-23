using Jumper1.Controllers;
using Jumper1.Views.UI;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumper1.Views.Renderers
{
   public class MonoGameRenderer : AbstractRenderer
   {
      private ContentManager content = StartupController.game.Content;
      private GraphicsDevice graphicsDevice = StartupController.game.GraphicsDevice;
      private SpriteBatch spriteBatch;
      public List<LevelUI> levelUIList;
      public MainMenuUI mainMenuUI;
      public LevelBuilderUI levelBuilderUI;
      public CharacterUI characterUI;

      public MonoGameRenderer()
      {
         levelUIList = new List<LevelUI>();
         levelUIList.Add(UIInitialiser.CreateLevelUI(content, graphicsDevice, "Level/Level1_1"));

         mainMenuUI = UIInitialiser.CreateMainMenuUI(content, "MainMenu/MainMenuFont");

         levelBuilderUI = UIInitialiser.CreateLevelBuilderUI(content);
         levelBuilderUI = UIInitialiser.CreateLevelBuilderUI(content);
         levelBuilderUI = UIInitialiser.CreateLevelBuilderUI(content);
         levelBuilderUI = UIInitialiser.CreateLevelBuilderUI(content);
         characterUI = UIInitialiser.CreateCharacterUI(content);
      }

      public override void Draw()
      {
         spriteBatch = StartupController.game.spriteBatch;
      }

      public override void DrawLevel(int levelNumber)
      {
         spriteBatch = StartupController.game.spriteBatch;
         levelUIList[levelNumber-1].Draw(spriteBatch);
      }

      public override void ClearCharacter(float positionX, float positionY)
      {
         spriteBatch = StartupController.game.spriteBatch;
         characterUI.Clear(spriteBatch, positionX, positionY);
      }

      public override void DrawCharacter(float positionX, float positionY)
      {
         spriteBatch = StartupController.game.spriteBatch;
         characterUI.Draw(spriteBatch, positionX, positionY);
      }

      public override void DrawMainMenu(List<string> textItems, List<int> textItemsPositionX, List<int> textItemsPositionY)
      {
         spriteBatch = StartupController.game.spriteBatch;
         mainMenuUI.Draw(spriteBatch, textItems, textItemsPositionX, textItemsPositionY);
      }

      public override void DrawLevelBuilder()
      {
         spriteBatch = StartupController.game.spriteBatch;
         levelBuilderUI.Draw(spriteBatch);
      }

      public override void MovePlayer(int currentPosition, int newPosition)
      {
         /* Here we shall move the player around */
      }
   }
}
