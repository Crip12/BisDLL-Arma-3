using System;
using System.IO;
using System.Runtime.InteropServices;
using BisDll.Compression;

namespace BisDll.Stream
{
	// Token: 0x02000004 RID: 4
	public class BinaryReaderEx : BinaryReader
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000007 RID: 7 RVA: 0x000020A7 File Offset: 0x000002A7
		// (set) Token: 0x06000008 RID: 8 RVA: 0x000020AF File Offset: 0x000002AF
		public bool UseCompressionFlag { get; set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000009 RID: 9 RVA: 0x000020B8 File Offset: 0x000002B8
		// (set) Token: 0x0600000A RID: 10 RVA: 0x000020C0 File Offset: 0x000002C0
		public bool UseLZOCompression { get; set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600000B RID: 11 RVA: 0x000020C9 File Offset: 0x000002C9
		// (set) Token: 0x0600000C RID: 12 RVA: 0x000020D1 File Offset: 0x000002D1
		public int Version { get; set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000D RID: 13 RVA: 0x000020DA File Offset: 0x000002DA
		// (set) Token: 0x0600000E RID: 14 RVA: 0x000020E7 File Offset: 0x000002E7
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

		// Token: 0x0600000F RID: 15 RVA: 0x000020F5 File Offset: 0x000002F5
		public BinaryReaderEx(Stream stream) : base(stream)
		{
			this.UseCompressionFlag = false;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002105 File Offset: 0x00000305
		public uint ReadUInt24()
		{
			return (uint)((int)this.ReadByte() + ((int)this.ReadByte() << 8) + ((int)this.ReadByte() << 16));
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002120 File Offset: 0x00000320
		public string ReadAscii(int count)
		{
			string text = "";
			for (int i = 0; i < count; i++)
			{
				text += ((char)this.ReadByte()).ToString();
			}
			return text;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002158 File Offset: 0x00000358
		public string ReadAsciiz()
		{
			string text = "";
			char c;
			while ((c = (char)this.ReadByte()) != '\0')
			{
				text += c.ToString();
			}
			return text;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002188 File Offset: 0x00000388
		private T ReadObject<T>() where T : IDeserializable, new()
		{
			T result = Activator.CreateInstance<T>();
			result.ReadObject(this);
			return result;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000021AC File Offset: 0x000003AC
		private T[] ReadArrayBase<T>(Func<BinaryReaderEx, T> readElement, int size)
		{
			T[] array = new T[size];
			for (int i = 0; i < size; i++)
			{
				array[i] = readElement(this);
			}
			return array;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x000021DB File Offset: 0x000003DB
		public T[] ReadArray<T>(Func<BinaryReaderEx, T> readElement)
		{
			return this.ReadArrayBase<T>(readElement, this.ReadInt32());
		}

		// Token: 0x06000016 RID: 22 RVA: 0x000021EA File Offset: 0x000003EA
		public T[] ReadArray<T>() where T : IDeserializable, new()
		{
			return this.ReadArray<T>((BinaryReaderEx i) => i.ReadObject<T>());
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002211 File Offset: 0x00000411
		public float[] ReadFloatArray()
		{
			return this.ReadArray<float>((BinaryReaderEx i) => i.ReadSingle());
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002238 File Offset: 0x00000438
		public int[] ReadIntArray()
		{
			return this.ReadArray<int>((BinaryReaderEx i) => i.ReadInt32());
		}

		// Token: 0x06000019 RID: 25 RVA: 0x0000225F File Offset: 0x0000045F
		public string[] ReadStringArray()
		{
			return this.ReadArray<string>((BinaryReaderEx i) => i.ReadAsciiz());
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002288 File Offset: 0x00000488
		public T[] ReadCompressedArray<T>(Func<BinaryReaderEx, T> readElement, int elemSize)
		{
			int num = this.ReadInt32();
			uint expectedSize = (uint)(num * elemSize);
			return new BinaryReaderEx(new MemoryStream(this.ReadCompressed(expectedSize))).ReadArrayBase<T>(readElement, num);
		}

		// Token: 0x0600001B RID: 27 RVA: 0x000022B8 File Offset: 0x000004B8
		public T[] ReadCompressedArray<T>(Func<BinaryReaderEx, T> readElement)
		{
			return this.ReadCompressedArray<T>(readElement, Marshal.SizeOf(typeof(T)));
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000022D0 File Offset: 0x000004D0
		public T[] ReadCompressedObjectArray<T>(int sizeOfT) where T : IDeserializable, new()
		{
			return this.ReadCompressedArray<T>((BinaryReaderEx i) => i.ReadObject<T>(), sizeOfT);
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000022F8 File Offset: 0x000004F8
		public short[] ReadCompressedShortArray()
		{
			return this.ReadCompressedArray<short>((BinaryReaderEx i) => i.ReadInt16());
		}

		// Token: 0x0600001E RID: 30 RVA: 0x0000231F File Offset: 0x0000051F
		public int[] ReadCompressedIntArray()
		{
			return this.ReadCompressedArray<int>((BinaryReaderEx i) => i.ReadInt32());
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002346 File Offset: 0x00000546
		public float[] ReadCompressedFloatArray()
		{
			return this.ReadCompressedArray<float>((BinaryReaderEx i) => i.ReadSingle());
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002370 File Offset: 0x00000570
		public T[] ReadCondensedArray<T>(Func<BinaryReaderEx, T> readElement, int sizeOfT)
		{
			int num = this.ReadInt32();
			T[] array = new T[num];
			if (this.ReadBoolean())
			{
				T t = readElement(this);
				for (int i = 0; i < num; i++)
				{
					array[i] = t;
				}
				return array;
			}
			uint expectedSize = (uint)(num * sizeOfT);
			BinaryReaderEx binaryReaderEx = new BinaryReaderEx(new MemoryStream(this.ReadCompressed(expectedSize)));
			array = binaryReaderEx.ReadArrayBase<T>(readElement, num);
			binaryReaderEx.Close();
			return array;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x000023DA File Offset: 0x000005DA
		public T[] ReadCondensedObjectArray<T>(int sizeOfT) where T : IDeserializable, new()
		{
			return this.ReadCondensedArray<T>((BinaryReaderEx i) => i.ReadObject<T>(), sizeOfT);
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002402 File Offset: 0x00000602
		public int[] ReadCondensedIntArray()
		{
			return this.ReadCondensedArray<int>((BinaryReaderEx i) => i.ReadInt32(), 4);
		}

		// Token: 0x06000023 RID: 35 RVA: 0x0000242C File Offset: 0x0000062C
		public int ReadCompactInteger()
		{
			int num = (int)this.ReadByte();
			if ((num & 128) != 0)
			{
				int num2 = (int)this.ReadByte();
				num += (num2 - 1) * 128;
			}
			return num;
		}

		// Token: 0x06000024 RID: 36 RVA: 0x0000245D File Offset: 0x0000065D
		public byte[] ReadCompressed(uint expectedSize)
		{
			if (expectedSize == 0u)
			{
				return new byte[0];
			}
			if (this.UseLZOCompression)
			{
				return this.ReadLZO(expectedSize);
			}
			return this.ReadLZSS(expectedSize, false);
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002484 File Offset: 0x00000684
		public byte[] ReadLZO(uint expectedSize)
		{
			bool flag = expectedSize >= 1024u;
			if (this.UseCompressionFlag)
			{
				flag = this.ReadBoolean();
			}
			if (!flag)
			{
				return this.ReadBytes((int)expectedSize);
			}
			return LZO.readLZO(this.BaseStream, expectedSize);
		}

		// Token: 0x06000026 RID: 38 RVA: 0x000024C4 File Offset: 0x000006C4
		public byte[] ReadLZSS(uint expectedSize, bool inPAA = false)
		{
			if (expectedSize < 1024u && !inPAA)
			{
				return this.ReadBytes((int)expectedSize);
			}
			byte[] result = new byte[expectedSize];
			LZSS.readLZSS(this.BaseStream, out result, expectedSize, inPAA);
			return result;
		}

		// Token: 0x06000027 RID: 39 RVA: 0x000024FC File Offset: 0x000006FC
		public byte[] ReadCompressedIndices(int bytesToRead, uint expectedSize)
		{
			byte[] array = new byte[expectedSize];
			int num = 0;
			for (int i = 0; i < bytesToRead; i++)
			{
				byte b = this.ReadByte();
				if ((b & 128) != 0)
				{
					byte b2 = b - 127;
					byte b3 = this.ReadByte();
					for (int j = 0; j < (int)b2; j++)
					{
						array[num++] = b3;
					}
				}
				else
				{
					for (int k = 0; k < (int)(b + 1); k++)
					{
						array[num++] = this.ReadByte();
					}
				}
			}
			return array;
		}

		// Token: 0x06000028 RID: 40 RVA: 0x0000257C File Offset: 0x0000077C
		public uint skipGridCompressed()
		{
			long position = this.Position;
			ushort num = this.ReadUInt16();
			for (int i = 0; i < 16; i++)
			{
				if ((num & 1) == 1)
				{
					this.skipGridCompressed();
				}
				else
				{
					this.Position += 4L;
				}
				num = (ushort)(num >> 1);
			}
			return (uint)(this.Position - position);
		}
	}
}
