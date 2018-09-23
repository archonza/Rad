using Jumper1.Models.CollisionDetection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumper1.Models.Levels
{
   public class LevelOne : AbstractLevel, ICollider
   {
      public override TimeSpan TimeLimit { get; protected set; } = TimeSpan.FromSeconds(120);
      public override float GravitationalAcceleration { get; protected set; } = 0.20f;
      public override float BoundaryTop { get; protected set; }
      public override float BoundaryBottom { get; protected set; } = 447.0f;
      public override float BoundaryLeft { get; protected set; } = 0f;
      public override float BoundaryRight { get; protected set; } = 800f;
      private CollusionManager collusionManager;
      public LevelOne(AbstractLevel nextLevel, CollusionManager collusionManager)
          : base(nextLevel)
      {
         this.collusionManager = collusionManager;
         AddCollider();
      }

      override public void AddCollider()
      {
         collusionManager.AddCollider(new Collider(
            1,
            EColliderType.WorldFixed,
            BoundaryLeft + 200,
            BoundaryBottom - 31,
            200 + 16f,
            BoundaryBottom - 31,
            200,
            BoundaryBottom,
            BoundaryLeft + 16f,
            BoundaryBottom));
         collusionManager.AddCollider(new Collider(
               2,
               EColliderType.WorldFixed,
               300,
               BoundaryBottom - 31,
               300 + 16f,
               BoundaryBottom - 31,
               300,
               BoundaryBottom,
               BoundaryLeft + 16f,
               BoundaryBottom));
      }

      override public void UpdateCollider()
      {
         throw new NotImplementedException();
      }
   }
}
