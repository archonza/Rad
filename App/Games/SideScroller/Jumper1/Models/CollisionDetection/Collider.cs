using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumper1.Models.CollisionDetection
{
   public enum EColliderMoveDirection
   {
      None,
      Backwards,
      Forward,
      Up,
      Down
   }

   public enum EColliderType
   {
      Character,
      WorldMovable,
      WorldFixed
   }

   public class Collider
   {
      public Collider(uint id, EColliderMoveDirection moveDirection, EColliderType type, float vertex1x, float vertex1y, float vertex2x, float vertex2y, float vertex3x, float vertex3y, float vertex4x, float vertex4y)
      {
         Id = id;
         MoveDirection = moveDirection;
         Type = type;
         Vertex1x = vertex1x;
         Vertex1y = vertex1y;
         Vertex2x = vertex2x;
         Vertex2y = vertex2y;
         Vertex3x = vertex3x;
         Vertex3y = vertex3y;
         Vertex4x = vertex4x;
         Vertex4y = vertex4y;
      }

      public uint Id { get; set; }
      public EColliderMoveDirection MoveDirection { get; set; }
      public EColliderType Type { get; set; }
      public float Vertex1x { get; set; }
      public float Vertex1y { get; set; }
      public float Vertex2x { get; set; }
      public float Vertex2y { get; set; }
      public float Vertex3x { get; set; }
      public float Vertex3y { get; set; }
      public float Vertex4x { get; set; }
      public float Vertex4y { get; set; }

      public void Update(uint id, EColliderMoveDirection moveDirection, float vertex1x, float vertex1y, float vertex2x, float vertex2y, float vertex3x, float vertex3y, float vertex4x, float vertex4y)
      {
         Id = id;
         MoveDirection = moveDirection;
         Vertex1x = vertex1x;
         Vertex1y = vertex1y;
         Vertex2x = vertex2x;
         Vertex2y = vertex2y;
         Vertex3x = vertex3x;
         Vertex3y = vertex3y;
         Vertex4x = vertex4x;
         Vertex4y = vertex4y;
      }
   }
}
