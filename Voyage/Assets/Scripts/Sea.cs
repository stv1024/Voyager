using Fairwood.Math;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 海面，用于点击
/// </summary>
public class Sea : MonoBehaviour, IPointerClickHandler
{
    public void OnSeaRightClick(Vector2 position)
    {
        Debug.Log("OSeaRigClick "+ position);
        var map = MainController.Instance.Map;
        var pos = map.MapPositionToLogicPosition(
            (map.transform.InverseTransformPoint(Camera.main.ScreenToWorldPoint(position))).ToVector2());
        MainController.Instance.SendFocusedFleetToPosition(pos);
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
            OnSeaRightClick(eventData.position);
        }
    }
}