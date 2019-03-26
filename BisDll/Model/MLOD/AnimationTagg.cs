using System;
using BisDll.Common.Math;
using BisDll.Stream;

namespace BisDll.Model.MLOD
{
	// Token: 0x02000035 RID: 53
	public class AnimationTagg : Tagg
	{
		// Token: 0x060001A2 RID: 418 RVA: 0x00006488 File Offset: 0x00004688
		public void read(BinaryReaderEx input)
		{
			uint num = (base.DataSize - 4u) / 12u;
			this.frameTime = input.ReadSingle();
			this.framePoints = new Vector3P[num];
			int num2 = 0;
			while ((long)num2 < (long)((ulong)num))
			{
				this.framePoints[num2] = new Vector3P(input);
				num2++;
			}
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x000064D8 File Offset: 0x000046D8
		public void write(BinaryWriter output)
		{
			output.Write(true);
			output.writeAsciiz(base.Name);
			output.Write(base.DataSize);
			output.Write(this.frameTime);
			for (int i = 0; i < this.framePoints.Length; i++)
			{
				this.framePoints[i].write(output);
			}
		}

		// Token: 0x040001A4 RID: 420
		public float frameTime;

		// Token: 0x040001A5 RID: 421
		public Vector3P[] framePoints;
	}
}
