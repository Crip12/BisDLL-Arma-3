using System;
using BisDll.Stream;

namespace BisDll.Model.MLOD
{
	// Token: 0x02000037 RID: 55
	public class MassTagg : Tagg
	{
		// Token: 0x060001A8 RID: 424 RVA: 0x00006608 File Offset: 0x00004808
		public void read(BinaryReaderEx input)
		{
			uint num = base.DataSize / 4u;
			this.mass = new float[num];
			int num2 = 0;
			while ((long)num2 < (long)((ulong)num))
			{
				this.mass[num2] = input.ReadSingle();
				num2++;
			}
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x00006648 File Offset: 0x00004848
		public void write(BinaryWriter output)
		{
			output.Write(true);
			output.writeAsciiz(base.Name);
			output.Write(base.DataSize);
			uint num = base.DataSize / 4u;
			int num2 = 0;
			while ((long)num2 < (long)((ulong)num))
			{
				output.Write(this.mass[num2]);
				num2++;
			}
		}

		// Token: 0x040001A8 RID: 424
		public float[] mass;
	}
}
