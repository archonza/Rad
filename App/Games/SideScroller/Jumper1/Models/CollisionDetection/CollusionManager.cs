using Jumper1.Models.CollisionDetection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumper1.Models
{
   public class CollusionManager
   {
      private List<Collider> colliders = new List<Collider>();

      public CollusionManager()
      {
      }

      public void AddCollider(Collider collider)
      {
         colliders.Add(collider);
      }

      public bool HasCollided(uint id)
      {
         bool hasCollided = false;

         Collider collider = colliders.Find(c => c.Id == id);

         foreach (Collider c in colliders)
         {
            if (collider != c)
            {
               if (collider.Type == EColliderType.Character)
               {
                  /* Move right */
                  if ((collider.Vertex2x >= c.Vertex1x) &&
                      (collider.Vertex2x <= c.Vertex2x) &&
                      (collider.Vertex3y >= c.Vertex1y) &&
                      (collider.Vertex3y <= c.Vertex3y))
                  {
                     hasCollided = true;
                     break;
                  }
                  /* Move left */
                  else if ((collider.Vertex1x <= c.Vertex2x) &&
                           (collider.Vertex1x >= c.Vertex1x) &&
                           (collider.Vertex3y >= c.Vertex1y) &&
                           (collider.Vertex3y <= c.Vertex3y))
                  {
                     hasCollided = true;
                     break;
                  }
                  else
                  {
                     hasCollided = false;
                  }
               } // if (collider.Type == EColliderType.Character)
            } // if (collider != c)
         } // foreach (Collider c in colliders)

         return hasCollided;
      }

      public void Update(uint id, float vertex1x, float vertex1y, float vertex2x, float vertex2y, float vertex3x, float vertex3y, float vertex4x, float vertex4y)
      {
         Collider collider = colliders.Find(c => c.Id == id);
         collider.Update(id, vertex1x, vertex1y, vertex2x, vertex2y, vertex3x, vertex3y, vertex4x, vertex4y);
      }
   }
}
