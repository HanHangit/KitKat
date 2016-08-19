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
        Texture2D[] coinTextures;

        int spawnTime;
        int currTime;

        public List<ICollider> listBlock { get; private set; }
        public List<Coin> coinList { get; private set; }

        public Spawner(Texture2D[] textures, Texture2D[] _coinTextures)
        {
            this.textures = textures;
            coinTextures = _coinTextures;
            spawnTime = 1000;
            currTime = 0;

            listBlock = new List<ICollider>();
            coinList = new List<Coin>();

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
                Random rand = new Random(System.DateTime.Now.Millisecond);
                if (rand.Next(0, 5) == 0)
                {
                    Rectangle block = listBlock[listBlock.Count - 1].GetRect();
                    Vector2 position = new Vector2(rand.Next(block.X, block.X + block.Width - coinTextures[0].Width), 
                        block.Y - coinTextures[0].Height);
                    coinList.Add(new Coin(coinTextures[0], position, 0.3f));
                }
            }

            foreach (IBlock b in listBlock)
                b.Update(gTime);
            foreach (Coin c in coinList)
                c.Update(gTime);
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
            foreach (Coin c in coinList)
                c.Draw(spriteBatch);
        }

    }
}
