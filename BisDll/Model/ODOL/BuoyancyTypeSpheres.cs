using System;
using BisDll.Stream;

namespace BisDll.Model.ODOL
{
	// Token: 0x02000025 RID: 37
	public class BuoyancyTypeSpheres : BuoyancyType, IDeserializable
	{
		// Token: 0x1700007C RID: 124
		// (get) Token: 0x06000139 RID: 313 RVA: 0x00005007 File Offset: 0x00003207
		// (set) Token: 0x0600013A RID: 314 RVA: 0x0000500F File Offset: 0x0000320F
		public int ArraySizeX { get; private set; }

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x0600013B RID: 315 RVA: 0x00005018 File Offset: 0x00003218
		// (set) Token: 0x0600013C RID: 316 RVA: 0x00005020 File Offset: 0x00003220
		public int ArraySizeY { get; private set; }

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x0600013D RID: 317 RVA: 0x00005029 File Offset: 0x00003229
		// (set) Token: 0x0600013E RID: 318 RVA: 0x00005031 File Offset: 0x00003231
		public int ArraySizeZ { get; private set; }

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x0600013F RID: 319 RVA: 0x0000503A File Offset: 0x0000323A
		// (set) Token: 0x06000140 RID: 320 RVA: 0x00005042 File Offset: 0x00003242
		public float StepX { get; private set; }

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x06000141 RID: 321 RVA: 0x0000504B File Offset: 0x0000324B
		// (set) Token: 0x06000142 RID: 322 RVA: 0x00005053 File Offset: 0x00003253
		public float StepY { get; private set; }

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x06000143 RID: 323 RVA: 0x0000505C File Offset: 0x0000325C
		// (set) Token: 0x06000144 RID: 324 RVA: 0x00005064 File Offset: 0x00003264
		public float StepZ { get; private set; }

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x06000145 RID: 325 RVA: 0x0000506D File Offset: 0x0000326D
		// (set) Token: 0x06000146 RID: 326 RVA: 0x00005075 File Offset: 0x00003275
		public float FullSphereRadius { get; private set; }

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x06000147 RID: 327 RVA: 0x0000507E File Offset: 0x0000327E
		// (set) Token: 0x06000148 RID: 328 RVA: 0x00005086 File Offset: 0x00003286
		public int MinSpheres { get; private set; }

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x06000149 RID: 329 RVA: 0x0000508F File Offset: 0x0000328F
		// (set) Token: 0x0600014A RID: 330 RVA: 0x00005097 File Offset: 0x00003297
		public int MaxSpheres { get; private set; }

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x0600014B RID: 331 RVA: 0x000050A0 File Offset: 0x000032A0
		// (set) Token: 0x0600014C RID: 332 RVA: 0x000050A8 File Offset: 0x000032A8
		public BuoyantPoint[] BuoyancyPoints { get; private set; }

		// Token: 0x0600014D RID: 333 RVA: 0x000050B4 File Offset: 0x000032B4
		public new void ReadObject(BinaryReaderEx input)
		{
			this.ArraySizeX = input.ReadInt32();
			this.ArraySizeY = input.ReadInt32();
			this.ArraySizeZ = input.ReadInt32();
			this.StepX = input.ReadSingle();
			this.StepY = input.ReadSingle();
			this.StepZ = input.ReadSingle();
			this.FullSphereRadius = input.ReadSingle();
			this.MinSpheres = input.ReadInt32();
			this.MaxSpheres = input.ReadInt32();
			int num = this.ArraySizeX * this.ArraySizeY * this.ArraySizeZ;
			this.BuoyancyPoints = new BuoyantPoint[num];
			for (int i = 0; i < num; i++)
			{
				this.BuoyancyPoints[i] = new BuoyantPoint();
				this.BuoyancyPoints[i].ReadObject(input);
			}
			base.ReadObject(input);
		}
	}
}
