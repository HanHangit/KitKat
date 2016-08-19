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
        float speed;

        public Coin(Texture2D _text, Vector2 _position, float _speed)
        {
            value = 10;
            text = _text;
            position = _position;
            speed = _speed;
        }

        public Rectangle GetRect()
        {
            return new Rectangle(position.ToPoint(), new Point(text.Width, text.Height));
        }

        public void Update(GameTime gTime)
        {
            position.X -= speed * gTime.ElapsedGameTime.Milliseconds;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(text, position, Color.White);
        }
    }
}
