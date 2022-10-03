using Microsoft.Xna.Framework;
using Zelda.Blocks;
using Zelda.Items;
using Zelda.NPCs;
using Zelda.Link;

namespace Zelda.Commands.Classes
{
    public class Reset : ICommand
    {
        private ItemBuilder itemBuilder;
        private BlockBuilder blockBuilder;
        private NPCBuilder npcBuilder;
        private Game1 game;

        public Reset(ItemBuilder itemBuilder, BlockBuilder blockBuilder, NPCBuilder npcBuilder, Game1 game)
        {
            this.itemBuilder = itemBuilder;
            this.blockBuilder = blockBuilder;
            this.npcBuilder = npcBuilder;
            this.game = game;
        }

        public void Execute(GameTime gameTime)
        {
            itemBuilder.Reset();
            blockBuilder.Reset();
            npcBuilder.Reset();
            game.link.Reset();
        }
    }
}
