using System;
using BisDll.Stream;

namespace BisDll.Model.ODOL
{
	// Token: 0x0200002A RID: 42
	public class STPairUncompressed : STPair, IDeserializable
	{
		// Token: 0x0600015C RID: 348 RVA: 0x000054D0 File Offset: 0x000036D0
		public void ReadObject(BinaryReaderEx input)
		{
			base.S.ReadObject(input);
			base.T.ReadObject(input);
		}
	}
}
