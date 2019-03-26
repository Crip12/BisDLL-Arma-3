using System;
using BisDll.Stream;

namespace BisDll.Model.ODOL
{
	// Token: 0x02000020 RID: 32
	public class Polygons
	{
		// Token: 0x17000076 RID: 118
		// (get) Token: 0x06000124 RID: 292 RVA: 0x00004EB8 File Offset: 0x000030B8
		// (set) Token: 0x06000125 RID: 293 RVA: 0x00004EC0 File Offset: 0x000030C0
		public Polygon[] Faces { get; private set; }

		// Token: 0x06000126 RID: 294 RVA: 0x00004ECC File Offset: 0x000030CC
		public Polygons(BinaryReaderEx input)
		{
			uint num = input.ReadUInt32();
			input.ReadUInt32();
			input.ReadUInt16();
			this.Faces = new Polygon[num];
			int num2 = 0;
			while ((long)num2 < (long)((ulong)num))
			{
				this.Faces[num2] = new Polygon();
				this.Faces[num2].ReadObject(input);
				num2++;
			}
		}
	}
}
