using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 延时方法管理器。放在某个永存单例物体上
/// </summary>
public class CoroutineManager : MonoBehaviour
{
    public delegate bool ConditionMethod();

    public delegate void ActionMethod();
    public class Coroutine
    {
        /// <summary>
        /// 创建时的Time.realTimeSinceStart
        /// </summary>
        public float CreateRealTime;
        /// <summary>
        /// 创建时的Time.time
        /// </summary>
        public float CreateTime;
        /// <summary>
        /// 创建时的Time.frameCount
        /// </summary>
        public int CreateFrame;
        /// <summary>
        /// 用于查找删除
        /// </summary>
        public string ID;
        /// <summary>
        /// 在何时执行Action，NULL则默认true。每帧都会执行。
        /// </summary>
        public ConditionMethod Condition;
        /// <summary>
        /// 在满足Condition时执行一次，然后就销毁Coroutine。
        /// </summary>
        public ActionMethod Action;

        public Coroutine()
        {
            CreateRealTime = Time.realtimeSinceStartup;
            CreateTime = Time.time;
            CreateFrame = Time.frameCount;
        }
        /// <summary>
        /// 最方便的延时执行某操作的方法
        /// </summary>
        /// <param name="delay"></param>
        /// <param name="action"></param>
        public Coroutine(float delay, ActionMethod action) : this()
        {
            Condition = () => Time.realtimeSinceStartup > CreateRealTime + delay;
            Action = action;
        }
        /// <summary>
        /// 最方便的延时执行某操作的方法
        /// </summary>
        /// <param name="id"></param>
        /// <param name="delay"></param>
        /// <param name="action"></param>
        public Coroutine(string id, float delay, ActionMethod action) : this()
        {
            ID = id;
            Condition = () => Time.realtimeSinceStartup > CreateRealTime + delay;
            Action = action;
        }

        /// <summary>
        /// condition CANNOT be null!
        /// </summary>
        /// <param name="id"></param>
        /// <param name="condition"></param>
        /// <param name="action"></param>
        public Coroutine(string id, ConditionMethod condition, ActionMethod action)
            : this()
        {
            ID = id;
            Condition = condition;
            Action = action;
        }
        /// <summary>
        /// condition CANNOT be null!
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="action"></param>
        public Coroutine(ConditionMethod condition, ActionMethod action)
            : this()
        {
            if (condition == null) throw new ArgumentNullException("condition");
            ID = null;
            Condition = condition;
            Action = action;
        }
    }

    public static readonly List<Coroutine> CoroutineList = new List<Coroutine>();

    void Update()
    {
        for (var i = 0; i < CoroutineList.Count;)
        {
            var coroutine = CoroutineList[i];
            if (coroutine.Condition == null || coroutine.Condition())
            {
                CoroutineList.RemoveAt(i);
                if (coroutine.Action != null) coroutine.Action();
            }
            else
            {
                i++;
            }
        }
    }

    public static void StartCoroutine(string id, ConditionMethod condition, ActionMethod action)
    {
        CoroutineList.Add(new Coroutine(id, condition, action));
    }
    public static void StartCoroutine(ConditionMethod condition, ActionMethod action)
    {
        CoroutineList.Add(new Coroutine(condition, action));
    }

    public static void StartCoroutine(Coroutine coroutine)
    {
        CoroutineList.Add(coroutine);
    }

    /// <summary>
    /// 以ID覆盖旧的，若无旧的就新增
    /// </summary>
    /// <param name="coroutine"></param>
    public static void StartCoroutineOverrideOld(Coroutine coroutine)
    {
        var index = CoroutineList.FindIndex(x => x.ID == coroutine.ID);
        if (index >= 0) CoroutineList[index] = coroutine;
        else CoroutineList.Add(coroutine);
    }

    public static void StartCoroutineOverrideOld(string id, ConditionMethod condition, ActionMethod action)
    {
        var index = CoroutineList.FindIndex(x => x.ID == id);
        if (index >= 0) CoroutineList[index] = new Coroutine(id, condition, action);
        else CoroutineList.Add(new Coroutine(id, condition, action));
    }

    public static void RemoveCoroutine(string id)
    {
        CoroutineList.RemoveAll(x => x.ID == id);
    }

    public static void RemoveCoroutines(Predicate<Coroutine> match)
    {
        CoroutineList.RemoveAll(match);
    }
}