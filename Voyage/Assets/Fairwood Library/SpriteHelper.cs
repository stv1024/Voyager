using UnityEngine;

namespace Fairwood
{
    public static class SpriteHelper
    {
        public static void JoinTwoPoint(this SpriteRenderer spriteRenderer, Vector3 startPoint,
                                        Vector3 endPoint)
        {
            if (!spriteRenderer || !spriteRenderer.sprite) return;
            var width = spriteRenderer.sprite.textureRect.width;
            var transform = spriteRenderer.transform;
            transform.JoinTwoPoint(startPoint, endPoint, width);
        }
    }
}