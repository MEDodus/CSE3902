using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zelda.Sprites
{
    public class Items
    {
        private readonly int itemSize = 35;
        private ISprite[] items;
        private int idx;

        public Items()
        {
            items = new ISprite[itemSize];
            idx = 0;
            InitItems();
        }

        public void InitItems()
        {
            items[0] = new Arrow(TextureStorage.GetTexture(TextureStorage.SpriteSheet.Arrow));
            items[1] = new BlueCandle(TextureStorage.GetTexture(TextureStorage.SpriteSheet.BlueCandle));
            items[2] = new BluePotion(TextureStorage.GetTexture(TextureStorage.SpriteSheet.BluePotion));
            items[3] = new BlueRing(TextureStorage.GetTexture(TextureStorage.SpriteSheet.BlueRing));
            items[4] = new Bomb(TextureStorage.GetTexture(TextureStorage.SpriteSheet.Bomb));
            items[5] = new BookOfMagic(TextureStorage.GetTexture(TextureStorage.SpriteSheet.BookOfMagic));
            items[6] = new Boomerang(TextureStorage.GetTexture(TextureStorage.SpriteSheet.Boomerang));
            items[7] = new Bow(TextureStorage.GetTexture(TextureStorage.SpriteSheet.Bow));
            items[8] = new Clock(TextureStorage.GetTexture(TextureStorage.SpriteSheet.Clock));
            items[9] = new Compass(TextureStorage.GetTexture(TextureStorage.SpriteSheet.Compass));
            items[10] = new Fairy(TextureStorage.GetTexture(TextureStorage.SpriteSheet.Fairy));
            items[11] = new Fire(TextureStorage.GetTexture(TextureStorage.SpriteSheet.Fire));
            items[12] = new Food(TextureStorage.GetTexture(TextureStorage.SpriteSheet.Food));
            items[13] = new Heart(TextureStorage.GetTexture(TextureStorage.SpriteSheet.Heart));
            items[14] = new HeartContainer(TextureStorage.GetTexture(TextureStorage.SpriteSheet.HeartContainer));
            items[15] = new Key(TextureStorage.GetTexture(TextureStorage.SpriteSheet.Key));
            items[16] = new FiveRupies(TextureStorage.GetTexture(TextureStorage.SpriteSheet.FiveRupies));
            items[17] = new Letter(TextureStorage.GetTexture(TextureStorage.SpriteSheet.Letter));
            items[18] = new MagicalBoomerang(TextureStorage.GetTexture(TextureStorage.SpriteSheet.MagicalBoomerang));
            items[19] = new MagicalKey(TextureStorage.GetTexture(TextureStorage.SpriteSheet.MagicalKey));
            items[20] = new MagicalRod(TextureStorage.GetTexture(TextureStorage.SpriteSheet.MagicalRod));
            items[21] = new MagicalShield(TextureStorage.GetTexture(TextureStorage.SpriteSheet.MagicalShield));
            items[22] = new Map(TextureStorage.GetTexture(TextureStorage.SpriteSheet.Map));
            items[23] = new PowerBracelet(TextureStorage.GetTexture(TextureStorage.SpriteSheet.PowerBracelet));
            items[24] = new Raft(TextureStorage.GetTexture(TextureStorage.SpriteSheet.Raft));
            items[25] = new Recorder(TextureStorage.GetTexture(TextureStorage.SpriteSheet.Recorder));
            items[26] = new RedCandle(TextureStorage.GetTexture(TextureStorage.SpriteSheet.RedCandle));
            items[27] = new RedPotion(TextureStorage.GetTexture(TextureStorage.SpriteSheet.RedPotion));
            items[28] = new RedRing(TextureStorage.GetTexture(TextureStorage.SpriteSheet.RedRing));
            items[29] = new Rupy(TextureStorage.GetTexture(TextureStorage.SpriteSheet.Rupy));
            items[30] = new SilverArrow(TextureStorage.GetTexture(TextureStorage.SpriteSheet.SilverArrow));
            items[31] = new Stepladder(TextureStorage.GetTexture(TextureStorage.SpriteSheet.Stepladder));
            items[32] = new Sword(TextureStorage.GetTexture(TextureStorage.SpriteSheet.Sword));
            items[33] = new Triforce(TextureStorage.GetTexture(TextureStorage.SpriteSheet.Triforce));
            items[34] = new WhiteSword(TextureStorage.GetTexture(TextureStorage.SpriteSheet.WhiteSword));
        }

        public void PreviousItem()
        {
            if (idx == 0)
            {
                idx = items.Length - 1;
            }
            else
            {
                idx--;
            }
        }

        public void NextItem()
        {
            if (idx == items.Length - 1)
            {
                idx = 0;
            }
            else
            {
                idx++;
            }
        }

        public void Update()
        {
            items[idx].Update();
        }

        public void Reset()
        {
            idx = 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            ISprite item = items[idx];
            spriteBatch.Begin();
            if (item != null) spriteBatch.Draw(item.Texture, item.DestinationLocation, item.SourceLocation, Color.White);
            spriteBatch.End();
        }
    }
}
