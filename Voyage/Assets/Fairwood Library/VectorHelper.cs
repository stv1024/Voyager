using UnityEngine;

namespace Fairwood.Math
{
    public class VectorHelper
    {
        public static Vector3 V2ToV3(Vector2 v2)
        {
            return V2ToV3(v2, 0);
        }

        public static Vector3 V2ToV3(Vector2 v2, float z)
        {
            return new Vector3(v2.x, v2.y, z);
        }

        //	public static Vector3 V2ToV3(Vector2 v2)
        //	{
        //		return new Vector3(v2.x, v2.y, 0);
        //	}

        public static Vector2 V3ToV2(Vector3 v3)
        {
            return new Vector2(v3.x, v3.y);
        }

        public static Vector3 SetV3X(Vector3 v3, float x)
        {
            return new Vector3(x, v3.y, v3.z);
        }

        public static Vector3 SetV3Y(Vector3 v3, float y)
        {
            return new Vector3(v3.x, y, v3.z);
        }

        public static Vector3 SetV3Z(Vector3 v3, float z)
        {
            return new Vector3(v3.x, v3.y, z);
        }

        public static Color SetAlpha(Color clr, float a)
        {
            return new Color(clr.r, clr.g, clr.b, a);
        }
    }

    public struct IntVector2
    {
        public bool Equals(IntVector2 other)
        {
            return i == other.i && j == other.j;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is IntVector2 && Equals((IntVector2) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (i*397) ^ j;
            }
        }

        public int i, j;

        public IntVector2(int i, int j)
        {
            this.i = i;
            this.j = j;
        }

        public static readonly IntVector2 zero = new IntVector2(0, 0);
        public static readonly IntVector2 up = new IntVector2(0, 1);
        public static readonly IntVector2 right = new IntVector2(1, 0);

        public static bool operator ==(IntVector2 a, IntVector2 b)
        {
            return a.i == b.i && a.j == b.j;
        }

        public static bool operator !=(IntVector2 a, IntVector2 b)
        {
            return !(a == b);
        }

        public static IntVector2 operator -(IntVector2 a)
        {
            return new IntVector2(-a.i, -a.j);
        }

        public static IntVector2 operator +(IntVector2 a, IntVector2 b)
        {
            return new IntVector2(a.i + b.i, a.j + b.j);
        }
        public static IntVector2 operator -(IntVector2 a, IntVector2 b)
        {
            return a + -b;
        }
        public static IntVector2 operator /(IntVector2 a, int b)
        {
            return new IntVector2(a.i/b, a.j/b);
        }

        public override string ToString()
        {
            return new System.Text.StringBuilder().Append('(').Append(i).Append(',').Append(j).Append(')').ToString();
        }

        public static implicit operator Vector2(IntVector2 a)
        {
            return new Vector2(a.i, a.j);
        }
    }

    public struct IntVector3
    {
        public int i, j, k;

        public IntVector3(int i, int j, int k)
        {
            this.i = i;
            this.j = j;
            this.k = k;
        }

        public static implicit operator Vector3(IntVector3 a)
        {
            return new Vector3(a.i, a.j, a.k);
        }
    }
}