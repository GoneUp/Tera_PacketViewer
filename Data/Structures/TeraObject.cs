namespace Data.Structures
{
    public abstract class TeraObject : Uid
    {
        public TeraObject Parent;

        public override void Release()
        {
            base.Release();
            
            Parent = null;
        }
    }
}