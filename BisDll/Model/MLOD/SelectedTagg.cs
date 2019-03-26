using System;
using BisDll.Stream;

namespace BisDll.Model.MLOD
{
	// Token: 0x0200003A RID: 58
	public class SelectedTagg : Tagg
	{
		// Token: 0x060001B1 RID: 433 RVA: 0x000067C4 File Offset: 0x000049C4
		public void read(BinaryReaderEx input, int nPoints, int nFaces)
		{
			this.weightedPoints = new byte[nPoints];
			for (int i = 0; i < nPoints; i++)
			{
				this.weightedPoints[i] = input.ReadByte();
			}
			this.faces = new byte[nFaces];
			for (int j = 0; j < nFaces; j++)
			{
				this.faces[j] = input.ReadByte();
			}
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x00006820 File Offset: 0x00004A20
		public void write(BinaryWriter output)
		{
			output.Write(true);
			output.writeAsciiz(base.Name);
			output.Write(base.DataSize);
			for (int i = 0; i < this.weightedPoints.Length; i++)
			{
				output.Write(this.weightedPoints[i]);
			}
			for (int j = 0; j < this.faces.Length; j++)
			{
				output.Write(this.faces[j]);
			}
		}

		// Token: 0x040001AD RID: 429
		public byte[] weightedPoints;

		// Token: 0x040001AE RID: 430
		public byte[] faces;
	}
}
