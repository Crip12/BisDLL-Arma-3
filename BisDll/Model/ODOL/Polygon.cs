using System;
using BisDll.Stream;

namespace BisDll.Model.ODOL
{
	// Token: 0x02000021 RID: 33
	public class Polygon : IDeserializable
	{
		// Token: 0x17000077 RID: 119
		// (get) Token: 0x06000127 RID: 295 RVA: 0x00004F29 File Offset: 0x00003129
		// (set) Token: 0x06000128 RID: 296 RVA: 0x00004F31 File Offset: 0x00003131
		public VertexIndex[] VertexIndices { get; private set; }

		// Token: 0x06000129 RID: 297 RVA: 0x00004F3C File Offset: 0x0000313C
		public void ReadObject(BinaryReaderEx input)
		{
			int version = input.Version;
			byte b = input.ReadByte();
			this.VertexIndices = new VertexIndex[(int)b];
			for (int i = 0; i < (int)b; i++)
			{
				this.VertexIndices[i] = input.ReadVertexIndex();
			}
		}
	}
}
