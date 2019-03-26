using System;
using BisDll.Stream;

namespace BisDll.Model.ODOL
{
	// Token: 0x0200002C RID: 44
	public class UVSet
	{
		// Token: 0x1700008C RID: 140
		// (get) Token: 0x06000160 RID: 352 RVA: 0x0000550C File Offset: 0x0000370C
		public float[] UVData
		{
			get
			{
				float[] array = new float[this.nVertices * 2u];
				float num = 0f;
				float num2 = 0f;
				double scale = 1.0;
				double scale2 = 1.0;
				if (this.isDiscretized)
				{
					scale = (double)(this.maxU - this.minU);
					scale2 = (double)(this.maxV - this.minV);
				}
				if (this.defaultFill)
				{
					if (this.isDiscretized)
					{
						num = this.scale(BitConverter.ToInt16(this.defaultValue, 0), scale, this.minU);
						num2 = this.scale(BitConverter.ToInt16(this.defaultValue, 2), scale2, this.minV);
					}
					else
					{
						num = BitConverter.ToSingle(this.defaultValue, 0);
						num2 = BitConverter.ToSingle(this.defaultValue, 4);
					}
				}
				int num3 = 0;
				while ((long)num3 < (long)((ulong)this.nVertices))
				{
					if (this.isDiscretized)
					{
						array[num3 * 2] = (this.defaultFill ? num : this.scale(BitConverter.ToInt16(this.uvData, num3 * 4), scale, this.minU));
						array[num3 * 2 + 1] = (this.defaultFill ? num2 : this.scale(BitConverter.ToInt16(this.uvData, num3 * 4 + 2), scale2, this.minV));
					}
					else
					{
						array[num3 * 2] = (this.defaultFill ? num : BitConverter.ToSingle(this.uvData, num3 * 8));
						array[num3 * 2 + 1] = (this.defaultFill ? num2 : BitConverter.ToSingle(this.uvData, num3 * 8 + 4));
					}
					num3++;
				}
				return array;
			}
		}

		// Token: 0x06000161 RID: 353 RVA: 0x0000569B File Offset: 0x0000389B
		private float scale(short value, double scale, float min)
		{
			return (float)(1.52587890625E-05 * (double)(value + short.MaxValue) * scale) + min;
		}

		// Token: 0x06000162 RID: 354 RVA: 0x000056B4 File Offset: 0x000038B4
		public void read(BinaryReaderEx input, uint odolVersion)
		{
			this.isDiscretized = false;
			if (odolVersion >= 45u)
			{
				this.isDiscretized = true;
				this.minU = input.ReadSingle();
				this.minV = input.ReadSingle();
				this.maxU = input.ReadSingle();
				this.maxV = input.ReadSingle();
			}
			this.nVertices = input.ReadUInt32();
			this.defaultFill = input.ReadBoolean();
			int num = (odolVersion >= 45u) ? 4 : 8;
			if (this.defaultFill)
			{
				this.defaultValue = input.ReadBytes(num);
				return;
			}
			this.uvData = input.ReadCompressed((uint)((ulong)this.nVertices * (ulong)((long)num)));
		}

		// Token: 0x04000188 RID: 392
		private bool isDiscretized;

		// Token: 0x04000189 RID: 393
		private float minU;

		// Token: 0x0400018A RID: 394
		private float minV;

		// Token: 0x0400018B RID: 395
		private float maxU;

		// Token: 0x0400018C RID: 396
		private float maxV;

		// Token: 0x0400018D RID: 397
		private uint nVertices;

		// Token: 0x0400018E RID: 398
		private bool defaultFill;

		// Token: 0x0400018F RID: 399
		private byte[] defaultValue;

		// Token: 0x04000190 RID: 400
		private byte[] uvData;
	}
}
