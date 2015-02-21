using System.IO;
using Data.Structures.Objects;

namespace Network.Server
{
    public class SpProjectile : ASendPacket // len 60
    {
        protected Projectile Projectile;

        public SpProjectile(Projectile projectile)
        {
            Projectile = projectile;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteUid(writer, Projectile.Parent);
            WriteD(writer, Projectile.GetModelId());
            WriteD(writer, 0);
            WriteUid(writer, Projectile);
            WriteD(writer, Projectile.ProjectileSkill.Id);

            WriteF(writer, Projectile.Position.X);
            WriteF(writer, Projectile.Position.Y);
            WriteF(writer, Projectile.Position.Z);

            if (Projectile.TargetPosition != null)
            {
                WriteF(writer, Projectile.TargetPosition.X);
                WriteF(writer, Projectile.TargetPosition.Y);
                WriteF(writer, Projectile.TargetPosition.Z);
            }
            else
            {
                WriteF(writer, Projectile.Position.X);
                WriteF(writer, Projectile.Position.Y);
                WriteF(writer, Projectile.Position.Z);
            }

            WriteF(writer, Projectile.Speed); //Speed here
        }
    }
}