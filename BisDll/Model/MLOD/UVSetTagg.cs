using System;
using BisDll.Stream;

namespace BisDll.Model.MLOD
{
	// Token: 0x0200003C RID: 60
	public class UVSetTagg : Tagg
	{
		// Token: 0x060001B7 RID: 439 RVA: 0x00006960 File Offset: 0x00004B60
		public void read(BinaryReaderEx input, Face[] faces)
		{
			this.uvSetNr = input.ReadUInt32();
			this.faceUVs = new float[faces.Length][,];
			for (int i = 0; i < faces.Length; i++)
			{
				this.faceUVs[i] = new float[faces[i].NumberOfVertices, 2];
				for (int j = 0; j < faces[i].NumberOfVertices; j++)
				{
					this.faceUVs[i][j, 0] = input.ReadSingle();
					this.faceUVs[i][j, 1] = input.ReadSingle();
				}
			}
		}

		// Token: 0x060001B8 RID: 440 RVA: 0x000069E8 File Offset: 0x00004BE8
		public void write(BinaryWriter output)
		{
			output.Write(true);
			output.writeAsciiz(base.Name);
			output.Write(base.DataSize);
			output.Write(this.uvSetNr);
			for (int i = 0; i < this.faceUVs.Length; i++)
			{
				for (int j = 0; j < this.faceUVs[i].Length / 2; j++)
				{
					output.Write(this.faceUVs[i][j, 0]);
					output.Write(this.faceUVs[i][j, 1]);
				}
			}
		}

		// Token: 0x040001B0 RID: 432
		public uint uvSetNr;

		// Token: 0x040001B1 RID: 433
		public float[][,] faceUVs;
	}
}
