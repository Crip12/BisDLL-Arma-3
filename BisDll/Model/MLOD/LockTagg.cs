using System;
using BisDll.Stream;

namespace BisDll.Model.MLOD
{
	// Token: 0x02000036 RID: 54
	public class LockTagg : Tagg
	{
		// Token: 0x060001A5 RID: 421 RVA: 0x0000653C File Offset: 0x0000473C
		public void read(BinaryReaderEx input, int nPoints, int nFaces)
		{
			this.lockedPoints = new bool[nPoints];
			for (int i = 0; i < nPoints; i++)
			{
				this.lockedPoints[i] = input.ReadBoolean();
			}
			this.lockedFaces = new bool[nFaces];
			for (int j = 0; j < nFaces; j++)
			{
				this.lockedFaces[j] = input.ReadBoolean();
			}
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x00006598 File Offset: 0x00004798
		public void write(BinaryWriter output)
		{
			output.Write(true);
			output.writeAsciiz(base.Name);
			output.Write(base.DataSize);
			for (int i = 0; i < this.lockedPoints.Length; i++)
			{
				output.Write(this.lockedPoints[i]);
			}
			for (int j = 0; j < this.lockedFaces.Length; j++)
			{
				output.Write(this.lockedFaces[j]);
			}
		}

		// Token: 0x040001A6 RID: 422
		public bool[] lockedPoints;

		// Token: 0x040001A7 RID: 423
		public bool[] lockedFaces;
	}
}
