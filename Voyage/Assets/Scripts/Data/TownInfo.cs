using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Scripts.Data
{
    public class TownInfo
    {
        public int ID;
        [NotNull] public string Name;
        public Vector2 Position;

        public List<int> OriginalProductList;
    }
}