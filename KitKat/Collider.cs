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
        Rectangle GetRect();
        Vector2 GetMove();

    }

    class Collision
    {
        public static bool CheckCollision(ICollider t1, ICollider t2)
        {
            return RectCollision(t1.GetRect(), t2.GetRect());
        }

        public static bool CheckCollision(ICollider t1, Vector2 move1, ICollider t2, Vector2 move2)
        {
            return RectCollision(new Rectangle(t1.GetRect().Location + move1.ToPoint(), t1.GetRect().Size), new Rectangle(t2.GetRect().Location + move2.ToPoint(), t2.GetRect().Size));
        }

        /// <summary>
        /// Gibt die neue Position zurück, die Object1 haben muss, damit es nicht in Objekt 2 drinne landet. 
        /// -Es wird "geschoben".
        /// Object1 ist das Object was geschoben werden soll.
        /// </summary>
        public static Vector2 CheckCollisionVector(ICollider t1, Vector2 move1, ICollider t2, Vector2 move2)
        {
            if (RectCollision(new Rectangle(t1.GetRect().Location + move1.ToPoint(), t1.GetRect().Size), new Rectangle(t2.GetRect().Location + move2.ToPoint(), t2.GetRect().Size))
                && RectCollision(t1.GetRect(), new Rectangle(t2.GetRect().Location + move2.ToPoint(), t2.GetRect().Size)))
                return move2;
            else
                return move1;
        }

        static bool RectCollision(Rectangle r1, Rectangle r2)
        {
            if (r1.X < r2.X + r2.Width && r1.X + r1.Width > r2.X
                && r1.Y < r2.Y + r2.Height && r1.Y + r1.Height > r2.Y)
                return true;
            else
                return false;
        }


    }


}
