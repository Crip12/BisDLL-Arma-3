using System;
using BisDll.Stream;

namespace BisDll.Model.MLOD
{
	// Token: 0x0200003B RID: 59
	public class SharpEdgesTagg : Tagg
	{
		// Token: 0x060001B4 RID: 436 RVA: 0x00006890 File Offset: 0x00004A90
		public void read(BinaryReaderEx input)
		{
			uint num = base.DataSize / 8u;
			this.pointIndices = new uint[(int)((IntPtr)((long)((ulong)num))), 2];
			int num2 = 0;
			while ((long)num2 < (long)((ulong)num))
			{
				this.pointIndices[num2, 0] = input.ReadUInt32();
				this.pointIndices[num2, 1] = input.ReadUInt32();
				num2++;
			}
		}

		// Token: 0x060001B5 RID: 437 RVA: 0x000068F4 File Offset: 0x00004AF4
		public void write(BinaryWriter output)
		{
			output.Write(true);
			output.writeAsciiz(base.Name);
			output.Write(base.DataSize);
			uint num = base.DataSize / 8u;
			int num2 = 0;
			while ((long)num2 < (long)((ulong)num))
			{
				output.Write(this.pointIndices[num2, 0]);
				output.Write(this.pointIndices[num2, 1]);
				num2++;
			}
		}

		// Token: 0x040001AF RID: 431
		public uint[,] pointIndices;
	}
}
