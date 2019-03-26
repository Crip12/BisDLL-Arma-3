using System;
using BisDll.Stream;

namespace BisDll.Model.MLOD
{
	// Token: 0x0200002F RID: 47
	public class Face
	{
		// Token: 0x1700008D RID: 141
		// (get) Token: 0x06000169 RID: 361 RVA: 0x00005820 File Offset: 0x00003A20
		// (set) Token: 0x0600016A RID: 362 RVA: 0x00005828 File Offset: 0x00003A28
		public int NumberOfVertices { get; private set; }

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x0600016B RID: 363 RVA: 0x00005831 File Offset: 0x00003A31
		// (set) Token: 0x0600016C RID: 364 RVA: 0x00005839 File Offset: 0x00003A39
		public Vertex[] Vertices { get; private set; }

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x0600016D RID: 365 RVA: 0x00005842 File Offset: 0x00003A42
		// (set) Token: 0x0600016E RID: 366 RVA: 0x0000584A File Offset: 0x00003A4A
		public FaceFlags Flags { get; private set; }

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x0600016F RID: 367 RVA: 0x00005853 File Offset: 0x00003A53
		// (set) Token: 0x06000170 RID: 368 RVA: 0x0000585B File Offset: 0x00003A5B
		public string Texture { get; private set; }

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x06000171 RID: 369 RVA: 0x00005864 File Offset: 0x00003A64
		// (set) Token: 0x06000172 RID: 370 RVA: 0x0000586C File Offset: 0x00003A6C
		public string Material { get; private set; }

		// Token: 0x06000173 RID: 371 RVA: 0x00005875 File Offset: 0x00003A75
		public Face(int nVerts, Vertex[] verts, FaceFlags flags, string texture, string material)
		{
			this.NumberOfVertices = nVerts;
			this.Vertices = verts;
			this.Flags = flags;
			this.Texture = texture;
			this.Material = material;
		}

		// Token: 0x06000174 RID: 372 RVA: 0x000058A2 File Offset: 0x00003AA2
		public Face(BinaryReaderEx input)
		{
			this.read(input);
		}

		// Token: 0x06000175 RID: 373 RVA: 0x000058B4 File Offset: 0x00003AB4
		public void read(BinaryReaderEx input)
		{
			this.NumberOfVertices = input.ReadInt32();
			this.Vertices = new Vertex[4];
			for (int i = 0; i < 4; i++)
			{
				this.Vertices[i] = new Vertex(input);
			}
			this.Flags = (FaceFlags)input.ReadInt32();
			this.Texture = input.ReadAsciiz();
			this.Material = input.ReadAsciiz();
		}

		// Token: 0x06000176 RID: 374 RVA: 0x00005918 File Offset: 0x00003B18
		public void write(BinaryWriter output)
		{
			output.Write(this.NumberOfVertices);
			for (int i = 0; i < 4; i++)
			{
				if (i < this.Vertices.Length && this.Vertices[i] != null)
				{
					this.Vertices[i].write(output);
				}
				else
				{
					output.Write(0);
					output.Write(0);
					output.Write(0);
					output.Write(0);
				}
			}
			output.Write((int)this.Flags);
			output.writeAsciiz(this.Texture);
			output.writeAsciiz(this.Material);
		}
	}
}
