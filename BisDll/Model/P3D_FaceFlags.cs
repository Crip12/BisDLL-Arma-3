using System;

namespace BisDll.Model
{
	// Token: 0x02000007 RID: 7
	public static class P3D_FaceFlags
	{
		// Token: 0x0600003C RID: 60 RVA: 0x000030D8 File Offset: 0x000012D8
		public static byte GetUserValue(this FaceFlags flags)
		{
			return (byte)(((long)flags & (long)((ulong)-33554432)) >> 24);
		}

		// Token: 0x0600003D RID: 61 RVA: 0x000030E7 File Offset: 0x000012E7
		public static void SetUserValue(this FaceFlags flags, byte value)
		{
			flags &= (FaceFlags)33554431;
			flags += (int)value << 24;
		}
	}
}
