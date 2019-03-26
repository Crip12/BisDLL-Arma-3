using System;
using BisDll.Common.Math;

namespace BisDll.Model
{
	// Token: 0x0200000C RID: 12
	public abstract class P3D_LOD
	{
		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000044 RID: 68 RVA: 0x00003369 File Offset: 0x00001569
		public string Name
		{
			get
			{
				return this.resolution.getLODName();
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000045 RID: 69 RVA: 0x00003376 File Offset: 0x00001576
		public float Resolution
		{
			get
			{
				return this.resolution;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000046 RID: 70
		public abstract Vector3P[] Points { get; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000047 RID: 71
		public abstract Vector3P[] Normals { get; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000048 RID: 72
		public abstract string[] Textures { get; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000049 RID: 73
		public abstract string[] MaterialNames { get; }

		// Token: 0x04000061 RID: 97
		protected float resolution;
	}
}
