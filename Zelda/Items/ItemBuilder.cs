using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Items.Classes;

namespace Zelda.Items
{
    public class ItemBuilder
    {
        private readonly Vector2 SPAWN_POS = new Vector2(100, 100);
        private IItem[] items = new IItem[35];
        private int i = 0;

        public ItemBuilder()
        {
            items[0] = new Arrow(SPAWN_POS);
            items[1] = new BlueCandle(SPAWN_POS);
            items[2] = new BluePotion(SPAWN_POS);
            items[3] = new Bomb(SPAWN_POS);
            items[4] = new Boomerang(SPAWN_POS);
            items[5] = new Bow(SPAWN_POS);
            items[6] = new Clock(SPAWN_POS);
            items[7] = new Compass(SPAWN_POS);
            items[8] = new Fairy(SPAWN_POS);
            items[9] = new Heart(SPAWN_POS);
            items[10] = new HeartContainer(SPAWN_POS);
            items[11] = new Key(SPAWN_POS);
            items[12] = new Map(SPAWN_POS);
            items[13] = new Rupy(SPAWN_POS);
            items[14] = new Triforce(SPAWN_POS);
            items[15] = new Fire(SPAWN_POS);
            items[16] = new BlueRing(SPAWN_POS);
            items[17] = new BookOfMagic(SPAWN_POS);
            items[18] = new Food(SPAWN_POS);
            items[19] = new FiveRupies(SPAWN_POS);
            items[20] = new Letter(SPAWN_POS);
            items[21] = new MagicalBoomerang(SPAWN_POS);
            items[22] = new MagicalKey(SPAWN_POS);
            items[23] = new MagicalRod(SPAWN_POS);
            items[24] = new MagicalShield(SPAWN_POS);
            items[25] = new PowerBracelet(SPAWN_POS);
            items[26] = new Raft(SPAWN_POS);
            items[27] = new Recorder(SPAWN_POS);
            items[28] = new RedCandle(SPAWN_POS);
            items[29] = new RedPotion(SPAWN_POS);
            items[30] = new RedRing(SPAWN_POS);
            items[31] = new SilverArrow(SPAWN_POS);
            items[32] = new Stepladder(SPAWN_POS);
            items[33] = new Sword(SPAWN_POS);
            items[34] = new WhiteSword(SPAWN_POS);
        }

        public void PreviousItem()
        {
            if (i == 0)
            {
                i = items.Length - 1;
            }
            else
            {
                i--;
            }
        }

        public void NextItem()
        {
            i = (i + 1) % items.Length;
        }

        public void Reset()
        {
            i = 0;
        }

        public void Update(GameTime gameTime)
        {
            items[i].Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            items[i].Draw(spriteBatch);
        }
    }
}
