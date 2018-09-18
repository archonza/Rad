using Jumper1.Models;
using Jumper1.Models.CollisionDetection;
using Jumper1.Models.Levels;
using Jumper1.Views.Renderers;
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
      //bool hasCollided = false;
      private AbstractLevel level;
      private Character character;


      public GameInProgressState(State nextState, AbstractLevel level, Character character)
          : base(nextState)
      {
         this.level = level;
         this.character = character;
      }

      public override void Execute(GameTime gameTime)
      {
         level.Update();
         //hasCollided = collusionManager.HasCollided(0);

         turnLeftTimer += gameTime.ElapsedGameTime;
         turnRightTimer += gameTime.ElapsedGameTime;

         if ((GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Left)) &&
             (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Right)))
         {
            character.HorizontalMoveState = EHorizontalMoveState.Stop;
         }
         else if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Left))
         {
            //if (hasCollided == false)
            //{
               turnLeftTimer += gameTime.ElapsedGameTime;
               character.MoveLeftActionDuration = turnLeftTimer.TotalMilliseconds;
               character.HorizontalMoveState = EHorizontalMoveState.TurnLeft;
            //}
            //else
            //{
            //   character.HorizontalMoveState = EHorizontalMoveState.Stop;
            //}
         }
         else if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Right))
         {
            //if (collusionManager.HasCollided(0) == false)
            //{
               turnRightTimer += gameTime.ElapsedGameTime;
               character.MoveRightActionDuration = turnRightTimer.TotalMilliseconds;
               character.HorizontalMoveState = EHorizontalMoveState.TurnRight;
            //}
            //else
            //{
            //   character.HorizontalMoveState = EHorizontalMoveState.Stop;
            //}
         }
         else
         {
            /* Always complete the jump */
            if (character.JumpState != EJumpState.JumpProgress)
            {
               character.HorizontalMoveState = EHorizontalMoveState.Stop;
               turnLeftTimer = TimeSpan.Zero;
               turnRightTimer = TimeSpan.Zero;
            }
         }

         if ((GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Space)) &&
             ((character.JumpState == EJumpState.Initial) || (character.JumpState == EJumpState.JumpComplete)))
         {
            character.JumpState = EJumpState.JumpInitiate;
         }

         //if (Keyboard.GetState().IsKeyDown(Keys.Left) == false)
         //{
         //   turnLeftTimer = TimeSpan.Zero;
         //}
         //if (Keyboard.GetState().IsKeyDown(Keys.Right) == false)
         //{
         //   turnRightTimer = TimeSpan.Zero;
         //}

         character.Update();

         //if (character.HorizontalMoveState == EHorizontalMoveState.TurnRight)
         //{
         //   collusionManager.Update(
         //      0,
         //      EColliderMoveDirection.Forward,
         //      character.CurrentPositionX,
         //      character.CurrentPositionY,
         //      character.CurrentPositionX + character.Width,
         //      character.CurrentPositionY,
         //      character.CurrentPositionX,
         //      character.CurrentPositionY + character.Height,
         //      character.CurrentPositionX + character.Width,
         //      character.CurrentPositionY + character.Height
         //      );
         //}
         //else if (character.HorizontalMoveState == EHorizontalMoveState.TurnLeft)
         //{
         //   collusionManager.Update(
         //      0,
         //      EColliderMoveDirection.Backwards,
         //      character.CurrentPositionX,
         //      character.CurrentPositionY,
         //      character.CurrentPositionX + character.Width,
         //      character.CurrentPositionY,
         //      character.CurrentPositionX,
         //      character.CurrentPositionY + character.Height,
         //      character.CurrentPositionX + character.Width,
         //      character.CurrentPositionY + character.Height
         //      );
         //}
      }

      public override void Draw(GameTime gameTime, MonoGameRenderer renderer)
      {
         renderer.ClearCharacter(character.PreviousPositionX, character.PreviousPositionY);
         renderer.DrawCharacter(character.CurrentPositionX, character.CurrentPositionY);
      }
   }
}
