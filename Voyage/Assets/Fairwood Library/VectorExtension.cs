using UnityEngine;

namespace Fairwood.Math {
	/// <summary>
	/// Vector functions. 各种向量、Color的常用操作方法
	/// </summary>
	public static class VectorExtension
	{
		public static Vector3 GetXModV3(Vector3 v3, float x)
		{
			return new Vector3(x, v3.y, v3.z);
		}
		public static Vector3 GetYModV3(Vector3 v3, float y)
		{
			return new Vector3(v3.x, y, v3.z);
		}
		public static Vector3 GetZModV3(Vector3 v3, float z)
		{
			return new Vector3(v3.x, v3.y, z);
		}
		public static Color GetAModClr(Color clr, float a)
		{
			return new Color(clr.r, clr.g, clr.b, a);
		}
		public static Vector3 GetCpntModV3(Vector3 v3, int ind, float c)
		{
			v3[ind] = c;
			return v3;
		}
		public static Color GetCpntModClr(Color clr, int ind, float c)
		{
			clr[ind] = c;
			return clr;
		}
		
		public static Vector3 GetXAddV3(Vector3 v3, float deltaX)
		{
			return new Vector3(v3.x + deltaX, v3.y, v3.z);
		}
		public static Vector3 GetYAddV3(Vector3 v3, float deltaY)
		{
			return new Vector3(v3.x, v3.y + deltaY, v3.z);
		}
		public static Vector3 GetZAddV3(Vector3 v3, float deltaZ)
		{
			return new Vector3(v3.x, v3.y, v3.z + deltaZ);
		}
        public static Vector3 SetV3X(this Vector3 v3, float x)
		{
			return new Vector3(x, v3.y, v3.z);
		}
        public static Vector3 SetV3Y(this Vector3 v3, float y)
		{
            return new Vector3(v3.x, y, v3.z);
		}
        public static Vector3 SetV3Z(this Vector3 v3, float z)
		{
            return new Vector3(v3.x, v3.y, z);
		}
        public static Color SetAlpha(this Color clr, float a)
		{
            return new Color(clr.r, clr.g, clr.b, a);
		}
        public static Vector3 SetV3Cpnt(this Vector3 v3, int ind, float c)
		{
			var tmpV3 = v3;
			tmpV3[ind] = c;
			return tmpV3;
		}

        public static Vector3 AddV3X(this Vector3 v3, float deltaX)
		{
            return new Vector3(v3.x + deltaX, v3.y, v3.z);
		}
        public static Vector3 AddV3Y(this Vector3 v3, float deltaY)
		{
            return new Vector3(v3.x, v3.y + deltaY, v3.z);
		}
        public static Vector3 AddV3Z(this Vector3 v3, float deltaZ)
		{
            return new Vector3(v3.x, v3.y, v3.z + deltaZ);
		}
        public static Color AddAlpha(this Color clr, float deltaA)
		{
            return new Color(clr.r, clr.g, clr.b, clr.a + deltaA);
		}
        public static Vector3 AddV3Cpnt(this Vector3 v3, int ind, float deltaC)
		{
			Vector3 tmpV3 = v3;
			tmpV3[ind] = tmpV3[ind] + deltaC;
            return tmpV3;
		}

        public static Vector2 ToVector2(this Vector3 me)
        {
            return new Vector2(me.x, me.y);
        }
        public static Vector3 ToVector3(this Vector2 me, float z = 0)
        {
            return new Vector3(me.x, me.y, z);
        }

        public static Vector2 SetV2X(this Vector2 v2, float x)
        {
            return new Vector2(x, v2.y);
        }
	}
}