using System.Collections.Generic;
using Assets.Scripts.Data;
using UnityEngine;
using System.Collections;

/// <summary>
/// 逻辑层城镇
/// </summary>
public class Town : Entity
{
    public TownInfo Info;
    public int ID { get { return Info.ID; } }
    public string Name { get { return Info.Name; } }

    public readonly Dictionary<int, double> CommodityAmountTable = new Dictionary<int, double>();

    public readonly Dictionary<int, double> CommodityPriceTable = new Dictionary<int, double>();

    public readonly Dictionary<int, double> ProductivityTable = new Dictionary<int, double>();

    public TownButton InMapButton;

    public long Population;

    public float SettleRemaining;

    public void LoadSave(SavesStructure.Town townSave)
    {
        Population = townSave.Population;
        foreach (var kv in townSave.CommodityAmountTable)
        {
            if (CommodityAmountTable.ContainsKey(kv.Key))
            {
                CommodityAmountTable[kv.Key] = kv.Value;
            }
            else
            {
                CommodityAmountTable.Add(kv.Key, kv.Value);
            }
        }
    }

    public void Reset()
    {
        foreach (var commodityInfo in MainController.Instance.DataTableManager.CommodityTable.Values)
        {
            var id = commodityInfo.ID;
            if (!CommodityAmountTable.ContainsKey(id))
            {
                CommodityAmountTable.Add(id, 0);
            }
            if (!CommodityPriceTable.ContainsKey(id))
            {
                CommodityPriceTable.Add(id, 0);
            }
            if (!ProductivityTable.ContainsKey(id))
            {
                ProductivityTable.Add(id, 0);
            }
        }
        RebuildCommodityPrice();
        RebuildProductivity();
        SettleRemaining = 0;
    }

    public override void Update(float dt)
    {
        SettleRemaining -= dt;
        if (SettleRemaining <= 0)
        {
            SettleRemaining += Parameters.TownSettleIntervalSeconds;
            //商品消耗
            foreach (var commodityInfo in MainController.Instance.DataTableManager.CommodityTable.Values)
            {
                var id = commodityInfo.ID;
                CommodityAmountTable[id] -= Population*commodityInfo.ConsumePerPopulationPerMinute*dt/60;
                if (CommodityAmountTable[id] < 0)
                {
                    CommodityAmountTable[id] = 0;
                }
            }
            //商品生产
            foreach (var kv in ProductivityTable)
            {
                var id = kv.Key;
                CommodityAmountTable[id] += kv.Value * dt;
            }

            //商品价格浮动
            RebuildCommodityPrice();


            //人口变化

            //RebuildProductivity(); 人口没变化则产量也不会变化
        }

    }

    public void RebuildCommodityPrice()
    {
        foreach (var kv in MainController.Instance.DataTableManager.CommodityTable)
        {
            var id = kv.Key;
            var value = kv.Value.Value;
            var amount = CommodityAmountTable[id];
            var consumePerMinute = kv.Value.ConsumePerPopulationPerMinute*Population + 0.000001d;
            var price = Parameters.CalcPriceFromValue(value, amount, consumePerMinute);
            CommodityPriceTable[id] = price;
        }
    }
    public void RebuildProductivity()
    {
        foreach (var kv in MainController.Instance.DataTableManager.CommodityTable)
        {
            var id = kv.Key;
            ProductivityTable[id] = 0;
        }
        foreach (var productInfo in Info.OriginalProductList)
        {
            ProductivityTable[productInfo.ID] += productInfo.ProductivityPerPopulationPerMinute * Population/60;
        }
    }

    public void OnInMapButtonClick()
    {
    }

    public void OnFleetBuyCommodity(int id)
    {
        if (CommodityAmountTable[id] >= 1)
        {
            CommodityAmountTable[id] -= 1;
            RebuildCommodityPrice();
        }
    }
    public void OnFleetSellCommodity(int id)
    {
        CommodityAmountTable[id] += 1;
        RebuildCommodityPrice();
    }

    public override string ToString()
    {
        return string.Format("[{0}]{1}", ID, Name);
    }

}
