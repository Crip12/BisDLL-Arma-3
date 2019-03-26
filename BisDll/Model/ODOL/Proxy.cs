using System;
using BisDll.Common.Math;
using BisDll.Stream;

namespace BisDll.Model.ODOL
{
	// Token: 0x02000026 RID: 38
	public class Proxy : IDeserializable
	{
		// Token: 0x0600014F RID: 335 RVA: 0x00005184 File Offset: 0x00003384
		public void ReadObject(BinaryReaderEx input)
		{
			this.proxyModel = input.ReadAsciiz();
			this.transformation = new Matrix4P(input);
			this.sequenceID = input.ReadInt32();
			this.namedSelectionIndex = input.ReadInt32();
			this.boneIndex = input.ReadInt32();
			if (input.Version >= 40)
			{
				this.sectionIndex = input.ReadInt32();
			}
		}

		// Token: 0x04000171 RID: 369
		public string proxyModel;

		// Token: 0x04000172 RID: 370
		public Matrix4P transformation;

		// Token: 0x04000173 RID: 371
		public int sequenceID;

		// Token: 0x04000174 RID: 372
		public int namedSelectionIndex;

		// Token: 0x04000175 RID: 373
		public int boneIndex;

		// Token: 0x04000176 RID: 374
		public int sectionIndex;
	}
}
