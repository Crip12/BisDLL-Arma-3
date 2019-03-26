using System;
using System.IO;

namespace BisDll.Stream
{
	// Token: 0x02000005 RID: 5
	public class BinaryWriter : BinaryWriter
	{
		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000029 RID: 41 RVA: 0x000025D0 File Offset: 0x000007D0
		// (set) Token: 0x0600002A RID: 42 RVA: 0x000025DD File Offset: 0x000007DD
		public long Position
		{
			get
			{
				return this.BaseStream.Position;
			}
			set
			{
				this.BaseStream.Position = value;
			}
		}

		// Token: 0x0600002B RID: 43 RVA: 0x000025EB File Offset: 0x000007EB
		public BinaryWriter(Stream dstStream) : base(dstStream)
		{
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000025F4 File Offset: 0x000007F4
		public void writeAscii(string text, uint len)
		{
			this.Write(text.ToCharArray());
			uint num = (uint)((ulong)len - (ulong)((long)text.Length));
			int num2 = 0;
			while ((long)num2 < (long)((ulong)num))
			{
				this.Write('\0');
				num2++;
			}
		}

		// Token: 0x0600002D RID: 45 RVA: 0x0000262E File Offset: 0x0000082E
		public void writeAsciiz(string text)
		{
			this.Write(text.ToCharArray());
			this.Write('\0');
		}
	}
}
