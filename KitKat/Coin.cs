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
        Vector2 move;
        Texture2D text;
        int value;
        float speed;

        public Coin(Texture2D _text, Vector2 _position, float _speed)
        {
            value = 10;
            text = _text;
            position = _position;
            speed = _speed;
            move = new Vector2(speed, 0);
        }

        public Rectangle GetRect()
        {
            return new Rectangle(position.ToPoint(), new Point(text.Width, text.Height));
        }

        public void Update(GameTime gTime)
        {
            move = new Vector2(speed, 0) * gTime.ElapsedGameTime.Milliseconds;
            position += move;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(text, position, Color.White);
        }

        public Vector2 GetMove()
        {
            throw new NotImplementedException();
        }
    }
}
