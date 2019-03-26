using System;

namespace BisDll.Model.ODOL
{
	// Token: 0x0200001F RID: 31
	public enum ClipFlags
	{
		// Token: 0x0400013E RID: 318
		ClipNone,
		// Token: 0x0400013F RID: 319
		ClipFront,
		// Token: 0x04000140 RID: 320
		ClipBack,
		// Token: 0x04000141 RID: 321
		ClipLeft = 4,
		// Token: 0x04000142 RID: 322
		ClipRight = 8,
		// Token: 0x04000143 RID: 323
		ClipBottom = 16,
		// Token: 0x04000144 RID: 324
		ClipTop = 32,
		// Token: 0x04000145 RID: 325
		ClipUser0 = 64,
		// Token: 0x04000146 RID: 326
		ClipAll = 63,
		// Token: 0x04000147 RID: 327
		ClipLandMask = 3840,
		// Token: 0x04000148 RID: 328
		ClipLandStep = 256,
		// Token: 0x04000149 RID: 329
		ClipLandNone = 0,
		// Token: 0x0400014A RID: 330
		ClipLandOn = 256,
		// Token: 0x0400014B RID: 331
		ClipLandUnder = 512,
		// Token: 0x0400014C RID: 332
		ClipLandAbove = 1024,
		// Token: 0x0400014D RID: 333
		ClipLandKeep = 2048,
		// Token: 0x0400014E RID: 334
		ClipDecalMask = 12288,
		// Token: 0x0400014F RID: 335
		ClipDecalStep = 4096,
		// Token: 0x04000150 RID: 336
		ClipDecalNone = 0,
		// Token: 0x04000151 RID: 337
		ClipDecalNormal = 4096,
		// Token: 0x04000152 RID: 338
		ClipDecalVertical = 8192,
		// Token: 0x04000153 RID: 339
		ClipFogMask = 49152,
		// Token: 0x04000154 RID: 340
		ClipFogStep = 16384,
		// Token: 0x04000155 RID: 341
		ClipFogNormal = 0,
		// Token: 0x04000156 RID: 342
		ClipFogDisable = 16384,
		// Token: 0x04000157 RID: 343
		ClipFogSky = 32768,
		// Token: 0x04000158 RID: 344
		ClipLightMask = 983040,
		// Token: 0x04000159 RID: 345
		ClipLightStep = 65536,
		// Token: 0x0400015A RID: 346
		ClipLightNormal = 0,
		// Token: 0x0400015B RID: 347
		ClipLightLine = 524288,
		// Token: 0x0400015C RID: 348
		ClipUserMask = 267386880,
		// Token: 0x0400015D RID: 349
		ClipUserStep = 1048576,
		// Token: 0x0400015E RID: 350
		MaxUserValue = 255,
		// Token: 0x0400015F RID: 351
		ClipHints = 268435200
	}
}
