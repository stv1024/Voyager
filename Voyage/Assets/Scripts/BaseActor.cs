using UnityEngine;

/// <summary>
/// 表现层基类
/// </summary>
public class BaseActor : MonoBehaviour
{
    public float LastUpdateRealTime;

    protected virtual void Update()
    {
        LastUpdateRealTime = Time.realtimeSinceStartup;
    }
}