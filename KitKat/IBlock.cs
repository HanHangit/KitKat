using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitKat
{
    interface IBlock
    {
        void Update(GameTime gTime);
        void Draw(SpriteBatch spriteBatch);

    }
}
