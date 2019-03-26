using System;
using BisDll.Stream;

namespace BisDll.Model.MLOD
{
	// Token: 0x02000038 RID: 56
	public class NamedSelectionTagg : Tagg
	{
		// Token: 0x060001AB RID: 427 RVA: 0x0000669C File Offset: 0x0000489C
		public void read(BinaryReaderEx input, int nPoints, int nFaces)
		{
			this.points = new byte[nPoints];
			for (int i = 0; i < nPoints; i++)
			{
				this.points[i] = input.ReadByte();
			}
			this.faces = new byte[nFaces];
			for (int j = 0; j < nFaces; j++)
			{
				this.faces[j] = input.ReadByte();
			}
		}

		// Token: 0x060001AC RID: 428 RVA: 0x000066F8 File Offset: 0x000048F8
		public void write(BinaryWriter output)
		{
			output.Write(true);
			output.writeAsciiz(base.Name);
			output.Write(base.DataSize);
			for (int i = 0; i < this.points.Length; i++)
			{
				output.Write(this.points[i]);
			}
			for (int j = 0; j < this.faces.Length; j++)
			{
				output.Write(this.faces[j]);
			}
		}

		// Token: 0x040001A9 RID: 425
		public byte[] points;

		// Token: 0x040001AA RID: 426
		public byte[] faces;
	}
}
