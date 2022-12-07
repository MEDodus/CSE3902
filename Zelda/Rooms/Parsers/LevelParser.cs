namespace Zelda.Rooms.Parsers
{
    public class LevelParser : Parser
    {
        private LevelData levelData;

        public LevelParser(string filename, LevelData levelData)
            : base(null, "leveldata.csv")
        {
            this.levelData = levelData;
        }

        protected override void ParseObject(string identifier, int i, int j)
        {
            int num = int.Parse(identifier);
            if (i == 0)
                levelData.RoomCount = num;
            else if (i == 1)
                levelData.StartRoom = num;
        }
    }
}
