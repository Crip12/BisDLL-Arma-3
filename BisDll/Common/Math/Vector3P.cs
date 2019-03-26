using System;
using System.Globalization;
using BisDll.Stream;

namespace BisDll.Common.Math
{
	// Token: 0x02000044 RID: 68
	public class Vector3P : IDeserializable
	{
		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x060001FD RID: 509 RVA: 0x0000824E File Offset: 0x0000644E
		// (set) Token: 0x060001FE RID: 510 RVA: 0x00008258 File Offset: 0x00006458
		public float X
		{
			get
			{
				return this.xyz[0];
			}
			set
			{
				this.xyz[0] = value;
			}
		}

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x060001FF RID: 511 RVA: 0x00008263 File Offset: 0x00006463
		// (set) Token: 0x06000200 RID: 512 RVA: 0x0000826D File Offset: 0x0000646D
		public float Y
		{
			get
			{
				return this.xyz[1];
			}
			set
			{
				this.xyz[1] = value;
			}
		}

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x06000201 RID: 513 RVA: 0x00008278 File Offset: 0x00006478
		// (set) Token: 0x06000202 RID: 514 RVA: 0x00008282 File Offset: 0x00006482
		public float Z
		{
			get
			{
				return this.xyz[2];
			}
			set
			{
				this.xyz[2] = value;
			}
		}

		// Token: 0x06000203 RID: 515 RVA: 0x0000828D File Offset: 0x0000648D
		public Vector3P() : this(0f)
		{
		}

		// Token: 0x06000204 RID: 516 RVA: 0x0000829A File Offset: 0x0000649A
		public Vector3P(float val) : this(val, val, val)
		{
		}

		// Token: 0x06000205 RID: 517 RVA: 0x000082A5 File Offset: 0x000064A5
		public Vector3P(BinaryReaderEx input) : this(input.ReadSingle(), input.ReadSingle(), input.ReadSingle())
		{
		}

		// Token: 0x06000206 RID: 518 RVA: 0x000082BF File Offset: 0x000064BF
		public Vector3P(float x, float y, float z)
		{
			this.xyz = new float[]
			{
				x,
				y,
				z
			};
		}

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x06000207 RID: 519 RVA: 0x000082DF File Offset: 0x000064DF
		public double Length
		{
			get
			{
				return Math.Sqrt((double)(this.X * this.X + this.Y * this.Y + this.Z * this.Z));
			}
		}

		// Token: 0x170000B9 RID: 185
		public float this[int i]
		{
			get
			{
				return this.xyz[i];
			}
			set
			{
				this.xyz[i] = value;
			}
		}

		// Token: 0x0600020A RID: 522 RVA: 0x00008325 File Offset: 0x00006525
		public static Vector3P operator -(Vector3P a)
		{
			return new Vector3P(-a.X, -a.Y, -a.Z);
		}

		// Token: 0x0600020B RID: 523 RVA: 0x00008344 File Offset: 0x00006544
		public void readCompressed(BinaryReaderEx input)
		{
			int num = input.ReadInt32();
			int num2 = num & 1023;
			int num3 = num >> 10 & 1023;
			int num4 = num >> 20 & 1023;
			if (num2 > 511)
			{
				num2 -= 1024;
			}
			if (num3 > 511)
			{
				num3 -= 1024;
			}
			if (num4 > 511)
			{
				num4 -= 1024;
			}
			this.X = (float)((double)num2 * -0.0019569471624266144);
			this.Y = (float)((double)num3 * -0.0019569471624266144);
			this.Z = (float)((double)num4 * -0.0019569471624266144);
		}

		// Token: 0x0600020C RID: 524 RVA: 0x000083DD File Offset: 0x000065DD
		public void write(BinaryWriter output)
		{
			output.Write(this.X);
			output.Write(this.Y);
			output.Write(this.Z);
		}

		// Token: 0x0600020D RID: 525 RVA: 0x00008403 File Offset: 0x00006603
		public static Vector3P operator *(Vector3P a, float b)
		{
			return new Vector3P(a.X * b, a.Y * b, a.Z * b);
		}

		// Token: 0x0600020E RID: 526 RVA: 0x00008422 File Offset: 0x00006622
		public static float operator *(Vector3P a, Vector3P b)
		{
			return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
		}

		// Token: 0x0600020F RID: 527 RVA: 0x0000844D File Offset: 0x0000664D
		public static Vector3P operator +(Vector3P a, Vector3P b)
		{
			return new Vector3P(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
		}

		// Token: 0x06000210 RID: 528 RVA: 0x0000847B File Offset: 0x0000667B
		public static Vector3P operator -(Vector3P a, Vector3P b)
		{
			return new Vector3P(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
		}

		// Token: 0x06000211 RID: 529 RVA: 0x000084AC File Offset: 0x000066AC
		public override bool Equals(object obj)
		{
			Vector3P vector3P = obj as Vector3P;
			return vector3P != null && base.Equals(obj) && this.Equals(vector3P);
		}

		// Token: 0x06000212 RID: 530 RVA: 0x000084D8 File Offset: 0x000066D8
		public bool Equals(Vector3P other)
		{
			Func<float, float, bool> func = (float f1, float f2) => (double)Math.Abs(f1 - f2) < 0.05;
			return func(this.X, other.X) && func(this.Y, other.Y) && func(this.Z, other.Z);
		}

		// Token: 0x06000213 RID: 531 RVA: 0x00008544 File Offset: 0x00006744
		public override string ToString()
		{
			CultureInfo cultureInfo = new CultureInfo("en-GB");
			return string.Concat(new string[]
			{
				"{",
				this.X.ToString(cultureInfo.NumberFormat),
				",",
				this.Y.ToString(cultureInfo.NumberFormat),
				",",
				this.Z.ToString(cultureInfo.NumberFormat),
				"}"
			});
		}

		// Token: 0x06000214 RID: 532 RVA: 0x000085CC File Offset: 0x000067CC
		public void ReadObject(BinaryReaderEx input)
		{
			this.xyz[0] = input.ReadSingle();
			this.xyz[1] = input.ReadSingle();
			this.xyz[2] = input.ReadSingle();
		}

		// Token: 0x06000215 RID: 533 RVA: 0x000085F8 File Offset: 0x000067F8
		public float Distance(Vector3P v)
		{
			Vector3P vector3P = this - v;
			return (float)Math.Sqrt((double)(vector3P.X * vector3P.X + vector3P.Y * vector3P.Y + vector3P.Z * vector3P.Z));
		}

		// Token: 0x06000216 RID: 534 RVA: 0x00008640 File Offset: 0x00006840
		public void Normalize()
		{
			float num = (float)this.Length;
			this.X /= num;
			this.Y /= num;
			this.Z /= num;
		}

		// Token: 0x040001BF RID: 447
		private float[] xyz;
	}
}
