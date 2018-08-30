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

      public GameInProgressState(State nextState)
          : base(nextState) { }

      public override void Execute(GameTime gameTime)
      {
         turnLeftTimer += gameTime.ElapsedGameTime;
         turnRightTimer += gameTime.ElapsedGameTime;

         if ((GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Left)) &&
             (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Right)))
         {
            Character.HorizontalMoveState = EHorizontalMoveState.Stop;
         }
         else if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Left))
         {
            turnLeftTimer += gameTime.ElapsedGameTime;
            Character.MoveLeftActionDuration = turnLeftTimer.TotalMilliseconds;
            Character.HorizontalMoveState = EHorizontalMoveState.TurnLeft;
         }
         else if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Right))
         {
            turnRightTimer += gameTime.ElapsedGameTime;
            Character.MoveRightActionDuration = turnRightTimer.TotalMilliseconds;
            Character.HorizontalMoveState = EHorizontalMoveState.TurnRight;
         }
         else
         {
            /* Always complete the jump */
            if (Character.JumpState != EJumpState.JumpProgress)
            {
               Character.HorizontalMoveState = EHorizontalMoveState.Stop;
               turnLeftTimer = TimeSpan.Zero;
               turnRightTimer = TimeSpan.Zero;
            }
         }

         if ((GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Space)) &&
             ((Character.JumpState == EJumpState.Initial) || (Character.JumpState == EJumpState.JumpComplete)))
         {
            Character.JumpState = EJumpState.JumpInitiate;
         }

         //if (Keyboard.GetState().IsKeyDown(Keys.Left) == false)
         //{
         //   turnLeftTimer = TimeSpan.Zero;
         //}
         //if (Keyboard.GetState().IsKeyDown(Keys.Right) == false)
         //{
         //   turnRightTimer = TimeSpan.Zero;
         //}

         Character.Update();
      }
   }
}
