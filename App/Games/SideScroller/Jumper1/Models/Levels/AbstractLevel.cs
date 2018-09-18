using Jumper1.Models.CollisionDetection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumper1.Models.Levels
{
   public enum EDifficultyLevel
   {
      Easy,
      Moderate,
      Difficult
   }

   public abstract class AbstractLevel : ICollider
   {
      public abstract float BoundaryTop { get; protected set; }
      public abstract float BoundaryBottom { get; protected set; }
      public abstract float BoundaryLeft { get; protected set; }
      public abstract float BoundaryRight { get; protected set; }
      public virtual float PositionStart { get; private set; }
      public virtual float PositionEnd { get; private set; }
      public abstract float GravitationalAcceleration { get; protected set; }
      public virtual EDifficultyLevel Difficulty { get; set; }
      public abstract TimeSpan TimeLimit { get; protected set; }
      public virtual Stopwatch CurrentTime { get; private set; }
      public AbstractLevel NextLevel { get; set; }

      public AbstractLevel(AbstractLevel nextLevel)
      {
         this.NextLevel = nextLevel;
         CurrentTime = new Stopwatch();
      }

      public virtual void Start()
      {
         /* Adjust TimeLimit depending on Difficulty Level */
         if (Difficulty == EDifficultyLevel.Easy)
         {
            TimeLimit += TimeSpan.FromSeconds(20);
         }
         else if (Difficulty == EDifficultyLevel.Moderate)
         {
            TimeLimit += TimeSpan.FromSeconds(10);
         }
         else
         {
            TimeLimit = TimeLimit;
         }

         CurrentTime.Start();
      }
      public virtual void Update()
      {
         if (CurrentTime.Elapsed >= TimeLimit)
         {
            End();
         }
      }
      public virtual void End()
      {
         CurrentTime.Stop();
      }

      public abstract void AddCollider();

      public abstract void UpdateCollider();

   }
}
