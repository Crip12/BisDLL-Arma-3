using System;
using System.IO;

namespace BisDll.Compression
{
	// Token: 0x0200003D RID: 61
	public static class LZO
	{
		// Token: 0x060001BA RID: 442 RVA: 0x00006A78 File Offset: 0x00004C78
		public unsafe static uint decompress(byte* input, byte* output, uint expectedSize)
		{
			byte* ptr = output + expectedSize;
			byte* ptr2 = output;
			byte* ptr3 = input;
			uint num;
			if (*ptr3 > 17)
			{
				num = (uint)(*(ptr3++) - 17);
				if (num < 4u)
				{
					goto IL_37D;
				}
				if ((long)(ptr - ptr2) < (long)((ulong)num))
				{
					throw new OverflowException("Outpur Overrun");
				}
				do
				{
					*(ptr2++) = *(ptr3++);
				}
				while ((num -= 1u) > 0u);
				goto IL_F2;
			}
			IL_50:
			num = (uint)(*(ptr3++));
			if (num >= 16u)
			{
				goto IL_169;
			}
			if (num == 0u)
			{
				while (*ptr3 == 0)
				{
					num += 255u;
					ptr3++;
				}
				num += (uint)(15 + *(ptr3++));
			}
			if ((long)(ptr - ptr2) < (long)((ulong)(num + 3u)))
			{
				throw new OverflowException("Output Overrun");
			}
			*(int*)ptr2 = (int)(*(uint*)ptr3);
			ptr2 += 4;
			ptr3 += 4;
			if ((num -= 1u) > 0u)
			{
				if (num >= 4u)
				{
					do
					{
						*(int*)ptr2 = (int)(*(uint*)ptr3);
						ptr2 += 4;
						ptr3 += 4;
						num -= 4u;
					}
					while (num >= 4u);
					if (num > 0u)
					{
						do
						{
							*(ptr2++) = *(ptr3++);
						}
						while ((num -= 1u) > 0u);
					}
				}
				else
				{
					do
					{
						*(ptr2++) = *(ptr3++);
					}
					while ((num -= 1u) > 0u);
				}
			}
			IL_F2:
			num = (uint)(*(ptr3++));
			byte* ptr4;
			if (num < 16u)
			{
				ptr4 = ptr2 - (1u + LZO.M2_MAX_OFFSET);
				ptr4 -= num >> 2;
				ptr4 -= *(ptr3++) << 2;
				if (ptr4 < output || ptr4 >= ptr2)
				{
					throw new OverflowException("Lookbehind Overrun");
				}
				if ((long)(ptr - ptr2) < 3L)
				{
					throw new OverflowException("Output Overrun");
				}
				*(ptr2++) = *(ptr4++);
				*(ptr2++) = *(ptr4++);
				*(ptr2++) = *ptr4;
				goto IL_36F;
			}
			IL_169:
			if (num >= 64u)
			{
				ptr4 = ptr2 - 1;
				ptr4 -= (num >> 2 & 7u);
				ptr4 -= *(ptr3++) << 3;
				num = (num >> 5) - 1u;
				if (ptr4 < output || ptr4 >= ptr2)
				{
					throw new OverflowException("Lookbehind Overrun");
				}
				if ((long)(ptr - ptr2) < (long)((ulong)(num + 2u)))
				{
					throw new OverflowException("Output Overrun");
				}
			}
			else
			{
				if (num >= 32u)
				{
					num &= 31u;
					if (num == 0u)
					{
						while (*ptr3 == 0)
						{
							num += 255u;
							ptr3++;
						}
						num += (uint)(31 + *(ptr3++));
					}
					ptr4 = ptr2 - 1;
					ptr4 -= (*ptr3 >> 2) + ((int)ptr3[1] << 6);
					ptr3 += 2;
				}
				else if (num >= 16u)
				{
					ptr4 = ptr2;
					ptr4 -= (num & 8u) << 11;
					num &= 7u;
					if (num == 0u)
					{
						while (*ptr3 == 0)
						{
							num += 255u;
							ptr3++;
						}
						num += (uint)(7 + *(ptr3++));
					}
					ptr4 -= (*ptr3 >> 2) + ((int)ptr3[1] << 6);
					ptr3 += 2;
					if (ptr4 == ptr2)
					{
						long num2 = (long)(ptr2 - output);
						if (ptr4 != ptr)
						{
							throw new OverflowException("Output Underrun");
						}
						return (uint)((long)(ptr3 - input));
					}
					else
					{
						ptr4 -= 16384;
					}
				}
				else
				{
					ptr4 = ptr2 - 1;
					ptr4 -= num >> 2;
					ptr4 -= *(ptr3++) << 2;
					if (ptr4 < output || ptr4 >= ptr2)
					{
						throw new OverflowException("Lookbehind Overrun");
					}
					if ((long)(ptr - ptr2) < 2L)
					{
						throw new OverflowException("Output Overrun");
					}
					*(ptr2++) = *(ptr4++);
					*(ptr2++) = *ptr4;
					goto IL_36F;
				}
				if (ptr4 < output || ptr4 >= ptr2)
				{
					throw new OverflowException("Lookbehind Overrun");
				}
				if ((long)(ptr - ptr2) < (long)((ulong)(num + 2u)))
				{
					throw new OverflowException("Output Overrun");
				}
				if (num >= 6u && (long)(ptr2 - ptr4) >= 4L)
				{
					*(int*)ptr2 = (int)(*(uint*)ptr4);
					ptr2 += 4;
					ptr4 += 4;
					num -= 2u;
					do
					{
						*(int*)ptr2 = (int)(*(uint*)ptr4);
						ptr2 += 4;
						ptr4 += 4;
						num -= 4u;
					}
					while (num >= 4u);
					if (num > 0u)
					{
						do
						{
							*(ptr2++) = *(ptr4++);
						}
						while ((num -= 1u) > 0u);
						goto IL_36F;
					}
					goto IL_36F;
				}
			}
			*(ptr2++) = *(ptr4++);
			*(ptr2++) = *(ptr4++);
			do
			{
				*(ptr2++) = *(ptr4++);
			}
			while ((num -= 1u) > 0u);
			IL_36F:
			num = (uint)(ptr3[-2] & 3);
			if (num == 0u)
			{
				goto IL_50;
			}
			IL_37D:
			if ((long)(ptr - ptr2) < (long)((ulong)num))
			{
				throw new OverflowException("Output Overrun");
			}
			*(ptr2++) = *(ptr3++);
			if (num > 1u)
			{
				*(ptr2++) = *(ptr3++);
				if (num > 2u)
				{
					*(ptr2++) = *(ptr3++);
				}
			}
			num = (uint)(*(ptr3++));
			goto IL_169;
		}

		// Token: 0x060001BB RID: 443 RVA: 0x00006E50 File Offset: 0x00005050
		private static byte ip(Stream i)
		{
			byte result = (byte)i.ReadByte();
			long position = i.Position;
			i.Position = position - 1L;
			return result;
		}

		// Token: 0x060001BC RID: 444 RVA: 0x00006E75 File Offset: 0x00005075
		private static byte ip(Stream i, short offset)
		{
			i.Position += (long)offset;
			byte result = (byte)i.ReadByte();
			i.Position -= (long)(offset + 1);
			return result;
		}

		// Token: 0x060001BD RID: 445 RVA: 0x00006E9E File Offset: 0x0000509E
		private static byte next(Stream i)
		{
			return (byte)i.ReadByte();
		}

		// Token: 0x060001BE RID: 446 RVA: 0x00006EA8 File Offset: 0x000050A8
		public unsafe static uint decompress(Stream i, byte* output, uint expectedSize)
		{
			long position = i.Position;
			byte* ptr = output + expectedSize;
			byte* ptr2 = output;
			uint num;
			if (LZO.ip(i) > 17)
			{
				num = (uint)(LZO.next(i) - 17);
				if (num < 4u)
				{
					goto IL_435;
				}
				if ((long)(ptr - ptr2) < (long)((ulong)num))
				{
					throw new OverflowException("Outpur Overrun");
				}
				do
				{
					*(ptr2++) = LZO.next(i);
				}
				while ((num -= 1u) > 0u);
				goto IL_156;
			}
			IL_59:
			num = (uint)LZO.next(i);
			if (num >= 16u)
			{
				goto IL_1CD;
			}
			if (num == 0u)
			{
				while (LZO.ip(i) == 0)
				{
					num += 255u;
					long position2 = i.Position;
					i.Position = position2 + 1L;
				}
				num += (uint)(15 + LZO.next(i));
			}
			if ((long)(ptr - ptr2) < (long)((ulong)(num + 3u)))
			{
				throw new OverflowException("Output Overrun");
			}
			*(ptr2++) = LZO.next(i);
			*(ptr2++) = LZO.next(i);
			*(ptr2++) = LZO.next(i);
			*(ptr2++) = LZO.next(i);
			if ((num -= 1u) > 0u)
			{
				if (num >= 4u)
				{
					do
					{
						*(ptr2++) = LZO.next(i);
						*(ptr2++) = LZO.next(i);
						*(ptr2++) = LZO.next(i);
						*(ptr2++) = LZO.next(i);
						num -= 4u;
					}
					while (num >= 4u);
					if (num > 0u)
					{
						do
						{
							*(ptr2++) = LZO.next(i);
						}
						while ((num -= 1u) > 0u);
					}
				}
				else
				{
					do
					{
						*(ptr2++) = LZO.next(i);
					}
					while ((num -= 1u) > 0u);
				}
			}
			IL_156:
			num = (uint)LZO.next(i);
			byte* ptr3;
			if (num < 16u)
			{
				ptr3 = ptr2 - (1u + LZO.M2_MAX_OFFSET);
				ptr3 -= num >> 2;
				ptr3 -= LZO.next(i) << 2;
				if (ptr3 < output || ptr3 >= ptr2)
				{
					throw new OverflowException("Lookbehind Overrun");
				}
				if ((long)(ptr - ptr2) < 3L)
				{
					throw new OverflowException("Output Overrun");
				}
				*(ptr2++) = *(ptr3++);
				*(ptr2++) = *(ptr3++);
				*(ptr2++) = *ptr3;
				goto IL_424;
			}
			IL_1CD:
			if (num >= 64u)
			{
				ptr3 = ptr2 - 1;
				ptr3 -= (num >> 2 & 7u);
				ptr3 -= LZO.next(i) << 3;
				num = (num >> 5) - 1u;
				if (ptr3 < output || ptr3 >= ptr2)
				{
					throw new OverflowException("Lookbehind Overrun");
				}
				if ((long)(ptr - ptr2) < (long)((ulong)(num + 2u)))
				{
					throw new OverflowException("Output Overrun");
				}
			}
			else
			{
				if (num >= 32u)
				{
					num &= 31u;
					if (num == 0u)
					{
						while (LZO.ip(i) == 0)
						{
							num += 255u;
							long position2 = i.Position;
							i.Position = position2 + 1L;
						}
						num += (uint)(31 + LZO.next(i));
					}
					ptr3 = ptr2 - 1;
					ptr3 -= (LZO.ip(i, 0) >> 2) + ((int)LZO.ip(i, 1) << 6);
					i.Position += 2L;
				}
				else if (num >= 16u)
				{
					ptr3 = ptr2;
					ptr3 -= (num & 8u) << 11;
					num &= 7u;
					if (num == 0u)
					{
						while (LZO.ip(i) == 0)
						{
							num += 255u;
							long position2 = i.Position;
							i.Position = position2 + 1L;
						}
						num += (uint)(7 + LZO.next(i));
					}
					ptr3 -= (LZO.ip(i, 0) >> 2) + ((int)LZO.ip(i, 1) << 6);
					i.Position += 2L;
					if (ptr3 == ptr2)
					{
						long num2 = (long)(ptr2 - output);
						if (ptr3 != ptr)
						{
							throw new OverflowException("Output Underrun");
						}
						return (uint)(i.Position - position);
					}
					else
					{
						ptr3 -= 16384;
					}
				}
				else
				{
					ptr3 = ptr2 - 1;
					ptr3 -= num >> 2;
					ptr3 -= LZO.next(i) << 2;
					if (ptr3 < output || ptr3 >= ptr2)
					{
						throw new OverflowException("Lookbehind Overrun");
					}
					if ((long)(ptr - ptr2) < 2L)
					{
						throw new OverflowException("Output Overrun");
					}
					*(ptr2++) = *(ptr3++);
					*(ptr2++) = *ptr3;
					goto IL_424;
				}
				if (ptr3 < output || ptr3 >= ptr2)
				{
					throw new OverflowException("Lookbehind Overrun");
				}
				if ((long)(ptr - ptr2) < (long)((ulong)(num + 2u)))
				{
					throw new OverflowException("Output Overrun");
				}
				if (num >= 6u && (long)(ptr2 - ptr3) >= 4L)
				{
					*(int*)ptr2 = (int)(*(uint*)ptr3);
					ptr2 += 4;
					ptr3 += 4;
					num -= 2u;
					do
					{
						*(int*)ptr2 = (int)(*(uint*)ptr3);
						ptr2 += 4;
						ptr3 += 4;
						num -= 4u;
					}
					while (num >= 4u);
					if (num > 0u)
					{
						do
						{
							*(ptr2++) = *(ptr3++);
						}
						while ((num -= 1u) > 0u);
						goto IL_424;
					}
					goto IL_424;
				}
			}
			*(ptr2++) = *(ptr3++);
			*(ptr2++) = *(ptr3++);
			do
			{
				*(ptr2++) = *(ptr3++);
			}
			while ((num -= 1u) > 0u);
			IL_424:
			num = (uint)(LZO.ip(i, -2) & 3);
			if (num == 0u)
			{
				goto IL_59;
			}
			IL_435:
			if ((long)(ptr - ptr2) < (long)((ulong)num))
			{
				throw new OverflowException("Output Overrun");
			}
			*(ptr2++) = LZO.next(i);
			if (num > 1u)
			{
				*(ptr2++) = LZO.next(i);
				if (num > 2u)
				{
					*(ptr2++) = LZO.next(i);
				}
			}
			num = (uint)LZO.next(i);
			goto IL_1CD;
		}

		// Token: 0x060001BF RID: 447 RVA: 0x00007338 File Offset: 0x00005538
		public unsafe static uint readLZO(Stream input, out byte[] dst, uint expectedSize)
		{
			dst = new byte[expectedSize];
			fixed (byte* ptr = &dst[0])
			{
				return LZO.decompress(input, ptr, expectedSize);
			}
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x00007360 File Offset: 0x00005560
		public unsafe static byte[] readLZO(Stream input, uint expectedSize)
		{
			byte[] array = new byte[expectedSize];
			fixed (byte* ptr = &array[0])
			{
				LZO.decompress(input, ptr, expectedSize);
			}
			return array;
		}

		// Token: 0x040001B2 RID: 434
		private static readonly uint M2_MAX_OFFSET = 2048u;
	}
}
