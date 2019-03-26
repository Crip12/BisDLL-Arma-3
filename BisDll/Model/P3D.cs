using System;
using System.IO;
using System.Linq;
using BisDll.Model.MLOD;
using BisDll.Model.ODOL;
using BisDll.Stream;

namespace BisDll.Model
{
	// Token: 0x0200000D RID: 13
	public abstract class P3D
	{
		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600004B RID: 75 RVA: 0x00003386 File Offset: 0x00001586
		// (set) Token: 0x0600004C RID: 76 RVA: 0x0000338E File Offset: 0x0000158E
		public uint Version { get; protected set; }

		// Token: 0x0600004D RID: 77 RVA: 0x00003397 File Offset: 0x00001597
		public static P3D GetInstance(string fileName)
		{
			return P3D.GetInstance(File.OpenRead(fileName));
		}

		// Token: 0x0600004E RID: 78 RVA: 0x000033A4 File Offset: 0x000015A4
		public static P3D GetInstance(Stream stream)
		{
			string a = new BinaryReaderEx(stream).ReadAscii(4);
			stream.Position -= 4L;
			if (a == "ODOL")
			{
				return new ODOL(stream);
			}
			if (a == "MLOD")
			{
				return new MLOD(stream);
			}
			throw new FormatException();
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600004F RID: 79
		public abstract P3D_LOD[] LODs { get; }

		// Token: 0x06000050 RID: 80 RVA: 0x000033FC File Offset: 0x000015FC
		public virtual P3D_LOD getLOD(float resolution)
		{
			return this.LODs.FirstOrDefault((P3D_LOD lod) => lod.Resolution == resolution);
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000051 RID: 81
		public abstract float Mass { get; }
	}
}
