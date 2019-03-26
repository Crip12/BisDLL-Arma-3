using System;
using BisDll.Stream;

namespace BisDll.Model.ODOL
{
	// Token: 0x02000018 RID: 24
	public abstract class VerySmallArray : IDeserializable
	{
		// Token: 0x06000111 RID: 273 RVA: 0x00004D0C File Offset: 0x00002F0C
		public void ReadObject(BinaryReaderEx input)
		{
			this.nSmall = input.ReadInt32();
			this.smallSpace = input.ReadBytes(8);
		}

		// Token: 0x04000124 RID: 292
		protected int nSmall;

		// Token: 0x04000125 RID: 293
		protected byte[] smallSpace;
	}
}
