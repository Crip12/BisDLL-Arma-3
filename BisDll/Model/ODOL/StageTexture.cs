using System;
using BisDll.Stream;

namespace BisDll.Model.ODOL
{
	// Token: 0x02000013 RID: 19
	public class StageTexture
	{
		// Token: 0x06000075 RID: 117 RVA: 0x0000405F File Offset: 0x0000225F
		public void read(BinaryReaderEx input, uint matVersion)
		{
			if (matVersion >= 5u)
			{
				this.textureFilter = (StageTexture.TextureFilterType)input.ReadUInt32();
			}
			this.texture = input.ReadAsciiz();
			if (matVersion >= 8u)
			{
				this.stageID = input.ReadUInt32();
			}
			if (matVersion >= 11u)
			{
				this.useWorldEnvMap = input.ReadBoolean();
			}
		}

		// Token: 0x040000A5 RID: 165
		public StageTexture.TextureFilterType textureFilter;

		// Token: 0x040000A6 RID: 166
		public string texture;

		// Token: 0x040000A7 RID: 167
		public uint stageID;

		// Token: 0x040000A8 RID: 168
		public bool useWorldEnvMap;

		// Token: 0x0200005C RID: 92
		public enum TextureFilterType
		{
			// Token: 0x040002DA RID: 730
			Point,
			// Token: 0x040002DB RID: 731
			Linear,
			// Token: 0x040002DC RID: 732
			Triliniear,
			// Token: 0x040002DD RID: 733
			Anisotropic
		}
	}
}
