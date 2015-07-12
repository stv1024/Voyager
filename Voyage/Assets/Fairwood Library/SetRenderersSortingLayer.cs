using UnityEngine;

/// <summary>
/// 设置所有render的2D层次。
/// </summary>
public class SetRenderersSortingLayer : MonoBehaviour
{
	//public string SortingLayerName;		// The name of the sorting layer the particles should be set to.
    public int SortingLayerID;
    public int SortingOrder;

	void Start ()
    {
        var renderers = GetComponentsInChildren<Renderer>(true);
        foreach (var rdrr in renderers)
        {
            //rdrr.sortingLayerName = name;
            rdrr.sortingLayerID = SortingLayerID;
            rdrr.sortingOrder = SortingOrder;
        }
	}

    public bool RefreshNow = true;
    void Update()
    {
        if (RefreshNow)
        {
            Start();
            RefreshNow = false;
        }
    }
}