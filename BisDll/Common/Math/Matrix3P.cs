using System;
using BisDll.Stream;

namespace BisDll.Common.Math
{
	// Token: 0x02000041 RID: 65
	public class Matrix3P
	{
		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x060001D8 RID: 472 RVA: 0x0000775E File Offset: 0x0000595E
		public Vector3P Aside
		{
			get
			{
				return this.columns[0];
			}
		}

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x060001D9 RID: 473 RVA: 0x00007768 File Offset: 0x00005968
		public Vector3P Up
		{
			get
			{
				return this.columns[1];
			}
		}

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x060001DA RID: 474 RVA: 0x00007772 File Offset: 0x00005972
		public Vector3P Dir
		{
			get
			{
				return this.columns[2];
			}
		}

		// Token: 0x170000AA RID: 170
		public Vector3P this[int col]
		{
			get
			{
				return this.columns[col];
			}
		}

		// Token: 0x170000AB RID: 171
		public float this[int row, int col]
		{
			get
			{
				return this[col][row];
			}
			set
			{
				this[col][row] = value;
			}
		}

		// Token: 0x060001DE RID: 478 RVA: 0x000077A5 File Offset: 0x000059A5
		public Matrix3P() : this(0f)
		{
		}

		// Token: 0x060001DF RID: 479 RVA: 0x000077B2 File Offset: 0x000059B2
		public Matrix3P(float val) : this(new Vector3P(val), new Vector3P(val), new Vector3P(val))
		{
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x000077CC File Offset: 0x000059CC
		public Matrix3P(BinaryReaderEx input) : this(new Vector3P(input), new Vector3P(input), new Vector3P(input))
		{
		}

		// Token: 0x060001E1 RID: 481 RVA: 0x000077E6 File Offset: 0x000059E6
		private Matrix3P(Vector3P aside, Vector3P up, Vector3P dir)
		{
			this.columns = new Vector3P[]
			{
				aside,
				up,
				dir
			};
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x00007806 File Offset: 0x00005A06
		public static Matrix3P operator -(Matrix3P a)
		{
			return new Matrix3P(-a.Aside, -a.Up, -a.Dir);
		}

		// Token: 0x060001E3 RID: 483 RVA: 0x00007830 File Offset: 0x00005A30
		public static Matrix3P operator *(Matrix3P a, Matrix3P b)
		{
			Matrix3P matrix3P = new Matrix3P();
			float num = b[0, 0];
			float num2 = b[1, 0];
			float num3 = b[2, 0];
			matrix3P[0, 0] = a[0, 0] * num + a[0, 1] * num2 + a[0, 2] * num3;
			matrix3P[1, 0] = a[1, 0] * num + a[1, 1] * num2 + a[1, 2] * num3;
			matrix3P[2, 0] = a[2, 0] * num + a[2, 1] * num2 + a[2, 2] * num3;
			num = b[0, 1];
			num2 = b[1, 1];
			num3 = b[2, 1];
			matrix3P[0, 1] = a[0, 0] * num + a[0, 1] * num2 + a[0, 2] * num3;
			matrix3P[1, 1] = a[1, 0] * num + a[1, 1] * num2 + a[1, 2] * num3;
			matrix3P[2, 1] = a[2, 0] * num + a[2, 1] * num2 + a[2, 2] * num3;
			num = b[0, 2];
			num2 = b[1, 2];
			num3 = b[2, 2];
			matrix3P[0, 2] = a[0, 0] * num + a[0, 1] * num2 + a[0, 2] * num3;
			matrix3P[1, 2] = a[1, 0] * num + a[1, 1] * num2 + a[1, 2] * num3;
			matrix3P[2, 2] = a[2, 0] * num + a[2, 1] * num2 + a[2, 2] * num3;
			return matrix3P;
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x000079FC File Offset: 0x00005BFC
		public void setTilda(Vector3P a)
		{
			this.Aside.Y = -a.Z;
			this.Aside.Z = a.Y;
			this.Up.X = a.Z;
			this.Up.Z = -a.X;
			this.Dir.X = -a.Y;
			this.Dir.Y = a.X;
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x00007A72 File Offset: 0x00005C72
		public void write(BinaryWriter output)
		{
			this.Aside.write(output);
			this.Up.write(output);
			this.Dir.write(output);
		}

		// Token: 0x040001B8 RID: 440
		private Vector3P[] columns;
	}
}
