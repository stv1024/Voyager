using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Scripts.Data
{
    public class CommodityInfo
    {
        public int ID;
        [NotNull]
        public string Name;
        /// <summary>
        /// 价值
        /// </summary>
        public double Value;

        public double ConsumePerPopulationPerMinute;
    }
}