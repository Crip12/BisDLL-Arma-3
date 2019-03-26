using System;
using BisDll.Common.Math;
using BisDll.Stream;

namespace BisDll.Model.MLOD
{
	// Token: 0x02000032 RID: 50
	public class Point : Vector3P
	{
		// Token: 0x17000098 RID: 152
		// (get) Token: 0x0600018C RID: 396 RVA: 0x0000632B File Offset: 0x0000452B
		// (set) Token: 0x0600018D RID: 397 RVA: 0x00006333 File Offset: 0x00004533
		public PointFlags PointFlags { get; private set; }

		// Token: 0x0600018E RID: 398 RVA: 0x0000633C File Offset: 0x0000453C
		public Point(Vector3P pos, PointFlags flags) : base(pos.X, pos.Y, pos.Z)
		{
			this.PointFlags = flags;
		}

		// Token: 0x0600018F RID: 399 RVA: 0x0000635D File Offset: 0x0000455D
		public Point(BinaryReaderEx input) : base(input)
		{
			this.PointFlags = (PointFlags)input.ReadUInt32();
		}

		// Token: 0x06000190 RID: 400 RVA: 0x00006372 File Offset: 0x00004572
		public new void write(BinaryWriter output)
		{
			base.write(output);
			output.Write((uint)this.PointFlags);
		}
	}
}
