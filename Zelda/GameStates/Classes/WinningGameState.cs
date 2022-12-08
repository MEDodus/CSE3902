using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Achievements;
using Zelda.Link;
using Zelda.NPCs.FriendlyNPCs;
using Zelda.Projectiles;
using Zelda.Rooms;
using Zelda.Sound;
using Zelda.Sprites.Factories;
using Color = Microsoft.Xna.Framework.Color;

namespace Zelda.GameStates.Classes
{
    public class WinningGameState : IGameState
    {
        private Game1 game;
        private TriforceLink decoratedLink;
        private double timer;
        private SpriteFont font1;
        private SpriteFont font2;

        public WinningGameState(Game1 game)
        {
            SoundManager.Instance.PlayGetItemSound();
            this.game = game;
            decoratedLink = new TriforceLink(game.Link, game);
            game.Link = decoratedLink;
            timer = 1.5;
            font1 = HUDSpriteFactory.WinOrLoseFont();
            font2 = HUDSpriteFactory.HUDFont();
            game.GraphicClear();
            AchievementManager.UnlockNextLevel();
        }

        private bool swappedScreens = false;
        public void Update(GameTime gameTime)
        {
            timer -= gameTime.ElapsedGameTime.TotalSeconds;
            if (timer <= 0 && !swappedScreens)
            {
                swappedScreens = true;
                decoratedLink.RemoveDecorator();
                FriendlyNPCManager.Instance.FriendlyNPCs.Clear();
                SoundManager.Instance.Stop();
                SoundManager.Instance.PlaySecretSound();
            }
            // Update only some game objects
            RoomBuilder.Instance.Update(gameTime);
            game.Link.Update(gameTime);
            game.HUD.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw all game objects
            if (timer <= 0)
            {
                game.GraphicClear();
                spriteBatch.DrawString(font1, "YOU WIN !", new Vector2(200, 300), Color.Green);
                spriteBatch.DrawString(font2, "Click to continue", new Vector2(420, 550), Color.White);
            }
            else
            {
                RoomBuilder.Instance.Draw(spriteBatch);
                ProjectileStorage.Draw(spriteBatch);
                game.Link.Draw(spriteBatch);
                RoomBuilder.Instance.DrawTopLayer(spriteBatch);
                game.HUD.Draw(spriteBatch);
            }
        }

        public void LeftClick()
        {
            game.GameState = new MenuGameState(game);
        }

        public void RightClick()
        {
            game.GameState = new MenuGameState(game);
        }

        public void Up()
        {

        }

        public void Down()
        {

        }

        public void Left()
        {

        }

        public void Right()
        {

        }
    }
}
