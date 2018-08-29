using Jumper1.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumper1.Controllers.States
{
   public class GameInProgressState : State
   {
      TimeSpan turnLeftTimer = TimeSpan.Zero;
      TimeSpan turnRightTimer = TimeSpan.Zero;
      bool hasJumped = false;
      bool turnRight = false;
      bool turnLeft = false;

      public GameInProgressState(State nextState)
          : base(nextState) { }

      public override void Execute(GameTime gameTime)
      {
         turnLeftTimer += gameTime.ElapsedGameTime;
         turnRightTimer += gameTime.ElapsedGameTime;

         Character.Update();

         if ((GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Left)) &&
             (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Right)))
         {
            //turnLeftTimer += gameTime.ElapsedGameTime;
            //Console.WriteLine("Execute1");
            //Character.MoveLeft(turnLeftTimer.TotalMilliseconds);
            Console.WriteLine("Execute3");
         }
         else if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Left))
         {
            turnLeftTimer += gameTime.ElapsedGameTime;
            //Console.WriteLine("Execute1");
            Character.MoveLeft(turnLeftTimer.TotalMilliseconds);
         }
         else if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Right))
         {
            //Console.WriteLine("Execute2");
            turnRightTimer += gameTime.ElapsedGameTime;
            Character.MoveRight(turnRightTimer.TotalMilliseconds);
         }

         if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Space))
         {
            Character.JumpInitiate();
            hasJumped = true;
         }
         else
         {
            
         }

         if (hasJumped == true)
         {
            Character.JumpProgress();
         }

         if (Character.CurrentPositionY + 31 >= 447)
         {
            hasJumped = false;
         }

         if (hasJumped == false)
         {
            Character.JumpComplete();
         }

         if (Keyboard.GetState().IsKeyDown(Keys.Left) == false)
         {
            turnLeftTimer = TimeSpan.Zero;
         }
         if (Keyboard.GetState().IsKeyDown(Keys.Right) == false)
         {
            turnRightTimer = TimeSpan.Zero;
         }
      }
   }
}
