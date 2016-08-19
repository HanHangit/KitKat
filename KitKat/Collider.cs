using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitKat
{
    interface ICollider
    {
        Vector2 GetPosition();
        Vector2 GetSize();
        Vector2 GetMove();

    }

    class Collision
    {
        public static bool CheckCollision(ICollider t1, ICollider t2)
        {
            return RectCollision(t1.GetPosition(),t1.GetSize(), t2.GetPosition(), t2.GetSize());
        }

        public static bool CheckCollision(ICollider t1, Vector2 move1, ICollider t2, Vector2 move2)
        {
            return (RectCollision(t1.GetPosition() + move1,
                t1.GetSize(),
                t2.GetPosition() + move2,
                t2.GetSize()));
        }

        /// <summary>
        /// Gibt die neue Position zurück, die Object1 haben muss, damit es nicht in Objekt 2 drinne landet. 
        /// -Es wird "geschoben".
        /// Object1 ist das Object was geschoben werden soll.
        /// </summary>
        public static Vector2 CheckCollisionVector(ICollider t1, Vector2 move1, ICollider t2, Vector2 move2)
        {

            if (RectCollision(t1.GetPosition() + move1, 
                t1.GetSize(), 
                t2.GetPosition() + move2,
                t2.GetSize()))
                return move2;
            else
                return move1;
        }

        static bool RectCollision(Vector2 pos1, Vector2 size1, Vector2 pos2, Vector2 size2)
        {
            if (pos1.X < pos2.X + size2.X && pos1.X + size1.X > pos2.X
                && pos1.Y < pos2.Y + size2.Y && pos1.Y + size1.Y > pos2.Y)
                return true;
            else
                return false;
        }


    }


}
