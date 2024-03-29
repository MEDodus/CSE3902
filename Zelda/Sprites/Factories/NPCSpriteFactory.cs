﻿using System.Runtime.CompilerServices;
using Zelda.Sprites.Classes;

namespace Zelda.Sprites.Factories
{
    public class NPCSpriteFactory : SpriteFactory
    {
        public static int GHOSTFOLLOWER_ROWS = 1;
        public static int GHOSTFOLLOWER_COLUMNS = 2;
        public static int GHOSTFOLLOWER_SIDELENGTH = 48;
        public static int GHOSTFOLLOWER_LEFT;
        public static int TOP_CORNER = 0;
        public static int GHOSTFOLLWER_FPS = 4;
        public static double GHOSTFOLLOWER_BLOCK_SIZE = 0.6;
        public static int RIGHT_ATTACK_Y = GHOSTFOLLOWER_SIDELENGTH * 2;
        public static int LEFT_ATTACK_Y = GHOSTFOLLOWER_SIDELENGTH * 3;

        //AnimatedSprite(Texture2D texture, int x, int y, int rows, int columns, int rowHeight, int columnWidth, int fps, double sizeInBlocks)

        // Neutral
        public static ISprite OldManSprite()
        {
            return new Sprite(GetTexture("old_man"), 1);
        }

        //Friendly
        public static ISprite LeftGhostFollower()
        {
            return new AnimatedSprite(GetTexture("old_man_ghost"), TOP_CORNER, GHOSTFOLLOWER_SIDELENGTH, GHOSTFOLLOWER_ROWS, GHOSTFOLLOWER_COLUMNS, GHOSTFOLLOWER_SIDELENGTH, GHOSTFOLLOWER_SIDELENGTH, GHOSTFOLLWER_FPS, GHOSTFOLLOWER_BLOCK_SIZE);
        }
        public static ISprite RightGhostFollower()
        {
            return new AnimatedSprite(GetTexture("old_man_ghost"), TOP_CORNER, TOP_CORNER, GHOSTFOLLOWER_ROWS, GHOSTFOLLOWER_COLUMNS, GHOSTFOLLOWER_SIDELENGTH, GHOSTFOLLOWER_SIDELENGTH, GHOSTFOLLWER_FPS, GHOSTFOLLOWER_BLOCK_SIZE);
        }
        public static ISprite LeftAttackGhostFollower()
        {
            return new AnimatedSprite(GetTexture("old_man_ghost"), TOP_CORNER, LEFT_ATTACK_Y, GHOSTFOLLOWER_ROWS, GHOSTFOLLOWER_COLUMNS, GHOSTFOLLOWER_SIDELENGTH, GHOSTFOLLOWER_SIDELENGTH, GHOSTFOLLWER_FPS, GHOSTFOLLOWER_BLOCK_SIZE);
        }
        public static ISprite RightAttackGhostFollower()
        {
            return new AnimatedSprite(GetTexture("old_man_ghost"), TOP_CORNER, RIGHT_ATTACK_Y, GHOSTFOLLOWER_ROWS, GHOSTFOLLOWER_COLUMNS, GHOSTFOLLOWER_SIDELENGTH, GHOSTFOLLOWER_SIDELENGTH, GHOSTFOLLWER_FPS, GHOSTFOLLOWER_BLOCK_SIZE);
        }

        public static ISprite OldManGhostSprite()
        {
            return new AnimatedSprite(GetTexture("old_man_ghost"), 4, 2, 4, 0.6);
        }

        // Enemies (single state)
        public static ISprite BatSprite()
        {
            return new AnimatedSprite(GetTexture("bat"), 1, 2, 8, 0.9);
        }

        public static ISprite GelSprite()
        {
            return new AnimatedSprite(GetTexture("gel"), 1, 2, 8, 0.6);
        }

        public static ISprite SkeletonSprite()
        {
            return new AnimatedSprite(GetTexture("skeleton"), 1, 2, 8, 0.9);
        }

        public static ISprite SpikeCross()
        {
            return new Sprite(GetTexture("spike_cross"), 0.9);
        }

        public static ISprite WallmasterSprite()
        {
            return new AnimatedSprite(GetTexture("hand"), 1, 2, 8, 0.9);
        }

        public static ISprite ZolSprite()
        {
            return new AnimatedSprite(GetTexture("zol"), 1, 2, 8, 0.9);
        }

        // Dragon
        private static int DRAGON_ROW_HEIGHT = 256;
        private static int DRAGON_COLUMN_WIDTH = 192;
        private static int DRAGON_FPS = 3;
        private static double DRAGON_SIZE_IN_BLOCKS = 2.5;
        public static ISprite NonAttackingDragonSprite()
        {
            return new AnimatedSprite(GetTexture("dragon"), 384, 0, 1, 2, DRAGON_ROW_HEIGHT, DRAGON_COLUMN_WIDTH, DRAGON_FPS, DRAGON_SIZE_IN_BLOCKS);
        }

        public static ISprite AttackingDragonSprite()
        {
            return new AnimatedSprite(GetTexture("dragon"), 0, 0, 1, 2, DRAGON_ROW_HEIGHT, DRAGON_COLUMN_WIDTH, DRAGON_FPS, DRAGON_SIZE_IN_BLOCKS);
        }

        //SNAKE SPRITE
        private static int SNAKE_ROW_HEIGHT = 60;
        private static int SNAKE_COLUMN_WIDTH = 64;
        private static int SNAKE_FPS = 8;
        private static double SNAKE_SIZE_IN_BLOCKS = 0.9;
        public static ISprite RightSnakeSprite()
        {
            return new AnimatedSprite(GetTexture("snake"), 0, 0, 1, 2, SNAKE_ROW_HEIGHT, SNAKE_COLUMN_WIDTH, SNAKE_FPS, SNAKE_SIZE_IN_BLOCKS);
        }
        public static ISprite LeftSnakeSprite()
        {
            return new AnimatedSprite(GetTexture("snake"), 0, SNAKE_ROW_HEIGHT, 1, 2, SNAKE_ROW_HEIGHT, SNAKE_COLUMN_WIDTH, SNAKE_FPS, SNAKE_SIZE_IN_BLOCKS);
        }

        //GORIYA SPRITE
        private static int GORIYA_ROW_HEIGHT = 64;
        private static int GORIYA_COLUMN_WIDTH = 60;
        private static int GORIYA_FPS = 8;
        private static double GORIYA_SIZE_IN_BLOCKS = 0.9;
        public static ISprite DownGoriyaSprite()
        {
            return new AnimatedSprite(GetTexture("Goriya"), 0, 0, 1, 2, GORIYA_ROW_HEIGHT, GORIYA_COLUMN_WIDTH, GORIYA_FPS, GORIYA_SIZE_IN_BLOCKS);
        }
        public static ISprite UpGoriyaSprite()
        {
            return new AnimatedSprite(GetTexture("Goriya"), 0, GORIYA_ROW_HEIGHT, 1, 2, GORIYA_ROW_HEIGHT, GORIYA_COLUMN_WIDTH, GORIYA_FPS, GORIYA_SIZE_IN_BLOCKS);
        }
        public static ISprite LeftGoriyaSprite()
        {
            return new AnimatedSprite(GetTexture("Goriya"), 0, GORIYA_ROW_HEIGHT * 2, 1, 2, GORIYA_ROW_HEIGHT, GORIYA_COLUMN_WIDTH, GORIYA_FPS, GORIYA_SIZE_IN_BLOCKS);
        }
        public static ISprite RightGoriyaSprite()
        {
            return new AnimatedSprite(GetTexture("Goriya"), 0, GORIYA_ROW_HEIGHT * 3, 1, 2, GORIYA_ROW_HEIGHT, GORIYA_COLUMN_WIDTH, GORIYA_FPS, GORIYA_SIZE_IN_BLOCKS);
        }
        //Damaged Goriya
        public static ISprite DamagedDownGoriyaSprite()
        {
            return new AnimatedSprite(GetTexture("Goriya"), 0, GORIYA_ROW_HEIGHT * 4, 1, 2, GORIYA_ROW_HEIGHT, GORIYA_COLUMN_WIDTH, GORIYA_FPS, GORIYA_SIZE_IN_BLOCKS);
        }
        public static ISprite DamagedUpGoriyaSprite()
        {
            return new AnimatedSprite(GetTexture("Goriya"), 0, GORIYA_ROW_HEIGHT * 5, 1, 2, GORIYA_ROW_HEIGHT, GORIYA_COLUMN_WIDTH, GORIYA_FPS, GORIYA_SIZE_IN_BLOCKS);
        }
        public static ISprite DamagedLeftGoriyaSprite()
        {
            return new AnimatedSprite(GetTexture("Goriya"), 0, GORIYA_ROW_HEIGHT * 6, 1, 2, GORIYA_ROW_HEIGHT, GORIYA_COLUMN_WIDTH, GORIYA_FPS, GORIYA_SIZE_IN_BLOCKS);
        }
        public static ISprite DamagedRightGoriyaSprite()
        {
            return new AnimatedSprite(GetTexture("Goriya"), 0, GORIYA_ROW_HEIGHT * 7, 1, 2, GORIYA_ROW_HEIGHT, GORIYA_COLUMN_WIDTH, GORIYA_FPS, GORIYA_SIZE_IN_BLOCKS);
        }

        //DODONGO SPRITES
        //Non-Damaged Dodongo
        private static int DODONGO_ROW_HEIGHT = 68;
        private static int DODONGO_VERT_COLUMN_WIDTH = 68;
        private static int DODONGO_HORIZONTAL_COLUMN_WIDTH = 134;
        private static int DODONGO_FPS = 6;
        private static double DODONGO_HORIZONTAL_SIZE_IN_BLOCKS = 2.5;
        private static double DODONGO_VERTICAL_SIZE_IN_BLOCKS = 1.5;

        public static ISprite LeftMovingDodongoSprite()
        {
            return new AnimatedSprite(GetTexture("dodongo"), 0, DODONGO_ROW_HEIGHT * 3, 1, 2, DODONGO_ROW_HEIGHT, DODONGO_HORIZONTAL_COLUMN_WIDTH, DODONGO_FPS, DODONGO_HORIZONTAL_SIZE_IN_BLOCKS);
        }
        public static ISprite RightMovingDodongoSprite()
        {
            return new AnimatedSprite(GetTexture("dodongo"), 0, DODONGO_ROW_HEIGHT * 2, 1, 2, DODONGO_ROW_HEIGHT, DODONGO_HORIZONTAL_COLUMN_WIDTH, DODONGO_FPS, DODONGO_HORIZONTAL_SIZE_IN_BLOCKS);
        }
        public static ISprite UpMovingDodongoSprite()
        {
            return new AnimatedSprite(GetTexture("dodongo"), 0, DODONGO_ROW_HEIGHT, 1, 2, DODONGO_ROW_HEIGHT, DODONGO_VERT_COLUMN_WIDTH, DODONGO_FPS, DODONGO_VERTICAL_SIZE_IN_BLOCKS);
        }
        public static ISprite DownMovingDodongoSprite()
        {
            return new AnimatedSprite(GetTexture("dodongo"), 0, 0, 1, 2, DODONGO_ROW_HEIGHT, DODONGO_VERT_COLUMN_WIDTH, DODONGO_FPS, DODONGO_VERTICAL_SIZE_IN_BLOCKS);
        }
        //Damaged Dodongo Sprite
        public static ISprite DamagedVertDodongoSprite()
        {
            return new AnimatedSprite(GetTexture("dodongo"), 0, DODONGO_ROW_HEIGHT * 4, 1, 1, DODONGO_ROW_HEIGHT, DODONGO_VERT_COLUMN_WIDTH, DODONGO_FPS, DODONGO_VERTICAL_SIZE_IN_BLOCKS);
        }
        public static ISprite DamagedRightDodongoSprite()
        {
            return new AnimatedSprite(GetTexture("dodongo"), 0, DODONGO_ROW_HEIGHT * 5, 1, 1, DODONGO_ROW_HEIGHT, DODONGO_HORIZONTAL_COLUMN_WIDTH, DODONGO_FPS, DODONGO_HORIZONTAL_SIZE_IN_BLOCKS);
        }
        public static ISprite DamagedLeftDodongoSprite()
        {
            return new AnimatedSprite(GetTexture("dodongo"), 0, DODONGO_ROW_HEIGHT * 6, 1, 1, DODONGO_ROW_HEIGHT, DODONGO_HORIZONTAL_COLUMN_WIDTH, DODONGO_FPS, DODONGO_HORIZONTAL_SIZE_IN_BLOCKS);
        }
    }
}
