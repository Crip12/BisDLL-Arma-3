using System;

namespace BisDll.Model.MLOD
{
	// Token: 0x02000034 RID: 52
	public abstract class Tagg
	{
		// Token: 0x1700009D RID: 157
		// (get) Token: 0x0600019D RID: 413 RVA: 0x00006463 File Offset: 0x00004663
		// (set) Token: 0x0600019E RID: 414 RVA: 0x0000646B File Offset: 0x0000466B
		public uint DataSize { get; set; }

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x0600019F RID: 415 RVA: 0x00006474 File Offset: 0x00004674
		// (set) Token: 0x060001A0 RID: 416 RVA: 0x0000647C File Offset: 0x0000467C
		public string Name { get; set; }
	}
}
