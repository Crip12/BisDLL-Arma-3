using System;
using BisDll.Stream;

namespace BisDll.Model.ODOL
{
	// Token: 0x0200002B RID: 43
	public class STPairCompressed : STPair, IDeserializable
	{
		// Token: 0x0600015E RID: 350 RVA: 0x000054F2 File Offset: 0x000036F2
		public void ReadObject(BinaryReaderEx input)
		{
			base.S.readCompressed(input);
			base.T.readCompressed(input);
		}
	}
}
