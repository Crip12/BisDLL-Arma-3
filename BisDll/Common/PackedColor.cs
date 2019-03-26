using System;

namespace BisDll.Common
{
	// Token: 0x02000040 RID: 64
	public struct PackedColor
	{
		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x060001D0 RID: 464 RVA: 0x000076AC File Offset: 0x000058AC
		public byte A8
		{
			get
			{
				return (byte)(this.value >> 24 & 255u);
			}
		}

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x060001D1 RID: 465 RVA: 0x000076BE File Offset: 0x000058BE
		public byte R8
		{
			get
			{
				return (byte)(this.value >> 16 & 255u);
			}
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x060001D2 RID: 466 RVA: 0x000076D0 File Offset: 0x000058D0
		public byte G8
		{
			get
			{
				return (byte)(this.value >> 8 & 255u);
			}
		}

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x060001D3 RID: 467 RVA: 0x000076E1 File Offset: 0x000058E1
		public byte B8
		{
			get
			{
				return (byte)(this.value & 255u);
			}
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x000076F0 File Offset: 0x000058F0
		public PackedColor(uint value)
		{
			this.value = value;
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x000076F9 File Offset: 0x000058F9
		public PackedColor(byte r, byte g, byte b, byte a = 255)
		{
			this.value = PackedColor.PackColor(r, g, b, a);
		}

		// Token: 0x060001D6 RID: 470 RVA: 0x0000770C File Offset: 0x0000590C
		public PackedColor(float r, float g, float b, float a)
		{
			byte r2 = (byte)(r * 255f);
			byte g2 = (byte)(g * 255f);
			byte b2 = (byte)(b * 255f);
			byte a2 = (byte)(a * 255f);
			this.value = PackedColor.PackColor(r2, g2, b2, a2);
		}

		// Token: 0x060001D7 RID: 471 RVA: 0x0000774D File Offset: 0x0000594D
		internal static uint PackColor(byte r, byte g, byte b, byte a)
		{
			return (uint)((int)a << 24 | (int)r << 16 | (int)g << 8 | (int)b);
		}

		// Token: 0x040001B7 RID: 439
		private uint value;
	}
}
