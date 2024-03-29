﻿using System.Data;
using Zelda.Sprites.Classes;

namespace Zelda.Sprites.Factories
{
    public class BlockSpriteFactory : SpriteFactory
    {
        public static ISprite BlueFloorSprite()
        {
            return new Sprite(GetTexture("blocks"), 0, 0, 160, 160, 1);
        }

        public static ISprite PushableBlockSprite()
        {
            return new Sprite(GetTexture("blocks"), 160, 0, 160, 160, 1);
        }

        public static ISprite Statue1Sprite()
        {
            return new Sprite(GetTexture("blocks"), 320, 0, 160, 160, 1);
        }

        public static ISprite Statue2Sprite()
        {
            return new Sprite(GetTexture("blocks"), 480, 0, 160, 160, 1);
        }

        public static ISprite WhiteBrickSprite()
        {
            return new Sprite(GetTexture("blocks"), 640, 0, 160, 160, 1);
        }

        public static ISprite BlackGapSprite()
        {
            return new Sprite(GetTexture("blocks"), 0, 160, 160, 160, 1);
        }

        public static ISprite BlueSandSprite()
        {
            return new Sprite(GetTexture("blocks"), 160, 160, 160, 160, 1);
        }

        public static ISprite BlueGapSprite()
        {
            return new Sprite(GetTexture("blocks"), 320, 160, 160, 160, 1);
        }

        public static ISprite StairsSprite()
        {
            return new Sprite(GetTexture("blocks"), 480, 160, 160, 160, 1);
        }

        public static ISprite LadderSprite()
        {
            return new Sprite(GetTexture("blocks"), 640, 160, 160, 160, 1);
        }
        public static ISprite InvisibleSprite()
        {
            return new Sprite(GetTexture("invisible_block"), 0, 0, 160, 160, 1);
        }

        public static ISprite InvisibleSprite(double sizeInBlocks)
        {
            return new Sprite(GetTexture("invisible_block"), 0, 0, 160, 160, sizeInBlocks);
        }

        public static ISprite FireSprite()
        {
            return new AnimatedSprite(GetTexture("fire"), 1, 2, 10, 0.85);
        }

        public static ISprite OldManWordsSprite()
        {
            return new Sprite(GetTexture("old_man_words"), 10);
        }
    }
}
