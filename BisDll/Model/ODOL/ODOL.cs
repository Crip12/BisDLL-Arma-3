using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BisDll.Stream;

namespace BisDll.Model.ODOL
{
	// Token: 0x02000017 RID: 23
	public class ODOL : P3D
	{
		// Token: 0x1700006C RID: 108
		// (get) Token: 0x06000109 RID: 265 RVA: 0x000049BC File Offset: 0x00002BBC
		public Skeleton Skeleton
		{
			get
			{
				return this.modelInfo.skeleton;
			}
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x0600010A RID: 266 RVA: 0x000049C9 File Offset: 0x00002BC9
		public override float Mass
		{
			get
			{
				return this.modelInfo.mass;
			}
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x0600010B RID: 267 RVA: 0x000049D6 File Offset: 0x00002BD6
		public override P3D_LOD[] LODs
		{
			get
			{
				return this.lods;
			}
		}

		// Token: 0x0600010C RID: 268 RVA: 0x000049DE File Offset: 0x00002BDE
		public ODOL(string fileName) : this(File.OpenRead(fileName))
		{
		}

		// Token: 0x0600010D RID: 269 RVA: 0x000049EC File Offset: 0x00002BEC
		public ODOL(Stream stream)
		{
			this.read(new BinaryReaderEx(stream));
		}

		// Token: 0x0600010E RID: 270 RVA: 0x00004A0C File Offset: 0x00002C0C
		public bool isSnappable()
		{
			LOD lod = this.lods.FirstOrDefault((LOD l) => l.Resolution.getLODType() == LodName.Memory);
			if (lod != null)
			{
				if ((from ns in lod.NamedSelections
				where ns.Name.Equals("lb", StringComparison.InvariantCultureIgnoreCase) || ns.Name.Equals("le", StringComparison.InvariantCultureIgnoreCase) || ns.Name.Equals("pb", StringComparison.InvariantCultureIgnoreCase) || ns.Name.Equals("pe", StringComparison.InvariantCultureIgnoreCase)
				select ns).Count<NamedSelection>() >= 4)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600010F RID: 271 RVA: 0x00004A7C File Offset: 0x00002C7C
		private void read(BinaryReaderEx input)
		{
			string b = input.ReadAscii(4);
			if ("ODOL" != b)
			{
				throw new FormatException("ODOL signature is missing");
			}
			base.Version = input.ReadUInt32();
			if (base.Version > 73u)
			{
				throw new FormatException("Unknown ODOL version");
			}
			if (base.Version < 28u)
			{
				throw new FormatException("Old ODOL version is currently not supported");
			}
			input.Version = (int)base.Version;
			if (base.Version >= 44u)
			{
				input.UseLZOCompression = true;
			}
			if (base.Version >= 64u)
			{
				input.UseCompressionFlag = true;
			}
			if (base.Version >= 59u)
			{
				this.appID = input.ReadUInt32();
			}
			if (base.Version >= 58u)
			{
				this.muzzleFlash = input.ReadAsciiz();
			}
			this.nLods = input.ReadInt32();
			this.resolutions = new float[this.nLods];
			for (int i = 0; i < this.nLods; i++)
			{
				this.resolutions[i] = input.ReadSingle();
			}
			this.modelInfo = new ODOL_ModelInfo(input, this.nLods);
			if (base.Version >= 30u)
			{
				this.hasAnims = input.ReadBoolean();
				if (this.hasAnims)
				{
					this.animations.read(input);
				}
			}
			this.lodStartAdresses = new uint[this.nLods];
			this.lodEndAdresses = new uint[this.nLods];
			this.permanent = new bool[this.nLods];
			for (int j = 0; j < this.nLods; j++)
			{
				this.lodStartAdresses[j] = input.ReadUInt32();
			}
			for (int k = 0; k < this.nLods; k++)
			{
				this.lodEndAdresses[k] = input.ReadUInt32();
			}
			for (int l = 0; l < this.nLods; l++)
			{
				this.permanent[l] = input.ReadBoolean();
			}
			this.LoadableLodInfos = new List<LoadableLodInfo>(this.nLods);
			this.lods = new LOD[this.nLods];
			long position = input.Position;
			for (int m = 0; m < this.nLods; m++)
			{
				if (!this.permanent[m])
				{
					LoadableLodInfo loadableLodInfo = new LoadableLodInfo();
					loadableLodInfo.ReadObject(input);
					this.LoadableLodInfos.Add(loadableLodInfo);
					position = input.Position;
				}
				input.Position = (long)((ulong)this.lodStartAdresses[m]);
				this.lods[m] = new LOD();
				this.lods[m].read(input, this.resolutions[m]);
				input.Position = position;
			}
			input.Position = (long)((ulong)this.lodEndAdresses.Max<uint>());
			input.Close();
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00003A56 File Offset: 0x00001C56
		public string[] getModelCfg()
		{
			throw new NotImplementedException();
		}

		// Token: 0x04000116 RID: 278
		public const int LATEST_VERSION = 73;

		// Token: 0x04000117 RID: 279
		public const int MINIMAL_VERSION = 28;

		// Token: 0x04000118 RID: 280
		private string muzzleFlash;

		// Token: 0x04000119 RID: 281
		private uint appID;

		// Token: 0x0400011A RID: 282
		private int nLods;

		// Token: 0x0400011B RID: 283
		private float[] resolutions;

		// Token: 0x0400011C RID: 284
		public ODOL_ModelInfo modelInfo;

		// Token: 0x0400011D RID: 285
		private bool hasAnims;

		// Token: 0x0400011E RID: 286
		private Animations animations = new Animations();

		// Token: 0x0400011F RID: 287
		private uint[] lodStartAdresses;

		// Token: 0x04000120 RID: 288
		private uint[] lodEndAdresses;

		// Token: 0x04000121 RID: 289
		private bool[] permanent;

		// Token: 0x04000122 RID: 290
		private List<LoadableLodInfo> LoadableLodInfos;

		// Token: 0x04000123 RID: 291
		private LOD[] lods;
	}
}
