using System;
using BisDll.Stream;

namespace BisDll.Model.MLOD
{
	// Token: 0x02000039 RID: 57
	public class PropertyTagg : Tagg
	{
		// Token: 0x060001AE RID: 430 RVA: 0x00006766 File Offset: 0x00004966
		public void read(BinaryReaderEx input)
		{
			this.name = input.ReadAscii(64);
			this.value = input.ReadAscii(64);
		}

		// Token: 0x060001AF RID: 431 RVA: 0x00006784 File Offset: 0x00004984
		public void write(BinaryWriter output)
		{
			output.Write(true);
			output.writeAsciiz(base.Name);
			output.Write(base.DataSize);
			output.writeAscii(this.name, 64u);
			output.writeAscii(this.value, 64u);
		}

		// Token: 0x040001AB RID: 427
		public string name;

		// Token: 0x040001AC RID: 428
		public string value;
	}
}
