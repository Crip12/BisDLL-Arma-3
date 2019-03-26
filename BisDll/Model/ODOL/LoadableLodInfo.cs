using System;
using BisDll.Stream;

namespace BisDll.Model.ODOL
{
	// Token: 0x0200001C RID: 28
	public class LoadableLodInfo : IDeserializable
	{
		// Token: 0x06000122 RID: 290 RVA: 0x00004E48 File Offset: 0x00003048
		public void ReadObject(BinaryReaderEx input)
		{
			this.nFaces = input.ReadInt32();
			this.color = input.ReadUInt32();
			this.special = input.ReadInt32();
			this.orHints = input.ReadUInt32();
			int version = input.Version;
			if (version >= 39)
			{
				this.hasSkeleton = input.ReadBoolean();
			}
			if (version >= 51)
			{
				this.nVertices = input.ReadInt32();
				this.faceArea = input.ReadSingle();
			}
		}

		// Token: 0x0400012C RID: 300
		private int nFaces;

		// Token: 0x0400012D RID: 301
		private uint color;

		// Token: 0x0400012E RID: 302
		private int special;

		// Token: 0x0400012F RID: 303
		private uint orHints;

		// Token: 0x04000130 RID: 304
		private bool hasSkeleton;

		// Token: 0x04000131 RID: 305
		private int nVertices;

		// Token: 0x04000132 RID: 306
		private float faceArea;
	}
}
