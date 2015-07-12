using Fairwood.Math;
using UnityEngine;

namespace Fairwood
{
    public static class TransformHelper
    {
        public static void ResetTransform(this Transform tra)
        {
            tra.localPosition = Vector3.zero;
            tra.localRotation = Quaternion.identity;
            tra.localScale = Vector3.one;
        }

        public static void ResetTransform(this Transform tra, Transform parent)
        {
            tra.parent = parent;
            tra.localPosition = Vector3.zero;
            tra.localRotation = Quaternion.identity;
            tra.localScale = Vector3.one;
        }

        /// <summary>
        /// 使用target的parent
        /// </summary>
        /// <param name="tra"></param>
        /// <param name="target"></param>
        public static void ResetAs(this Transform tra, Transform target)
        {
            tra.ResetAs(target, target.parent);
        }

        /// <summary>
        /// 使用指定的parent
        /// </summary>
        /// <param name="tra"></param>
        /// <param name="target"></param>
        /// <param name="parent"></param>
        public static void ResetAs(this Transform tra, Transform target, Transform parent)
        {
            tra.SetParent(parent);
            var srcRectTra = tra as RectTransform;
            var tarRectTra = target as RectTransform;
            if (srcRectTra && tarRectTra)
            {
                srcRectTra.anchoredPosition = tarRectTra.anchoredPosition;
                srcRectTra.anchorMax = tarRectTra.anchorMax;
                srcRectTra.anchorMin = tarRectTra.anchorMin;
                srcRectTra.offsetMax = tarRectTra.offsetMax;
                srcRectTra.offsetMin = tarRectTra.offsetMin;
                srcRectTra.pivot = tarRectTra.pivot;
                srcRectTra.sizeDelta = tarRectTra.sizeDelta;
            }
            else
            {
                tra.localPosition = target.localPosition;
                tra.localRotation = target.localRotation;
                tra.localScale = target.localScale;
            }
        }

        public static void SetLayer(Transform tra, int layer)
        {
            tra.gameObject.layer = layer;
            for (int i = 0, imax = tra.childCount; i < imax; i++)
            {
                SetLayer(tra.GetChild(i), layer);
            }
        }

        public static Transform FindChildRecursively(this Transform tra, string name)
        {
            Transform first = null;
            foreach (Transform sub in tra)
            {
                var cur = sub.FindChildRecursively(name);
                if (!cur) continue;
                first = cur;
                break;
            }
            return tra.name == name ? tra : first;
        }

        public static void SetSortingLayer(this Transform tra, string name)
        {
            var renderers = tra.GetComponentsInChildren<Renderer>(true);
            foreach (var renderer in renderers)
            {
                renderer.sortingLayerName = name;
            }
        }

        /// <summary>
        /// 用Transform把两点连接起来。
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="startPoint"></param>
        /// <param name="endPoint"></param>
        /// <param name="width">物体的宽度，必须大于0</param>
        public static void JoinTwoPoint(this Transform transform, Vector3 startPoint, Vector3 endPoint, float width = 1)
        {
            if (!transform) return;
            if (width <= 0) return;
            transform.localPosition = startPoint;
            var vector = endPoint - startPoint;
            transform.right = vector;
            transform.localScale = transform.localScale.SetV3X(vector.magnitude / width);
        }
    }
}