using UnityEngine;

public class TradePanel : MonoBehaviour
{
    public static TradePanel Instance { get; private set; }

    public Town Town;

    void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Buy(int id)
    {
        MainController.Instance.FocusedFleet.BuyCommodityFromTown(Town, id);
    }

    public void Sell(int id)
    {
        MainController.Instance.FocusedFleet.SellCommodityToTown(Town, id);
    }
    public void Haha(int id, int amount)
    {
        
    }
}