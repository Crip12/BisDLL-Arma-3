using System;

namespace BisDll.Model
{
	// Token: 0x02000008 RID: 8
	[Flags]
	public enum FaceFlags
	{
		// Token: 0x04000005 RID: 5
		DEFAULT = 0,
		// Token: 0x04000006 RID: 6
		SHADOW_OFF = 16,
		// Token: 0x04000007 RID: 7
		MERGING_OFF = 16777216,
		// Token: 0x04000008 RID: 8
		ZBIAS_LOW = 256,
		// Token: 0x04000009 RID: 9
		ZBIAS_MID = 512,
		// Token: 0x0400000A RID: 10
		ZBIAS_HIGH = 768,
		// Token: 0x0400000B RID: 11
		LIGHTNING_BOTH = 32,
		// Token: 0x0400000C RID: 12
		LIGHTNING_POSITION = 128,
		// Token: 0x0400000D RID: 13
		LIGHTNING_FLAT = 2097152,
		// Token: 0x0400000E RID: 14
		LIGHTNING_REVERSED = 1048576
	}
}
