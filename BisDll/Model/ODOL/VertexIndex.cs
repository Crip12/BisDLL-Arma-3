using System;

namespace BisDll.Model.ODOL
{
	// Token: 0x0200002D RID: 45
	public struct VertexIndex
	{
		// Token: 0x06000164 RID: 356 RVA: 0x00005753 File Offset: 0x00003953
		public static implicit operator int(VertexIndex vi)
		{
			return vi.value;
		}

		// Token: 0x06000165 RID: 357 RVA: 0x0000575C File Offset: 0x0000395C
		public static implicit operator VertexIndex(ushort vi)
		{
			VertexIndex result;
			result.value = ((vi == ushort.MaxValue) ? -1 : ((int)vi));
			return result;
		}

		// Token: 0x06000166 RID: 358 RVA: 0x00005780 File Offset: 0x00003980
		public static implicit operator VertexIndex(int vi)
		{
			VertexIndex result;
			result.value = vi;
			return result;
		}

		// Token: 0x04000191 RID: 401
		private int value;
	}
}
