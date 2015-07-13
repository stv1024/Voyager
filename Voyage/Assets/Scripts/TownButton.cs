using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// 城镇按钮
/// </summary>
public class TownButton : MonoBehaviour, IPointerClickHandler
{
    public Town Model;
    public Text NameLabel;

    /// <summary>
    /// 先设置Model
    /// </summary>
    public void Setup()
    {
        Reset();
    }

    public void Reset()
    {
        NameLabel.text = Model.Name;
    }


    public void OnTownLeftClick()
    {
        if (null != Model)
        {
            TradePanel.Instance.Show();
            TradePanel.Instance.Town = Model;
        }
    }
    public void OnTownRightClick()
    {
        if (null != Model)
        {
            MainController.Instance.SendFocusedFleetToTown(Model);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            
        }
        else if (eventData.button == PointerEventData.InputButton.Middle)
        {
            
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnTownRightClick();
        }
    }
}