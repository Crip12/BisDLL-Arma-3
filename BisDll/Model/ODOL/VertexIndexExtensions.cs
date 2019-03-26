using System;
using BisDll.Stream;

namespace BisDll.Model.ODOL
{
	// Token: 0x0200002E RID: 46
	public static class VertexIndexExtensions
	{
		// Token: 0x06000167 RID: 359 RVA: 0x00005796 File Offset: 0x00003996
		public static VertexIndex ReadVertexIndex(this BinaryReaderEx input)
		{
			if (input.Version >= 69)
			{
				return input.ReadInt32();
			}
			return input.ReadUInt16();
		}

		// Token: 0x06000168 RID: 360 RVA: 0x000057BC File Offset: 0x000039BC
		public static VertexIndex[] ReadCompressedVertexIndexArray(this BinaryReaderEx input)
		{
			if (input.Version >= 69)
			{
				return input.ReadCompressedArray<VertexIndex>((BinaryReaderEx i) => i.ReadInt32(), 4);
			}
			return input.ReadCompressedArray<VertexIndex>((BinaryReaderEx i) => i.ReadUInt16(), 2);
		}
	}
}
