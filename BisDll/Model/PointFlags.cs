using System;

namespace BisDll.Model
{
	// Token: 0x02000009 RID: 9
	[Flags]
	public enum PointFlags : uint
	{
		// Token: 0x04000010 RID: 16
		NONE = 0u,
		// Token: 0x04000011 RID: 17
		ONLAND = 1u,
		// Token: 0x04000012 RID: 18
		UNDERLAND = 2u,
		// Token: 0x04000013 RID: 19
		ABOVELAND = 4u,
		// Token: 0x04000014 RID: 20
		KEEPLAND = 8u,
		// Token: 0x04000015 RID: 21
		LAND_MASK = 15u,
		// Token: 0x04000016 RID: 22
		DECAL = 256u,
		// Token: 0x04000017 RID: 23
		VDECAL = 512u,
		// Token: 0x04000018 RID: 24
		DECAL_MASK = 768u,
		// Token: 0x04000019 RID: 25
		NOLIGHT = 16u,
		// Token: 0x0400001A RID: 26
		AMBIENT = 32u,
		// Token: 0x0400001B RID: 27
		FULLLIGHT = 64u,
		// Token: 0x0400001C RID: 28
		HALFLIGHT = 128u,
		// Token: 0x0400001D RID: 29
		LIGHT_MASK = 240u,
		// Token: 0x0400001E RID: 30
		NOFOG = 4096u,
		// Token: 0x0400001F RID: 31
		SKYFOG = 8192u,
		// Token: 0x04000020 RID: 32
		FOG_MASK = 12288u,
		// Token: 0x04000021 RID: 33
		USER_MASK = 16711680u,
		// Token: 0x04000022 RID: 34
		USER_STEP = 65536u,
		// Token: 0x04000023 RID: 35
		SPECIAL_MASK = 251658240u,
		// Token: 0x04000024 RID: 36
		SPECIAL_HIDDEN = 16777216u,
		// Token: 0x04000025 RID: 37
		ALL_FLAGS = 268383231u
	}
}
