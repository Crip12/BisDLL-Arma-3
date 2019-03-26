using System;
using BisDll.Common.Math;
using BisDll.Stream;

namespace BisDll.Model.ODOL
{
	// Token: 0x02000023 RID: 35
	public class BuoyantPoint : IDeserializable
	{
		// Token: 0x17000078 RID: 120
		// (get) Token: 0x0600012D RID: 301 RVA: 0x00004F8F File Offset: 0x0000318F
		// (set) Token: 0x0600012E RID: 302 RVA: 0x00004F97 File Offset: 0x00003197
		public Vector3P Coords { get; private set; }

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x0600012F RID: 303 RVA: 0x00004FA0 File Offset: 0x000031A0
		// (set) Token: 0x06000130 RID: 304 RVA: 0x00004FA8 File Offset: 0x000031A8
		public float SphereRadius { get; private set; }

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x06000131 RID: 305 RVA: 0x00004FB1 File Offset: 0x000031B1
		// (set) Token: 0x06000132 RID: 306 RVA: 0x00004FB9 File Offset: 0x000031B9
		public float TypicalSurface { get; private set; }

		// Token: 0x06000133 RID: 307 RVA: 0x00004FC2 File Offset: 0x000031C2
		public void ReadObject(BinaryReaderEx input)
		{
			this.Coords = new Vector3P(input);
			this.SphereRadius = input.ReadSingle();
			this.TypicalSurface = input.ReadSingle();
		}
	}
}
