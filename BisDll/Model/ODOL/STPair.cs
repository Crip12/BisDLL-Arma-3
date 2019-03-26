using System;
using BisDll.Common.Math;

namespace BisDll.Model.ODOL
{
	// Token: 0x02000029 RID: 41
	public abstract class STPair
	{
		// Token: 0x1700008A RID: 138
		// (get) Token: 0x06000159 RID: 345 RVA: 0x000054A2 File Offset: 0x000036A2
		public Vector3P S { get; } = new Vector3P();

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x0600015A RID: 346 RVA: 0x000054AA File Offset: 0x000036AA
		public Vector3P T { get; } = new Vector3P();
	}
}
