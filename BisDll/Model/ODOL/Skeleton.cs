using System;
using BisDll.Stream;

namespace BisDll.Model.ODOL
{
	// Token: 0x02000028 RID: 40
	public class Skeleton
	{
		// Token: 0x17000086 RID: 134
		// (get) Token: 0x06000154 RID: 340 RVA: 0x000053E1 File Offset: 0x000035E1
		public string Name { get; }

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x06000155 RID: 341 RVA: 0x000053E9 File Offset: 0x000035E9
		public bool isDiscrete { get; }

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x06000156 RID: 342 RVA: 0x000053F1 File Offset: 0x000035F1
		public string[] bones { get; }

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x06000157 RID: 343 RVA: 0x000053F9 File Offset: 0x000035F9
		public string pivotsNameObsolete { get; }

		// Token: 0x06000158 RID: 344 RVA: 0x00005404 File Offset: 0x00003604
		public Skeleton(BinaryReaderEx input)
		{
			int version = input.Version;
			this.Name = input.ReadAsciiz();
			if (this.Name == "")
			{
				return;
			}
			if (version >= 23)
			{
				this.isDiscrete = input.ReadBoolean();
			}
			int num = input.ReadInt32();
			this.bones = new string[num * 2];
			for (int i = 0; i < num; i++)
			{
				this.bones[i * 2] = input.ReadAsciiz();
				this.bones[i * 2 + 1] = input.ReadAsciiz();
			}
			if (version > 40)
			{
				this.pivotsNameObsolete = input.ReadAsciiz();
			}
		}
	}
}
