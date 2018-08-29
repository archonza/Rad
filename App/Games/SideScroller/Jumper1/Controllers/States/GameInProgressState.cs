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
      bool turnRight = false;
      bool turnLeft = false;

      public GameInProgressState(State nextState)
          : base(nextState) { }

      public override void Execute(GameTime gameTime)
      {
         turnLeftTimer += gameTime.ElapsedGameTime;
         turnRightTimer += gameTime.ElapsedGameTime;

         if ((GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Left)) &&
             (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Right)))
         {
            turnLeft = false;
            turnRight = false;
         }
         else if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Left))
         {
            turnLeftTimer += gameTime.ElapsedGameTime;
            turnLeft = true;
         }
         else if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Right))
         {
            turnRightTimer += gameTime.ElapsedGameTime;
            turnRight = true;
         }

         if ((GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Space)) &&
             ((Character.JumpState == EJumpState.Initial) || (Character.JumpState == EJumpState.JumpComplete)))
         {
            Character.JumpState = EJumpState.JumpInitiate;
         }

         if (turnLeft == true)
         {
            turnRight = false;
            Character.Update(turnLeftTimer.TotalMilliseconds, turnLeft, turnRight);
         }
         else if (turnRight == true)
         {
            turnLeft = false;
            Character.Update(turnRightTimer.TotalMilliseconds, turnLeft, turnRight);
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
