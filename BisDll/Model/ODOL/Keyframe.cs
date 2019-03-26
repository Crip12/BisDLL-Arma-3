using System;
using BisDll.Common.Math;
using BisDll.Stream;

namespace BisDll.Model.ODOL
{
	// Token: 0x0200000F RID: 15
	public class Keyframe : IDeserializable
	{
		// Token: 0x06000055 RID: 85 RVA: 0x000035D4 File Offset: 0x000017D4
		public void ReadObject(BinaryReaderEx input)
		{
			this.time = input.ReadSingle();
			uint num = input.ReadUInt32();
			this.points = new Vector3P[num];
			int num2 = 0;
			while ((long)num2 < (long)((ulong)num))
			{
				this.points[num2] = new Vector3P(input);
				num2++;
			}
		}

		// Token: 0x04000068 RID: 104
		public float time;

		// Token: 0x04000069 RID: 105
		public Vector3P[] points;
	}
}
