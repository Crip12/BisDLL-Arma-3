using System;
using System.Globalization;
using BisDll.Stream;

namespace BisDll.Common
{
	// Token: 0x0200003F RID: 63
	public struct ColorP
	{
		// Token: 0x1700009F RID: 159
		// (get) Token: 0x060001C3 RID: 451 RVA: 0x0000753C File Offset: 0x0000573C
		// (set) Token: 0x060001C4 RID: 452 RVA: 0x00007544 File Offset: 0x00005744
		public float Red { get; private set; }

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x060001C5 RID: 453 RVA: 0x0000754D File Offset: 0x0000574D
		// (set) Token: 0x060001C6 RID: 454 RVA: 0x00007555 File Offset: 0x00005755
		public float Green { get; private set; }

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x060001C7 RID: 455 RVA: 0x0000755E File Offset: 0x0000575E
		// (set) Token: 0x060001C8 RID: 456 RVA: 0x00007566 File Offset: 0x00005766
		public float Blue { get; private set; }

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x060001C9 RID: 457 RVA: 0x0000756F File Offset: 0x0000576F
		// (set) Token: 0x060001CA RID: 458 RVA: 0x00007577 File Offset: 0x00005777
		public float Alpha { get; private set; }

		// Token: 0x060001CB RID: 459 RVA: 0x00007580 File Offset: 0x00005780
		public ColorP(float r, float g, float b, float a)
		{
			this.Red = r;
			this.Green = g;
			this.Blue = b;
			this.Alpha = a;
		}

		// Token: 0x060001CC RID: 460 RVA: 0x0000759F File Offset: 0x0000579F
		public ColorP(BinaryReaderEx input)
		{
			this.Red = input.ReadSingle();
			this.Green = input.ReadSingle();
			this.Blue = input.ReadSingle();
			this.Alpha = input.ReadSingle();
		}

		// Token: 0x060001CD RID: 461 RVA: 0x0000759F File Offset: 0x0000579F
		public void read(BinaryReaderEx input)
		{
			this.Red = input.ReadSingle();
			this.Green = input.ReadSingle();
			this.Blue = input.ReadSingle();
			this.Alpha = input.ReadSingle();
		}

		// Token: 0x060001CE RID: 462 RVA: 0x000075D1 File Offset: 0x000057D1
		public void write(BinaryWriter output)
		{
			output.Write(this.Red);
			output.Write(this.Green);
			output.Write(this.Blue);
			output.Write(this.Alpha);
		}

		// Token: 0x060001CF RID: 463 RVA: 0x00007604 File Offset: 0x00005804
		public override string ToString()
		{
			CultureInfo cultureInfo = new CultureInfo("en-GB");
			return string.Concat(new string[]
			{
				"{",
				this.Red.ToString(cultureInfo.NumberFormat),
				",",
				this.Green.ToString(cultureInfo.NumberFormat),
				",",
				this.Blue.ToString(cultureInfo.NumberFormat),
				",",
				this.Alpha.ToString(cultureInfo.NumberFormat),
				"}"
			});
		}
	}
}
