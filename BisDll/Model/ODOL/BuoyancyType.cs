using System;
using BisDll.Stream;

namespace BisDll.Model.ODOL
{
	// Token: 0x02000024 RID: 36
	public class BuoyancyType : IDeserializable
	{
		// Token: 0x1700007B RID: 123
		// (get) Token: 0x06000135 RID: 309 RVA: 0x00004FE8 File Offset: 0x000031E8
		// (set) Token: 0x06000136 RID: 310 RVA: 0x00004FF0 File Offset: 0x000031F0
		public float Volume { get; private set; }

		// Token: 0x06000137 RID: 311 RVA: 0x00004FF9 File Offset: 0x000031F9
		public void ReadObject(BinaryReaderEx input)
		{
			this.Volume = input.ReadSingle();
		}
	}
}
