using System.IO;
using Data.Structures.Objects;

namespace Network.Server
{
    public class SpRemoveProjectile : ASendPacket
    {
        protected Projectile Projectile;

        public SpRemoveProjectile(Projectile projectile)
        {
            Projectile = projectile;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteUid(writer, Projectile);
            WriteC(writer, 1);
        }
    }
}