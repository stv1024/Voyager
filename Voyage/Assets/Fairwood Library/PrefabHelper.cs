using System;
using System.Collections;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Fairwood.Math
{
    public static class PrefabHelper
    {
        /// <summary>
        /// 一键实例化
        /// </summary>
        /// <param name="prefab"></param>
        /// <param name="parent">null if has no parent</param>
        /// <returns>返回新建的物体</returns>
        public static GameObject InstantiateAndReset(GameObject prefab, Transform parent)
        {
            if (!prefab)
            {
                Debug.LogError("没有prefab, 这样很不好");
                return null;
            }
            var go = Object.Instantiate(prefab) as GameObject;
            go.name = prefab.name;
            go.transform.ResetAs(prefab.transform, parent);
            return go;
        }

        /// <summary>
        /// 一键实例化
        /// </summary>
        /// <typeparam name="T">返回哪个组件</typeparam>
        /// <param name="prefab"></param>
        /// <param name="parent"></param>
        /// <returns>返回新建物体上所指定的组件</returns>
        public static T InstantiateAndReset<T>(GameObject prefab, Transform parent) where T : Component
        {
            if (!prefab)
            {
                Debug.LogError("没有prefab, 这样很不好");
                return null;
            }
            var go = InstantiateAndReset(prefab, parent);
            return go.GetComponent<T>();
        }


        /// <summary>
        /// 一键实例化，随机的一个
        /// </summary>
        /// <param name="prefabs"></param>
        /// <param name="parent">null if has no parent</param>
        /// <returns>返回新建的物体</returns>
        public static GameObject InstantiateAndReset(GameObject[] prefabs, Transform parent)
        {
            if (prefabs == null || prefabs.Length == 0) return null;
            var prefab = prefabs[UnityEngine.Random.Range(0, prefabs.Length)];
            if (!prefab)
            {
                Debug.LogError("没有prefab, 这样很不好");
                return null;
            }
            var go = InstantiateAndReset(prefab, parent);
            return go;
        }

        /// <summary>
        /// 一键实例化，随机的一个
        /// </summary>
        /// <typeparam name="T">返回哪个组件</typeparam>
        /// <param name="prefabs"></param>
        /// <param name="parent"></param>
        /// <returns>返回新建物体上所指定的组件</returns>
        public static T InstantiateAndReset<T>(GameObject[] prefabs, Transform parent) where T : Component
        {
            if (prefabs == null || prefabs.Length == 0) return null;
            var prefab = prefabs[UnityEngine.Random.Range(0, prefabs.Length)];
            var go = InstantiateAndReset(prefab, parent);
            return go.GetComponent<T>();
        }

        /// <summary>
        /// 延迟激活失活一个物体，是个Coroutine
        /// </summary>
        /// <param name="gameObject"></param>
        /// <param name="active"></param>
        /// <param name="time">延迟多少秒</param>
        /// <returns></returns>
        public static IEnumerator SetActiveDelay(this GameObject gameObject, bool active, float time)
        {
            yield return new WaitForSeconds(time);
            gameObject.SetActive(active);
        }
    }
}