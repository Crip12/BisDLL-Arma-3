using System;

namespace BisDll.Model.ODOL
{
	// Token: 0x0200001A RID: 26
	public class AnimationRTPair
	{
		// Token: 0x17000070 RID: 112
		// (get) Token: 0x06000115 RID: 277 RVA: 0x00004D79 File Offset: 0x00002F79
		public byte SelectionIndex { get; }

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x06000116 RID: 278 RVA: 0x00004D81 File Offset: 0x00002F81
		public byte Weight { get; }

		// Token: 0x06000117 RID: 279 RVA: 0x00004D89 File Offset: 0x00002F89
		public AnimationRTPair(byte sel, byte weight)
		{
			this.SelectionIndex = sel;
			this.Weight = weight;
		}
	}
}
