using JetBrains.Annotations;

namespace Assets.Scripts.Data
{
    public class FleetInfo
    {
        public int ID;
        [NotNull] public string Name;
        public float OriginalSpeed;
    }
}