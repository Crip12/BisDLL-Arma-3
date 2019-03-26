using System;
using BisDll.Stream;

namespace BisDll.Common.Math
{
	// Token: 0x02000042 RID: 66
	public class Matrix4P
	{
		// Token: 0x170000AC RID: 172
		// (get) Token: 0x060001E6 RID: 486 RVA: 0x00007A98 File Offset: 0x00005C98
		public Matrix3P Orientation
		{
			get
			{
				return this.orientation;
			}
		}

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x060001E7 RID: 487 RVA: 0x00007AA0 File Offset: 0x00005CA0
		public Vector3P Position
		{
			get
			{
				return this.position;
			}
		}

		// Token: 0x170000AE RID: 174
		public float this[int row, int col]
		{
			get
			{
				if (col != 3)
				{
					return this.orientation[col][row];
				}
				return this.position[row];
			}
			set
			{
				if (col == 3)
				{
					this.position[row] = value;
					return;
				}
				this.orientation[col][row] = value;
			}
		}

		// Token: 0x060001EA RID: 490 RVA: 0x00007AF4 File Offset: 0x00005CF4
		public Matrix4P() : this(0f)
		{
		}

		// Token: 0x060001EB RID: 491 RVA: 0x00007B01 File Offset: 0x00005D01
		public Matrix4P(float val) : this(new Matrix3P(val), new Vector3P(val))
		{
		}

		// Token: 0x060001EC RID: 492 RVA: 0x00007B15 File Offset: 0x00005D15
		public Matrix4P(BinaryReaderEx input) : this(new Matrix3P(input), new Vector3P(input))
		{
		}

		// Token: 0x060001ED RID: 493 RVA: 0x00007B29 File Offset: 0x00005D29
		private Matrix4P(Matrix3P orientation, Vector3P position)
		{
			this.orientation = orientation;
			this.position = position;
		}

		// Token: 0x060001EE RID: 494 RVA: 0x00007B40 File Offset: 0x00005D40
		public static Matrix4P operator *(Matrix4P a, Matrix4P b)
		{
			Matrix4P matrix4P = new Matrix4P();
			float num = b[0, 0];
			float num2 = b[1, 0];
			float num3 = b[2, 0];
			matrix4P[0, 0] = a[0, 0] * num + a[0, 1] * num2 + a[0, 2] * num3;
			matrix4P[1, 0] = a[1, 0] * num + a[1, 1] * num2 + a[1, 2] * num3;
			matrix4P[2, 0] = a[2, 0] * num + a[2, 1] * num2 + a[2, 2] * num3;
			num = b[0, 1];
			num2 = b[1, 1];
			num3 = b[2, 1];
			matrix4P[0, 1] = a[0, 0] * num + a[0, 1] * num2 + a[0, 2] * num3;
			matrix4P[1, 1] = a[1, 0] * num + a[1, 1] * num2 + a[1, 2] * num3;
			matrix4P[2, 1] = a[2, 0] * num + a[2, 1] * num2 + a[2, 2] * num3;
			num = b[0, 2];
			num2 = b[1, 2];
			num3 = b[2, 2];
			matrix4P[0, 2] = a[0, 0] * num + a[0, 1] * num2 + a[0, 2] * num3;
			matrix4P[1, 2] = a[1, 0] * num + a[1, 1] * num2 + a[1, 2] * num3;
			matrix4P[2, 2] = a[2, 0] * num + a[2, 1] * num2 + a[2, 2] * num3;
			num = b.Position.X;
			num2 = b.Position.Y;
			num3 = b.Position.Z;
			matrix4P.Position.X = a[0, 0] * num + a[0, 1] * num2 + a[0, 2] * num3 + a.Position.X;
			matrix4P.Position.Y = a[1, 0] * num + a[1, 1] * num2 + a[1, 2] * num3 + a.Position.Y;
			matrix4P.Position.Z = a[2, 0] * num + a[2, 1] * num2 + a[2, 2] * num3 + a.Position.Z;
			return matrix4P;
		}

		// Token: 0x060001EF RID: 495 RVA: 0x00007DD4 File Offset: 0x00005FD4
		public void write(BinaryWriter output)
		{
			this.orientation.write(output);
			this.position.write(output);
		}

		// Token: 0x040001B9 RID: 441
		private Matrix3P orientation;

		// Token: 0x040001BA RID: 442
		private Vector3P position;
	}
}
