using System;
using BisDll.Stream;

namespace BisDll.Common.Math
{
	// Token: 0x02000045 RID: 69
	public class Vector3PCompressed : IDeserializable
	{
		// Token: 0x170000BA RID: 186
		// (get) Token: 0x06000217 RID: 535 RVA: 0x00008680 File Offset: 0x00006880
		public float X
		{
			get
			{
				int num = this.value & 1023;
				if (num > 511)
				{
					num -= 1024;
				}
				return (float)num * -0.00195694715f;
			}
		}

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x06000218 RID: 536 RVA: 0x000086B4 File Offset: 0x000068B4
		public float Y
		{
			get
			{
				int num = this.value >> 10 & 1023;
				if (num > 511)
				{
					num -= 1024;
				}
				return (float)num * -0.00195694715f;
			}
		}

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x06000219 RID: 537 RVA: 0x000086EC File Offset: 0x000068EC
		public float Z
		{
			get
			{
				int num = this.value >> 20 & 1023;
				if (num > 511)
				{
					num -= 1024;
				}
				return (float)num * -0.00195694715f;
			}
		}

		// Token: 0x0600021A RID: 538 RVA: 0x00008724 File Offset: 0x00006924
		public static implicit operator Vector3P(Vector3PCompressed src)
		{
			int num = src.value & 1023;
			int num2 = src.value >> 10 & 1023;
			int num3 = src.value >> 20 & 1023;
			if (num > 511)
			{
				num -= 1024;
			}
			if (num2 > 511)
			{
				num2 -= 1024;
			}
			if (num3 > 511)
			{
				num3 -= 1024;
			}
			return new Vector3P((float)num * -0.00195694715f, (float)num2 * -0.00195694715f, (float)num3 * -0.00195694715f);
		}

		// Token: 0x0600021B RID: 539 RVA: 0x000087AB File Offset: 0x000069AB
		public static implicit operator int(Vector3PCompressed src)
		{
			return src.value;
		}

		// Token: 0x0600021C RID: 540 RVA: 0x000087B3 File Offset: 0x000069B3
		public static implicit operator Vector3PCompressed(int src)
		{
			return new Vector3PCompressed
			{
				value = src
			};
		}

		// Token: 0x0600021D RID: 541 RVA: 0x000087C1 File Offset: 0x000069C1
		public void ReadObject(BinaryReaderEx input)
		{
			this.value = input.ReadInt32();
		}

		// Token: 0x040001C0 RID: 448
		private int value;

		// Token: 0x040001C1 RID: 449
		private const float scaleFactor = -0.00195694715f;
	}
}
