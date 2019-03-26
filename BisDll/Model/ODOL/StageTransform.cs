using System;
using BisDll.Common.Math;
using BisDll.Stream;

namespace BisDll.Model.ODOL
{
	// Token: 0x02000012 RID: 18
	public class StageTransform
	{
		// Token: 0x06000074 RID: 116 RVA: 0x0000403F File Offset: 0x0000223F
		public StageTransform(BinaryReaderEx input)
		{
			this.uvSource = (StageTransform.UVSource)input.ReadUInt32();
			this.transformation = new Matrix4P(input);
		}

		// Token: 0x040000A3 RID: 163
		public StageTransform.UVSource uvSource;

		// Token: 0x040000A4 RID: 164
		public Matrix4P transformation;

		// Token: 0x0200005B RID: 91
		public enum UVSource
		{
			// Token: 0x040002CF RID: 719
			UVNone,
			// Token: 0x040002D0 RID: 720
			UVTex,
			// Token: 0x040002D1 RID: 721
			UVTexWaterAnim,
			// Token: 0x040002D2 RID: 722
			UVPos,
			// Token: 0x040002D3 RID: 723
			UVNorm,
			// Token: 0x040002D4 RID: 724
			UVTex1,
			// Token: 0x040002D5 RID: 725
			UVWorldPos,
			// Token: 0x040002D6 RID: 726
			UVWorldNorm,
			// Token: 0x040002D7 RID: 727
			UVTexShoreAnim,
			// Token: 0x040002D8 RID: 728
			NUVSource
		}
	}
}
