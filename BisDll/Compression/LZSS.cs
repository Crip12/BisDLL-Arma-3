using System;
using System.IO;

namespace BisDll.Compression
{
	// Token: 0x0200003E RID: 62
	public static class LZSS
	{
		// Token: 0x060001C2 RID: 450 RVA: 0x00007394 File Offset: 0x00005594
		public static uint readLZSS(Stream input, out byte[] dst, uint expectedSize, bool useSignedChecksum)
		{
			char[] array = new char[4113];
			dst = new byte[expectedSize];
			if (expectedSize <= 0u)
			{
				return 0u;
			}
			long position = input.Position;
			uint num = expectedSize;
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < 4078; i++)
			{
				array[i] = ' ';
			}
			int num4 = 4078;
			int num5 = 0;
			while (num > 0u)
			{
				if (((num5 >>= 1) & 256) == 0)
				{
					int num6 = input.ReadByte();
					num5 = (num6 | 65280);
				}
				if ((num5 & 1) != 0)
				{
					int num6 = input.ReadByte();
					if (useSignedChecksum)
					{
						num3 += (int)((sbyte)num6);
					}
					else
					{
						num3 += (int)((byte)num6);
					}
					dst[num2++] = (byte)num6;
					num -= 1u;
					array[num4] = (char)num6;
					num4++;
					num4 &= 4095;
				}
				else
				{
					int i = input.ReadByte();
					int num7 = input.ReadByte();
					i |= (num7 & 240) << 4;
					num7 &= 15;
					num7 += 2;
					int j = num4 - i;
					int num8 = num7 + j;
					if ((long)(num7 + 1) > (long)((ulong)num))
					{
						throw new ArgumentException("LZSS overflow");
					}
					while (j <= num8)
					{
						int num6 = (int)((byte)array[j & 4095]);
						if (useSignedChecksum)
						{
							num3 += (int)((sbyte)num6);
						}
						else
						{
							num3 += (int)((byte)num6);
						}
						dst[num2++] = (byte)num6;
						num -= 1u;
						array[num4] = (char)num6;
						num4++;
						num4 &= 4095;
						j++;
					}
				}
			}
			byte[] array2 = new byte[4];
			input.Read(array2, 0, 4);
			if (BitConverter.ToInt32(array2, 0) != num3)
			{
				throw new ArgumentException("Checksum mismatch");
			}
			return (uint)(input.Position - position);
		}
	}
}
