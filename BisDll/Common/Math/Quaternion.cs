using System;

namespace BisDll.Common.Math
{
	// Token: 0x02000043 RID: 67
	public class Quaternion
	{
		// Token: 0x170000AF RID: 175
		// (get) Token: 0x060001F0 RID: 496 RVA: 0x00007DEE File Offset: 0x00005FEE
		public float X
		{
			get
			{
				return this.x;
			}
		}

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x060001F1 RID: 497 RVA: 0x00007DEE File Offset: 0x00005FEE
		public float Y
		{
			get
			{
				return this.x;
			}
		}

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x060001F2 RID: 498 RVA: 0x00007DEE File Offset: 0x00005FEE
		public float Z
		{
			get
			{
				return this.x;
			}
		}

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x060001F3 RID: 499 RVA: 0x00007DEE File Offset: 0x00005FEE
		public float W
		{
			get
			{
				return this.x;
			}
		}

		// Token: 0x060001F4 RID: 500 RVA: 0x00007DF8 File Offset: 0x00005FF8
		public static Quaternion readCompressed(byte[] data)
		{
			float num = (float)((double)(-(double)BitConverter.ToInt16(data, 0)) / 16384.0);
			float num2 = (float)((double)BitConverter.ToInt16(data, 2) / 16384.0);
			float num3 = (float)((double)(-(double)BitConverter.ToInt16(data, 4)) / 16384.0);
			float num4 = (float)((double)BitConverter.ToInt16(data, 6) / 16384.0);
			return new Quaternion(num, num2, num3, num4);
		}

		// Token: 0x060001F5 RID: 501 RVA: 0x00007E5E File Offset: 0x0000605E
		public Quaternion()
		{
			this.w = 1f;
			this.x = 0f;
			this.y = 0f;
			this.z = 0f;
		}

		// Token: 0x060001F6 RID: 502 RVA: 0x00007E92 File Offset: 0x00006092
		public Quaternion(float x, float y, float z, float w)
		{
			this.w = w;
			this.x = x;
			this.y = y;
			this.z = z;
		}

		// Token: 0x060001F7 RID: 503 RVA: 0x00007EB8 File Offset: 0x000060B8
		public static Quaternion operator *(Quaternion a, Quaternion b)
		{
			float num = a.w * b.w - a.x * b.x - a.y * b.y - a.z * b.z;
			float num2 = a.w * b.x + a.x * b.w + a.y * b.z - a.z * b.y;
			float num3 = a.w * b.y - a.x * b.z + a.y * b.w + a.z * b.x;
			float num4 = a.w * b.z + a.x * b.y - a.y * b.x + a.z * b.w;
			return new Quaternion(num2, num3, num4, num);
		}

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x060001F8 RID: 504 RVA: 0x00007FAC File Offset: 0x000061AC
		public Quaternion Inverse
		{
			get
			{
				this.normalize();
				return this.Conjugate;
			}
		}

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x060001F9 RID: 505 RVA: 0x00007FBA File Offset: 0x000061BA
		public Quaternion Conjugate
		{
			get
			{
				return new Quaternion(-this.x, -this.y, -this.z, this.w);
			}
		}

		// Token: 0x060001FA RID: 506 RVA: 0x00007FDC File Offset: 0x000061DC
		public void normalize()
		{
			float num = (float)(1.0 / Math.Sqrt((double)(this.x * this.x + this.y * this.y + this.z * this.z + this.w * this.w)));
			this.x *= num;
			this.y *= num;
			this.z *= num;
			this.w *= num;
		}

		// Token: 0x060001FB RID: 507 RVA: 0x0000806C File Offset: 0x0000626C
		public Vector3P transform(Vector3P xyz)
		{
			Quaternion b = new Quaternion(xyz.X, xyz.Y, xyz.Z, 0f);
			Quaternion quaternion = this * b * this.Inverse;
			return new Vector3P(quaternion.x, quaternion.y, quaternion.z);
		}

		// Token: 0x060001FC RID: 508 RVA: 0x000080C0 File Offset: 0x000062C0
		public float[,] asRotationMatrix()
		{
			float[,] array = new float[3, 3];
			double num = (double)(this.x * this.y);
			double num2 = (double)(this.w * this.z);
			double num3 = (double)(this.w * this.x);
			double num4 = (double)(this.w * this.y);
			double num5 = (double)(this.x * this.z);
			double num6 = (double)(this.y * this.z);
			double num7 = (double)(this.z * this.z);
			double num8 = (double)(this.y * this.y);
			double num9 = (double)(this.x * this.x);
			array[0, 0] = (float)(1.0 - 2.0 * (num8 + num7));
			array[0, 1] = (float)(2.0 * (num - num2));
			array[0, 2] = (float)(2.0 * (num5 + num4));
			array[1, 0] = (float)(2.0 * (num + num2));
			array[1, 1] = (float)(1.0 - 2.0 * (num9 + num7));
			array[1, 2] = (float)(2.0 * (num6 - num3));
			array[2, 0] = (float)(2.0 * (num5 - num4));
			array[2, 1] = (float)(2.0 * (num6 + num3));
			array[2, 2] = (float)(1.0 - 2.0 * (num9 + num8));
			return array;
		}

		// Token: 0x040001BB RID: 443
		private float x;

		// Token: 0x040001BC RID: 444
		private float y;

		// Token: 0x040001BD RID: 445
		private float z;

		// Token: 0x040001BE RID: 446
		private float w;
	}
}
