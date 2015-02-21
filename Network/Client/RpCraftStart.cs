namespace Network.Client
{
    class RpCraftStart : ARecvPacket
    {
        protected int RecipeId;

        public override void Read()
        {
            RecipeId = ReadD();
        }

        public override void Process()
        {
            Communication.Global.CraftService.ProcessCraft(Connection.Player, RecipeId);
        }
    }
}
