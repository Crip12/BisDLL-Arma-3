using System;
using BisDll.Stream;

namespace BisDll.Model.ODOL
{
	// Token: 0x02000022 RID: 34
	public class SubSkeletonIndexSet : IDeserializable
	{
		// Token: 0x0600012B RID: 299 RVA: 0x00004F81 File Offset: 0x00003181
		public void ReadObject(BinaryReaderEx input)
		{
			this.subSkeletons = input.ReadIntArray();
		}

		// Token: 0x04000162 RID: 354
		private int[] subSkeletons;
	}
}
