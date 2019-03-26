using System;
using System.IO;
using BisDll.Stream;

namespace BisDll.Model.MLOD
{
	// Token: 0x02000031 RID: 49
	public class MLOD : P3D
	{
		// Token: 0x17000096 RID: 150
		// (get) Token: 0x06000182 RID: 386 RVA: 0x0000616C File Offset: 0x0000436C
		public override P3D_LOD[] LODs
		{
			get
			{
				return this.lods;
			}
		}

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x06000183 RID: 387 RVA: 0x00003A56 File Offset: 0x00001C56
		public override float Mass
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x06000184 RID: 388 RVA: 0x00006174 File Offset: 0x00004374
		public MLOD(string fileName)
		{
			byte[] array = File.ReadAllBytes(fileName);
			BinaryReaderEx binaryReaderEx = new BinaryReaderEx(new MemoryStream(array, 0, array.Length, false, true));
			this.read(binaryReaderEx);
			binaryReaderEx.Close();
		}

		// Token: 0x06000185 RID: 389 RVA: 0x000061AD File Offset: 0x000043AD
		public MLOD(Stream stream)
		{
			this.read(new BinaryReaderEx(stream));
		}

		// Token: 0x06000186 RID: 390 RVA: 0x000061C1 File Offset: 0x000043C1
		public MLOD(MLOD_LOD[] lods)
		{
			this.lods = lods;
		}

		// Token: 0x06000187 RID: 391 RVA: 0x000061D0 File Offset: 0x000043D0
		private void read(BinaryReaderEx input)
		{
			if (input.ReadAscii(4) != "MLOD")
			{
				throw new Exception("MLOD signature expected");
			}
			base.Version = input.ReadUInt32();
			if (base.Version != 257u)
			{
				throw new Exception("Unknown MLOD version");
			}
			uint num = input.ReadUInt32();
			this.lods = new MLOD_LOD[num];
			int num2 = 0;
			while ((long)num2 < (long)((ulong)num))
			{
				this.lods[num2] = new MLOD_LOD();
				this.lods[num2].read(input);
				num2++;
			}
		}

		// Token: 0x06000188 RID: 392 RVA: 0x0000625C File Offset: 0x0000445C
		private void write(BisDll.Stream.BinaryWriter output)
		{
			output.writeAscii("MLOD", 4u);
			output.Write(257);
			output.Write(this.lods.Length);
			for (int i = 0; i < this.lods.Length; i++)
			{
				this.lods[i].write(output);
			}
		}

		// Token: 0x06000189 RID: 393 RVA: 0x000062B0 File Offset: 0x000044B0
		public void writeToFile(string file, bool allowOverwriting = false)
		{
			FileMode mode = allowOverwriting ? FileMode.Create : FileMode.CreateNew;
			BisDll.Stream.BinaryWriter binaryWriter = new BisDll.Stream.BinaryWriter(new FileStream(file, mode));
			this.write(binaryWriter);
			binaryWriter.Close();
		}

		// Token: 0x0600018A RID: 394 RVA: 0x000062E0 File Offset: 0x000044E0
		public MemoryStream writeToMemory()
		{
			MemoryStream memoryStream = new MemoryStream(100000);
			BisDll.Stream.BinaryWriter binaryWriter = new BisDll.Stream.BinaryWriter(memoryStream);
			this.write(binaryWriter);
			binaryWriter.Position = 0L;
			return memoryStream;
		}

		// Token: 0x0600018B RID: 395 RVA: 0x00006310 File Offset: 0x00004510
		public void writeToStream(Stream stream)
		{
			BisDll.Stream.BinaryWriter output = new BisDll.Stream.BinaryWriter(stream);
			this.write(output);
		}

		// Token: 0x0400019C RID: 412
		private MLOD_LOD[] lods;
	}
}
