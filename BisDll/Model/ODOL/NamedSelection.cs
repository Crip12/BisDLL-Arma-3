using System;
using BisDll.Stream;

namespace BisDll.Model.ODOL
{
	// Token: 0x02000016 RID: 22
	public class NamedSelection : IDeserializable
	{
		// Token: 0x17000066 RID: 102
		// (get) Token: 0x060000FB RID: 251 RVA: 0x000048F2 File Offset: 0x00002AF2
		// (set) Token: 0x060000FC RID: 252 RVA: 0x000048FA File Offset: 0x00002AFA
		public string Name { get; private set; }

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x060000FD RID: 253 RVA: 0x00004903 File Offset: 0x00002B03
		// (set) Token: 0x060000FE RID: 254 RVA: 0x0000490B File Offset: 0x00002B0B
		public bool IsSectional { get; private set; }

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x060000FF RID: 255 RVA: 0x00004914 File Offset: 0x00002B14
		// (set) Token: 0x06000100 RID: 256 RVA: 0x0000491C File Offset: 0x00002B1C
		public VertexIndex[] SelectedFaces { get; private set; }

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x06000101 RID: 257 RVA: 0x00004925 File Offset: 0x00002B25
		// (set) Token: 0x06000102 RID: 258 RVA: 0x0000492D File Offset: 0x00002B2D
		public int[] Sections { get; private set; }

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x06000103 RID: 259 RVA: 0x00004936 File Offset: 0x00002B36
		// (set) Token: 0x06000104 RID: 260 RVA: 0x0000493E File Offset: 0x00002B3E
		public byte[] SelectedVerticesWeights { get; private set; }

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x06000105 RID: 261 RVA: 0x00004947 File Offset: 0x00002B47
		// (set) Token: 0x06000106 RID: 262 RVA: 0x0000494F File Offset: 0x00002B4F
		public VertexIndex[] SelectedVertices { get; private set; }

		// Token: 0x06000107 RID: 263 RVA: 0x00004958 File Offset: 0x00002B58
		public void ReadObject(BinaryReaderEx input)
		{
			this.Name = input.ReadAsciiz();
			this.SelectedFaces = input.ReadCompressedVertexIndexArray();
			input.ReadInt32();
			this.IsSectional = input.ReadBoolean();
			this.Sections = input.ReadCompressedIntArray();
			this.SelectedVertices = input.ReadCompressedVertexIndexArray();
			int expectedSize = input.ReadInt32();
			this.SelectedVerticesWeights = input.ReadCompressed((uint)expectedSize);
		}
	}
}
