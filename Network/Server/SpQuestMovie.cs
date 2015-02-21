using System.IO;

namespace Network.Server
{
    public class SpQuestMovie : ASendPacket
    {
        protected int MovieId;

        public SpQuestMovie(int movieId)
        {
            MovieId = movieId;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteD(writer, MovieId);
        }
    }
}