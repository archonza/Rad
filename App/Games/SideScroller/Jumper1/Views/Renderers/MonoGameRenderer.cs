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

      public MonoGameRenderer()
      {
         levelUIList = new List<LevelUI>();
         levelUIList.Add(UIInitialiser.CreateLevel(content, graphicsDevice, "Level/LevelBackground1"));
         levelUIList.Add(UIInitialiser.CreateLevel(content, graphicsDevice, "Level/LevelBackground2"));
         levelUIList.Add(UIInitialiser.CreateLevel(content, graphicsDevice, "Level/LevelBackground3"));
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

      public override void MovePlayer(int currentPosition, int newPosition)
      {
         /* Here we shall move the player around */
      }
   }
}
