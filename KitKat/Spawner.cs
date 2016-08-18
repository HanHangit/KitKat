using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitKat
{
    class Spawner
    {

        Texture2D[] textures;

        int spawnTime;
        int currTime;

        List<IBlock> listBlock;

        public Spawner(Texture2D[] textures)
        {
            this.textures = textures;
            spawnTime = 1000;
            currTime = 0;

            listBlock = new List<IBlock>();
        }

        public void Update(GameTime gTime)
        {
            currTime += gTime.ElapsedGameTime.Milliseconds;

            if (currTime >= spawnTime)
            {
                currTime -= spawnTime;
                listBlock.Add(new SimpleBlock(textures[(int)EBlock.SimpleBlock], new Vector2(2000, 400), 0.3f));
            }

            foreach (IBlock b in listBlock)
                b.Update(gTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IBlock b in listBlock)
                b.Draw(spriteBatch);
        }

    }
}
