using System;
using BisDll.Stream;

namespace BisDll.Model.ODOL
{
	// Token: 0x0200001B RID: 27
	public class VertexNeighborInfo : IDeserializable
	{
		// Token: 0x17000072 RID: 114
		// (get) Token: 0x06000118 RID: 280 RVA: 0x00004D9F File Offset: 0x00002F9F
		// (set) Token: 0x06000119 RID: 281 RVA: 0x00004DA7 File Offset: 0x00002FA7
		public ushort PosA { get; private set; }

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x0600011A RID: 282 RVA: 0x00004DB0 File Offset: 0x00002FB0
		// (set) Token: 0x0600011B RID: 283 RVA: 0x00004DB8 File Offset: 0x00002FB8
		public AnimationRTWeight RtwA { get; private set; }

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x0600011C RID: 284 RVA: 0x00004DC1 File Offset: 0x00002FC1
		// (set) Token: 0x0600011D RID: 285 RVA: 0x00004DC9 File Offset: 0x00002FC9
		public ushort PosB { get; private set; }

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x0600011E RID: 286 RVA: 0x00004DD2 File Offset: 0x00002FD2
		// (set) Token: 0x0600011F RID: 287 RVA: 0x00004DDA File Offset: 0x00002FDA
		public AnimationRTWeight RtwB { get; private set; }

		// Token: 0x06000120 RID: 288 RVA: 0x00004DE4 File Offset: 0x00002FE4
		public void ReadObject(BinaryReaderEx input)
		{
			this.PosA = input.ReadUInt16();
			input.ReadBytes(2);
			this.RtwA = new AnimationRTWeight();
			this.RtwA.ReadObject(input);
			this.PosB = input.ReadUInt16();
			input.ReadBytes(2);
			this.RtwB = new AnimationRTWeight();
			this.RtwB.ReadObject(input);
		}
	}
}
