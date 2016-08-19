using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KitKat
{

    enum EBlock
    {
        SimpleBlock,
        Count
    }

    class SimpleBlock : IBlock
    {

        Texture2D text;

        Vector2 position;

        float speed;

        public SimpleBlock(Texture2D text, Vector2 position, float speed)
        {
            this.text = text;
            this.position = position;
            this.speed = speed;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(text, position, Color.White);
        }

        public Rectangle GetRect()
        {
            return new Rectangle((int)position.X, (int)position.Y, text.Width, text.Height);
        }

        public void Update(GameTime gTime)
        {
            position.X -= speed * gTime.ElapsedGameTime.Milliseconds;
        }
    }
}
