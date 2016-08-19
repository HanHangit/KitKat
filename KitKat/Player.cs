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
    class Player
    {
        Texture2D text;
        Vector2 position;

        public Player(Texture2D _text, Vector2 _position)
        {
            text = _text;
            position = _position;
        }

        public void Update(GameTime gTime)
        {
            KeyboardState keyState = Keyboard.GetState();

            Vector2 move = new Vector2(0, 0);
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                move += new Vector2(-1, 0);
            }
            if(Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                move += new Vector2(1, 0);
            }
            position += move;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(text, position, Color.White);
        }



    }
}
