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

        public List<ICollider> listBlock { get; private set; }
        List<Coin> CoinLlist;

        public Spawner(Texture2D[] textures, Texture2D[] coinTextures)
        {
            this.textures = textures;
            spawnTime = 1000;
            currTime = 0;

            listBlock = new List<ICollider>();

            int initBlock = 10;

            for(int i = 0; i < initBlock; ++i)
            {
                
                listBlock.Add(new SimpleBlock(textures[0], new Vector2(textures[0].Width * i, 400), 0.3f));
            }


        }

        public void Update(GameTime gTime)
        {
            currTime += gTime.ElapsedGameTime.Milliseconds;

            if (currTime >= spawnTime)
            {
                currTime -= spawnTime;
                listBlock.Add(new SimpleBlock(textures[(int)EBlock.SimpleBlock], new Vector2(2000, getRandomBlockHeight()), 0.3f));
            }

            foreach (IBlock b in listBlock)
                b.Update(gTime);
        }

        float getRandomBlockHeight()
        {
            Random rand = new Random();
            return rand.Next(1, 7) * 100;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IBlock b in listBlock)
                b.Draw(spriteBatch);
        }

    }
}
