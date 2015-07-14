using System.Collections.Generic;
using Fairwood.Math;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TradePanel : MonoBehaviour
{
    public static TradePanel Instance { get; private set; }

    void Awake()
    {
        Instance = this;
        Setup();
        gameObject.SetActive(false);
    }

    public Town Town;
    public GameObject SlotTemplate;
    public List<GameObject> SlotList = new List<GameObject>();
    public List<int> CommodityIDList = new List<int>(); 
    public List<Text> CommodityNameLabelList = new List<Text>();
    public List<Text> AmountInTownLabelList = new List<Text>();
    public List<Text> AmountOnboardLabelList = new List<Text>();

    void Setup()
    {
        foreach (var commodityInfo in MainController.Instance.DataTableManager.CommodityTable.Values)
        {
            var id = commodityInfo.ID;
            var slot = PrefabHelper.InstantiateAndReset(SlotTemplate, SlotTemplate.transform.parent);
            SlotList.Add(slot);
            CommodityIDList.Add(id);
            CommodityNameLabelList.Add(slot.transform.FindChild("Text-Name").GetComponent<Text>());
            AmountInTownLabelList.Add(slot.transform.FindChild("Text-Amount In Town").GetComponent<Text>());
            AmountOnboardLabelList.Add(slot.transform.FindChild("Text-Amount Onboard").GetComponent<Text>());
        }
        Destroy(SlotTemplate);
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void SetAndRefresh(Town town)
    {
        Town = town;
        Refresh();
    }

    public void Refresh()
    {
        for (int i = 0; i < SlotList.Count; i++)
        {
            var id = CommodityIDList[i];
            var info = MainController.Instance.DataTableManager.CommodityTable[id];
            CommodityNameLabelList[i].text = info.Name;
            AmountInTownLabelList[i].text = Town.CommodityAmountTable[id].ToString();
            AmountOnboardLabelList[i].text = MainController.Instance.FocusedFleet.CommodityAmountTable[id].ToString();
        }
    }

    public void Buy(int id)
    {
        MainController.Instance.FocusedFleet.BuyCommodityFromTown(Town, id);
        Refresh();
    }

    public void Sell(int id)
    {
        MainController.Instance.FocusedFleet.SellCommodityToTown(Town, id);
        Refresh();
    }
    public void Haha(int id, int amount)
    {
        
    }
}