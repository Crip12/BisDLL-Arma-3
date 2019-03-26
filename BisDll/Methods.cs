using System;
using System.Collections.Generic;
using System.Linq;

namespace BisDll
{
	// Token: 0x02000002 RID: 2
	public static class Methods
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public static void Swap<T>(ref T v1, ref T v2)
		{
			T t = v1;
			v1 = v2;
			v2 = t;
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002077 File Offset: 0x00000277
		public static bool EqualsFloat(float f1, float f2, float tolerance = 0.0001f)
		{
			return Math.Abs(f1 - f2) <= tolerance;
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002087 File Offset: 0x00000287
		public static IEnumerable<T> Yield<T>(this T src)
		{
			yield return src;
			yield break;
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002097 File Offset: 0x00000297
		public static IEnumerable<T> Yield<T>(params T[] elems)
		{
			return elems;
		}

		// Token: 0x06000005 RID: 5 RVA: 0x0000209A File Offset: 0x0000029A
		public static string CharsToString(this IEnumerable<char> chars)
		{
			return new string(chars.ToArray<char>());
		}
	}
}
