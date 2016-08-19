using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KitKat
{
    class Player : ICollider
    {
        Texture2D text;
        Vector2 position;
        Vector2 move;


        Spawner spawner;

        float gravity;

        public Player(Spawner spawner, Texture2D _text, Vector2 _position)
        {
            text = _text;
            position = _position;
            gravity = 0.3f;
            this.spawner = spawner;
            move = Vector2.Zero;
        }

        public void Update(GameTime gTime)
        {
            KeyboardState keyState = Keyboard.GetState();

            move = new Vector2(0, gravity);

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                move += new Vector2(-1, 0);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                move += new Vector2(1, 0);
            }

            foreach (ICollider c in spawner.listBlock)
            {
                if (Collision.CheckCollision(this, new Vector2(move.X, 0), c, c.GetMove()))
                {
                    move.X = Collision.CheckCollisionVector(this, new Vector2(move.X, 0), c, c.GetMove()).X;
                }

                if (Collision.CheckCollision(this, new Vector2(0, move.Y), c, c.GetMove()))
                {
                    move.Y = Collision.CheckCollisionVector(this, new Vector2(0, move.Y), c, c.GetMove()).X;
                }
            }

            position += new Vector2(move.X, 0);
            position += new Vector2(0, move.Y);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(text, position, Color.White);
        }

        public Rectangle GetRect()
        {
            return new Rectangle((int)position.X, (int)position.Y, text.Width, text.Height);
        }

        public Vector2 GetMove()
        {
            return move;
        }
    }
}
