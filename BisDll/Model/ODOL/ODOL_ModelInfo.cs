using System;
using BisDll.Common;
using BisDll.Common.Math;
using BisDll.Stream;

namespace BisDll.Model.ODOL
{
	// Token: 0x02000015 RID: 21
	public class ODOL_ModelInfo
	{
		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000077 RID: 119 RVA: 0x0000409E File Offset: 0x0000229E
		// (set) Token: 0x06000078 RID: 120 RVA: 0x000040A6 File Offset: 0x000022A6
		public int special { get; private set; }

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000079 RID: 121 RVA: 0x000040AF File Offset: 0x000022AF
		// (set) Token: 0x0600007A RID: 122 RVA: 0x000040B7 File Offset: 0x000022B7
		public float BoundingSphere { get; private set; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x0600007B RID: 123 RVA: 0x000040C0 File Offset: 0x000022C0
		// (set) Token: 0x0600007C RID: 124 RVA: 0x000040C8 File Offset: 0x000022C8
		public float GeometrySphere { get; private set; }

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x0600007D RID: 125 RVA: 0x000040D1 File Offset: 0x000022D1
		// (set) Token: 0x0600007E RID: 126 RVA: 0x000040D9 File Offset: 0x000022D9
		public int remarks { get; private set; }

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x0600007F RID: 127 RVA: 0x000040E2 File Offset: 0x000022E2
		// (set) Token: 0x06000080 RID: 128 RVA: 0x000040EA File Offset: 0x000022EA
		public int andHints { get; private set; }

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000081 RID: 129 RVA: 0x000040F3 File Offset: 0x000022F3
		// (set) Token: 0x06000082 RID: 130 RVA: 0x000040FB File Offset: 0x000022FB
		public int orHints { get; private set; }

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000083 RID: 131 RVA: 0x00004104 File Offset: 0x00002304
		// (set) Token: 0x06000084 RID: 132 RVA: 0x0000410C File Offset: 0x0000230C
		public Vector3P AimingCenter { get; private set; }

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000085 RID: 133 RVA: 0x00004115 File Offset: 0x00002315
		// (set) Token: 0x06000086 RID: 134 RVA: 0x0000411D File Offset: 0x0000231D
		public PackedColor color { get; private set; }

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000087 RID: 135 RVA: 0x00004126 File Offset: 0x00002326
		// (set) Token: 0x06000088 RID: 136 RVA: 0x0000412E File Offset: 0x0000232E
		public PackedColor colorType { get; private set; }

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000089 RID: 137 RVA: 0x00004137 File Offset: 0x00002337
		// (set) Token: 0x0600008A RID: 138 RVA: 0x0000413F File Offset: 0x0000233F
		public float viewDensity { get; private set; }

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x0600008B RID: 139 RVA: 0x00004148 File Offset: 0x00002348
		// (set) Token: 0x0600008C RID: 140 RVA: 0x00004150 File Offset: 0x00002350
		public Vector3P bboxMin { get; private set; }

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x0600008D RID: 141 RVA: 0x00004159 File Offset: 0x00002359
		// (set) Token: 0x0600008E RID: 142 RVA: 0x00004161 File Offset: 0x00002361
		public Vector3P bboxMax { get; private set; }

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x0600008F RID: 143 RVA: 0x0000416A File Offset: 0x0000236A
		// (set) Token: 0x06000090 RID: 144 RVA: 0x00004172 File Offset: 0x00002372
		public float propertyLodDensityCoef { get; private set; }

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000091 RID: 145 RVA: 0x0000417B File Offset: 0x0000237B
		// (set) Token: 0x06000092 RID: 146 RVA: 0x00004183 File Offset: 0x00002383
		public float propertyDrawImportance { get; private set; }

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000093 RID: 147 RVA: 0x0000418C File Offset: 0x0000238C
		// (set) Token: 0x06000094 RID: 148 RVA: 0x00004194 File Offset: 0x00002394
		public Vector3P bboxMinVisual { get; private set; }

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000095 RID: 149 RVA: 0x0000419D File Offset: 0x0000239D
		// (set) Token: 0x06000096 RID: 150 RVA: 0x000041A5 File Offset: 0x000023A5
		public Vector3P bboxMaxVisual { get; private set; }

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x06000097 RID: 151 RVA: 0x000041AE File Offset: 0x000023AE
		// (set) Token: 0x06000098 RID: 152 RVA: 0x000041B6 File Offset: 0x000023B6
		public Vector3P boundingCenter { get; private set; }

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000099 RID: 153 RVA: 0x000041BF File Offset: 0x000023BF
		// (set) Token: 0x0600009A RID: 154 RVA: 0x000041C7 File Offset: 0x000023C7
		public Vector3P geometryCenter { get; private set; }

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x0600009B RID: 155 RVA: 0x000041D0 File Offset: 0x000023D0
		// (set) Token: 0x0600009C RID: 156 RVA: 0x000041D8 File Offset: 0x000023D8
		public Vector3P centerOfMass { get; private set; }

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x0600009D RID: 157 RVA: 0x000041E1 File Offset: 0x000023E1
		// (set) Token: 0x0600009E RID: 158 RVA: 0x000041E9 File Offset: 0x000023E9
		public Matrix3P invInertia { get; private set; }

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x0600009F RID: 159 RVA: 0x000041F2 File Offset: 0x000023F2
		// (set) Token: 0x060000A0 RID: 160 RVA: 0x000041FA File Offset: 0x000023FA
		public bool autoCenter { get; private set; }

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060000A1 RID: 161 RVA: 0x00004203 File Offset: 0x00002403
		// (set) Token: 0x060000A2 RID: 162 RVA: 0x0000420B File Offset: 0x0000240B
		public bool lockAutoCenter { get; private set; }

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060000A3 RID: 163 RVA: 0x00004214 File Offset: 0x00002414
		// (set) Token: 0x060000A4 RID: 164 RVA: 0x0000421C File Offset: 0x0000241C
		public bool canOcclude { get; private set; }

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060000A5 RID: 165 RVA: 0x00004225 File Offset: 0x00002425
		// (set) Token: 0x060000A6 RID: 166 RVA: 0x0000422D File Offset: 0x0000242D
		public bool canBeOccluded { get; private set; }

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060000A7 RID: 167 RVA: 0x00004236 File Offset: 0x00002436
		// (set) Token: 0x060000A8 RID: 168 RVA: 0x0000423E File Offset: 0x0000243E
		public bool AICovers { get; private set; }

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060000A9 RID: 169 RVA: 0x00004247 File Offset: 0x00002447
		// (set) Token: 0x060000AA RID: 170 RVA: 0x0000424F File Offset: 0x0000244F
		public float htMin { get; private set; }

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060000AB RID: 171 RVA: 0x00004258 File Offset: 0x00002458
		// (set) Token: 0x060000AC RID: 172 RVA: 0x00004260 File Offset: 0x00002460
		public float htMax { get; private set; }

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060000AD RID: 173 RVA: 0x00004269 File Offset: 0x00002469
		// (set) Token: 0x060000AE RID: 174 RVA: 0x00004271 File Offset: 0x00002471
		public float afMax { get; private set; }

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060000AF RID: 175 RVA: 0x0000427A File Offset: 0x0000247A
		// (set) Token: 0x060000B0 RID: 176 RVA: 0x00004282 File Offset: 0x00002482
		public float mfMax { get; private set; }

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060000B1 RID: 177 RVA: 0x0000428B File Offset: 0x0000248B
		// (set) Token: 0x060000B2 RID: 178 RVA: 0x00004293 File Offset: 0x00002493
		public float mFact { get; private set; }

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060000B3 RID: 179 RVA: 0x0000429C File Offset: 0x0000249C
		// (set) Token: 0x060000B4 RID: 180 RVA: 0x000042A4 File Offset: 0x000024A4
		public float tBody { get; private set; }

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060000B5 RID: 181 RVA: 0x000042AD File Offset: 0x000024AD
		// (set) Token: 0x060000B6 RID: 182 RVA: 0x000042B5 File Offset: 0x000024B5
		public bool forceNotAlphaModel { get; private set; }

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060000B7 RID: 183 RVA: 0x000042BE File Offset: 0x000024BE
		// (set) Token: 0x060000B8 RID: 184 RVA: 0x000042C6 File Offset: 0x000024C6
		public SBSource sbSource { get; private set; }

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060000B9 RID: 185 RVA: 0x000042CF File Offset: 0x000024CF
		// (set) Token: 0x060000BA RID: 186 RVA: 0x000042D7 File Offset: 0x000024D7
		public bool prefershadowvolume { get; private set; }

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060000BB RID: 187 RVA: 0x000042E0 File Offset: 0x000024E0
		// (set) Token: 0x060000BC RID: 188 RVA: 0x000042E8 File Offset: 0x000024E8
		public float shadowOffset { get; private set; }

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060000BD RID: 189 RVA: 0x000042F1 File Offset: 0x000024F1
		// (set) Token: 0x060000BE RID: 190 RVA: 0x000042F9 File Offset: 0x000024F9
		public bool animated { get; private set; }

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060000BF RID: 191 RVA: 0x00004302 File Offset: 0x00002502
		// (set) Token: 0x060000C0 RID: 192 RVA: 0x0000430A File Offset: 0x0000250A
		public Skeleton skeleton { get; private set; }

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060000C1 RID: 193 RVA: 0x00004313 File Offset: 0x00002513
		// (set) Token: 0x060000C2 RID: 194 RVA: 0x0000431B File Offset: 0x0000251B
		public MapType mapType { get; private set; }

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060000C3 RID: 195 RVA: 0x00004324 File Offset: 0x00002524
		// (set) Token: 0x060000C4 RID: 196 RVA: 0x0000432C File Offset: 0x0000252C
		public float[] massArray { get; private set; }

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060000C5 RID: 197 RVA: 0x00004335 File Offset: 0x00002535
		// (set) Token: 0x060000C6 RID: 198 RVA: 0x0000433D File Offset: 0x0000253D
		public float mass { get; private set; }

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060000C7 RID: 199 RVA: 0x00004346 File Offset: 0x00002546
		// (set) Token: 0x060000C8 RID: 200 RVA: 0x0000434E File Offset: 0x0000254E
		public float invMass { get; private set; }

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060000C9 RID: 201 RVA: 0x00004357 File Offset: 0x00002557
		// (set) Token: 0x060000CA RID: 202 RVA: 0x0000435F File Offset: 0x0000255F
		public float armor { get; private set; }

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060000CB RID: 203 RVA: 0x00004368 File Offset: 0x00002568
		// (set) Token: 0x060000CC RID: 204 RVA: 0x00004370 File Offset: 0x00002570
		public float invArmor { get; private set; }

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060000CD RID: 205 RVA: 0x00004379 File Offset: 0x00002579
		// (set) Token: 0x060000CE RID: 206 RVA: 0x00004381 File Offset: 0x00002581
		public float propertyExplosionShielding { get; private set; }

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060000CF RID: 207 RVA: 0x0000438A File Offset: 0x0000258A
		// (set) Token: 0x060000D0 RID: 208 RVA: 0x00004392 File Offset: 0x00002592
		public byte memory { get; private set; }

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060000D1 RID: 209 RVA: 0x0000439B File Offset: 0x0000259B
		// (set) Token: 0x060000D2 RID: 210 RVA: 0x000043A3 File Offset: 0x000025A3
		public byte geometry { get; private set; }

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060000D3 RID: 211 RVA: 0x000043AC File Offset: 0x000025AC
		// (set) Token: 0x060000D4 RID: 212 RVA: 0x000043B4 File Offset: 0x000025B4
		public byte geometrySimple { get; private set; }

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x060000D5 RID: 213 RVA: 0x000043BD File Offset: 0x000025BD
		// (set) Token: 0x060000D6 RID: 214 RVA: 0x000043C5 File Offset: 0x000025C5
		public byte geometryPhys { get; private set; }

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x060000D7 RID: 215 RVA: 0x000043CE File Offset: 0x000025CE
		// (set) Token: 0x060000D8 RID: 216 RVA: 0x000043D6 File Offset: 0x000025D6
		public byte geometryFire { get; private set; }

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x060000D9 RID: 217 RVA: 0x000043DF File Offset: 0x000025DF
		// (set) Token: 0x060000DA RID: 218 RVA: 0x000043E7 File Offset: 0x000025E7
		public byte geometryView { get; private set; }

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x060000DB RID: 219 RVA: 0x000043F0 File Offset: 0x000025F0
		// (set) Token: 0x060000DC RID: 220 RVA: 0x000043F8 File Offset: 0x000025F8
		public byte geometryViewPilot { get; private set; }

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x060000DD RID: 221 RVA: 0x00004401 File Offset: 0x00002601
		// (set) Token: 0x060000DE RID: 222 RVA: 0x00004409 File Offset: 0x00002609
		public byte geometryViewGunner { get; private set; }

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x060000DF RID: 223 RVA: 0x00004412 File Offset: 0x00002612
		// (set) Token: 0x060000E0 RID: 224 RVA: 0x0000441A File Offset: 0x0000261A
		public byte geometryViewCargo { get; private set; }

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x060000E1 RID: 225 RVA: 0x00004423 File Offset: 0x00002623
		// (set) Token: 0x060000E2 RID: 226 RVA: 0x0000442B File Offset: 0x0000262B
		public byte landContact { get; private set; }

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x060000E3 RID: 227 RVA: 0x00004434 File Offset: 0x00002634
		// (set) Token: 0x060000E4 RID: 228 RVA: 0x0000443C File Offset: 0x0000263C
		public byte roadway { get; private set; }

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x060000E5 RID: 229 RVA: 0x00004445 File Offset: 0x00002645
		// (set) Token: 0x060000E6 RID: 230 RVA: 0x0000444D File Offset: 0x0000264D
		public byte paths { get; private set; }

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x060000E7 RID: 231 RVA: 0x00004456 File Offset: 0x00002656
		// (set) Token: 0x060000E8 RID: 232 RVA: 0x0000445E File Offset: 0x0000265E
		public byte hitpoints { get; private set; }

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x060000E9 RID: 233 RVA: 0x00004467 File Offset: 0x00002667
		// (set) Token: 0x060000EA RID: 234 RVA: 0x0000446F File Offset: 0x0000266F
		public byte minShadow { get; private set; }

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x060000EB RID: 235 RVA: 0x00004478 File Offset: 0x00002678
		// (set) Token: 0x060000EC RID: 236 RVA: 0x00004480 File Offset: 0x00002680
		public bool canBlend { get; private set; }

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x060000ED RID: 237 RVA: 0x00004489 File Offset: 0x00002689
		// (set) Token: 0x060000EE RID: 238 RVA: 0x00004491 File Offset: 0x00002691
		public string propertyClass { get; private set; }

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x060000EF RID: 239 RVA: 0x0000449A File Offset: 0x0000269A
		// (set) Token: 0x060000F0 RID: 240 RVA: 0x000044A2 File Offset: 0x000026A2
		public string propertyDamage { get; private set; }

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x060000F1 RID: 241 RVA: 0x000044AB File Offset: 0x000026AB
		// (set) Token: 0x060000F2 RID: 242 RVA: 0x000044B3 File Offset: 0x000026B3
		public bool propertyFrequent { get; private set; }

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x060000F3 RID: 243 RVA: 0x000044BC File Offset: 0x000026BC
		// (set) Token: 0x060000F4 RID: 244 RVA: 0x000044C4 File Offset: 0x000026C4
		public int[] preferredShadowVolumeLod { get; private set; }

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x060000F5 RID: 245 RVA: 0x000044CD File Offset: 0x000026CD
		// (set) Token: 0x060000F6 RID: 246 RVA: 0x000044D5 File Offset: 0x000026D5
		public int[] preferredShadowBufferLod { get; private set; }

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x060000F7 RID: 247 RVA: 0x000044DE File Offset: 0x000026DE
		// (set) Token: 0x060000F8 RID: 248 RVA: 0x000044E6 File Offset: 0x000026E6
		public int[] preferredShadowBufferLodVis { get; private set; }

		// Token: 0x060000F9 RID: 249 RVA: 0x000044EF File Offset: 0x000026EF
		internal ODOL_ModelInfo(BinaryReaderEx input, int nLods)
		{
			this.read(input, nLods);
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00004500 File Offset: 0x00002700
		public void read(BinaryReaderEx input, int nLods)
		{
			int version = input.Version;
			this.special = input.ReadInt32();
			this.BoundingSphere = input.ReadSingle();
			this.GeometrySphere = input.ReadSingle();
			this.remarks = input.ReadInt32();
			this.andHints = input.ReadInt32();
			this.orHints = input.ReadInt32();
			this.AimingCenter = new Vector3P(input);
			this.color = new PackedColor(input.ReadUInt32());
			this.colorType = new PackedColor(input.ReadUInt32());
			this.viewDensity = input.ReadSingle();
			this.bboxMin = new Vector3P(input);
			this.bboxMax = new Vector3P(input);
			if (version >= 70)
			{
				this.propertyLodDensityCoef = input.ReadSingle();
			}
			if (version >= 71)
			{
				this.propertyDrawImportance = input.ReadSingle();
			}
			if (version >= 52)
			{
				this.bboxMinVisual = new Vector3P(input);
				this.bboxMaxVisual = new Vector3P(input);
			}
			this.boundingCenter = new Vector3P(input);
			this.geometryCenter = new Vector3P(input);
			this.centerOfMass = new Vector3P(input);
			this.invInertia = new Matrix3P(input);
			this.autoCenter = input.ReadBoolean();
			this.lockAutoCenter = input.ReadBoolean();
			this.canOcclude = input.ReadBoolean();
			this.canBeOccluded = input.ReadBoolean();
			if (version >= 73)
			{
				this.AICovers = input.ReadBoolean();
			}
			if ((version >= 42 && version < 10000) || version >= 10042)
			{
				this.htMin = input.ReadSingle();
				this.htMax = input.ReadSingle();
				this.afMax = input.ReadSingle();
				this.mfMax = input.ReadSingle();
			}
			if ((version >= 43 && version < 10000) || version >= 10043)
			{
				this.mFact = input.ReadSingle();
				this.tBody = input.ReadSingle();
			}
			if (version >= 33)
			{
				this.forceNotAlphaModel = input.ReadBoolean();
			}
			if (version >= 37)
			{
				this.sbSource = (SBSource)input.ReadInt32();
				this.prefershadowvolume = input.ReadBoolean();
			}
			if (version >= 48)
			{
				this.shadowOffset = input.ReadSingle();
			}
			this.animated = input.ReadBoolean();
			this.skeleton = new Skeleton(input);
			this.mapType = (MapType)input.ReadByte();
			this.massArray = input.ReadCompressedFloatArray();
			this.mass = input.ReadSingle();
			this.invMass = input.ReadSingle();
			this.armor = input.ReadSingle();
			this.invArmor = input.ReadSingle();
			if (version >= 72)
			{
				this.propertyExplosionShielding = input.ReadSingle();
			}
			if (version >= 53)
			{
				this.geometrySimple = input.ReadByte();
			}
			if (version >= 54)
			{
				this.geometryPhys = input.ReadByte();
			}
			this.memory = input.ReadByte();
			this.geometry = input.ReadByte();
			this.geometryFire = input.ReadByte();
			this.geometryView = input.ReadByte();
			this.geometryViewPilot = input.ReadByte();
			this.geometryViewGunner = input.ReadByte();
			input.ReadSByte();
			this.geometryViewCargo = input.ReadByte();
			this.landContact = input.ReadByte();
			this.roadway = input.ReadByte();
			this.paths = input.ReadByte();
			this.hitpoints = input.ReadByte();
			this.minShadow = (byte)input.ReadUInt32();
			if (version >= 38)
			{
				this.canBlend = input.ReadBoolean();
			}
			this.propertyClass = input.ReadAsciiz();
			this.propertyDamage = input.ReadAsciiz();
			this.propertyFrequent = input.ReadBoolean();
			if (version >= 31)
			{
				input.ReadUInt32();
			}
			if (version >= 57)
			{
				this.preferredShadowVolumeLod = new int[nLods];
				this.preferredShadowBufferLod = new int[nLods];
				this.preferredShadowBufferLodVis = new int[nLods];
				for (int i = 0; i < nLods; i++)
				{
					this.preferredShadowVolumeLod[i] = input.ReadInt32();
				}
				for (int j = 0; j < nLods; j++)
				{
					this.preferredShadowBufferLod[j] = input.ReadInt32();
				}
				for (int k = 0; k < nLods; k++)
				{
					this.preferredShadowBufferLodVis[k] = input.ReadInt32();
				}
			}
		}
	}
}
