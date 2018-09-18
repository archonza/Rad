using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumper1.Models.CollisionDetection
{
   public interface ICollider
   {
      void AddCollider();
      void UpdateCollider();
   }
}
