using Microsoft.Xna.Framework;
using Zelda.Blocks;
using Zelda.Items;
using Zelda.NPCs;

namespace Zelda.Commands.Classes
{
    public class Reset : ICommand
    {
        private ItemBuilder itemBuilder;
        private BlockBuilder blockBuilder;
        private NPCBuilder npcBuilder;
        //private ILink link;

        public Reset(ItemBuilder itemBuilder, BlockBuilder blockBuilder, NPCBuilder npcBuilder)
        {
            this.itemBuilder = itemBuilder;
            this.blockBuilder = blockBuilder;
            this.npcBuilder = npcBuilder;
            //this.link = link;
        }

        public void Execute(GameTime gameTime)
        {
            itemBuilder.Reset();
            blockBuilder.Reset();
            npcBuilder.Reset();
            //link.Reset();
        }
    }
}
