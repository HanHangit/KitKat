using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KitKat
{
    class Coin : ICollider
    {
        Vector2 position;
        Texture2D text;
        int value;

        public Coin(Texture2D _text, Vector2 _position)
        {
            value = 10;
            text = _text;
            position = _position;
        }

        public Rectangle GetRect()
        {
            return new Rectangle(0, 0, 0, 0);
        }

        public void Update(GameTime gTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
