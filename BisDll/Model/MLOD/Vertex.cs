using System;
using BisDll.Stream;

namespace BisDll.Model.MLOD
{
	// Token: 0x02000033 RID: 51
	public class Vertex
	{
		// Token: 0x17000099 RID: 153
		// (get) Token: 0x06000191 RID: 401 RVA: 0x00006387 File Offset: 0x00004587
		// (set) Token: 0x06000192 RID: 402 RVA: 0x0000638F File Offset: 0x0000458F
		public int PointIndex { get; private set; }

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x06000193 RID: 403 RVA: 0x00006398 File Offset: 0x00004598
		// (set) Token: 0x06000194 RID: 404 RVA: 0x000063A0 File Offset: 0x000045A0
		public int NormalIndex { get; private set; }

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x06000195 RID: 405 RVA: 0x000063A9 File Offset: 0x000045A9
		// (set) Token: 0x06000196 RID: 406 RVA: 0x000063B1 File Offset: 0x000045B1
		public float U { get; private set; }

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x06000197 RID: 407 RVA: 0x000063BA File Offset: 0x000045BA
		// (set) Token: 0x06000198 RID: 408 RVA: 0x000063C2 File Offset: 0x000045C2
		public float V { get; private set; }

		// Token: 0x06000199 RID: 409 RVA: 0x000063CB File Offset: 0x000045CB
		public Vertex(BinaryReaderEx input)
		{
			this.read(input);
		}

		// Token: 0x0600019A RID: 410 RVA: 0x000063DA File Offset: 0x000045DA
		public Vertex(int point, int normal, float u, float v)
		{
			this.PointIndex = point;
			this.NormalIndex = normal;
			this.U = u;
			this.V = v;
		}

		// Token: 0x0600019B RID: 411 RVA: 0x000063FF File Offset: 0x000045FF
		public void read(BinaryReaderEx input)
		{
			this.PointIndex = input.ReadInt32();
			this.NormalIndex = input.ReadInt32();
			this.U = input.ReadSingle();
			this.V = input.ReadSingle();
		}

		// Token: 0x0600019C RID: 412 RVA: 0x00006431 File Offset: 0x00004631
		public void write(BinaryWriter output)
		{
			output.Write(this.PointIndex);
			output.Write(this.NormalIndex);
			output.Write(this.U);
			output.Write(this.V);
		}
	}
}
