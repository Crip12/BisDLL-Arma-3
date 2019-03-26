using System;
using System.Collections.Generic;
using System.Linq;
using BisDll.Common.Math;
using BisDll.Stream;

namespace BisDll.Model.MLOD
{
	// Token: 0x02000030 RID: 48
	public class MLOD_LOD : P3D_LOD
	{
		// Token: 0x06000177 RID: 375 RVA: 0x00003A80 File Offset: 0x00001C80
		public MLOD_LOD()
		{
		}

		// Token: 0x06000178 RID: 376 RVA: 0x000059A2 File Offset: 0x00003BA2
		public MLOD_LOD(float resolution)
		{
			this.resolution = resolution;
		}

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x06000179 RID: 377 RVA: 0x000059B1 File Offset: 0x00003BB1
		public override Vector3P[] Points
		{
			get
			{
				return this.points;
			}
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x0600017A RID: 378 RVA: 0x000059B9 File Offset: 0x00003BB9
		public override Vector3P[] Normals
		{
			get
			{
				return this.normals;
			}
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x0600017B RID: 379 RVA: 0x000059C1 File Offset: 0x00003BC1
		public override string[] Textures
		{
			get
			{
				return (from f in this.faces
				select f.Texture).Distinct<string>().ToArray<string>();
			}
		}

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x0600017C RID: 380 RVA: 0x000059F7 File Offset: 0x00003BF7
		public override string[] MaterialNames
		{
			get
			{
				return (from f in this.faces
				select f.Material).Distinct<string>().ToArray<string>();
			}
		}

		// Token: 0x0600017D RID: 381 RVA: 0x00005A30 File Offset: 0x00003C30
		private Tagg readTagg(BinaryReaderEx input)
		{
			Tagg tagg = new MassTagg();
			if (!input.ReadBoolean())
			{
				throw new Exception("Deactivated Tagg?");
			}
			tagg.Name = input.ReadAsciiz();
			tagg.DataSize = input.ReadUInt32();
			string name = tagg.Name;
			uint num = <PrivateImplementationDetails>.ComputeStringHash(name);
			if (num <= 1022465937u)
			{
				if (num <= 449865672u)
				{
					if (num != 334716037u)
					{
						if (num == 449865672u)
						{
							if (name == "#Selected#")
							{
								SelectedTagg selectedTagg = new SelectedTagg();
								selectedTagg.Name = "#Selected#";
								selectedTagg.DataSize = tagg.DataSize;
								selectedTagg.read(input, this.Points.Length, this.faces.Length);
								return selectedTagg;
							}
						}
					}
					else if (name == "#EndOfFile#")
					{
						return tagg;
					}
				}
				else if (num != 970158452u)
				{
					if (num == 1022465937u)
					{
						if (name == "#SharpEdges#")
						{
							SharpEdgesTagg sharpEdgesTagg = new SharpEdgesTagg();
							sharpEdgesTagg.Name = "#SharpEdges#";
							sharpEdgesTagg.DataSize = tagg.DataSize;
							sharpEdgesTagg.read(input);
							return sharpEdgesTagg;
						}
					}
				}
				else if (name == "#UVSet#")
				{
					UVSetTagg uvsetTagg = new UVSetTagg();
					uvsetTagg.Name = "#UVSet#";
					uvsetTagg.DataSize = tagg.DataSize;
					uvsetTagg.read(input, this.faces);
					return uvsetTagg;
				}
			}
			else if (num <= 1836498403u)
			{
				if (num != 1450797708u)
				{
					if (num == 1836498403u)
					{
						if (name == "#Mass#")
						{
							MassTagg massTagg = new MassTagg();
							massTagg.Name = "#Mass#";
							massTagg.DataSize = tagg.DataSize;
							massTagg.read(input);
							return massTagg;
						}
					}
				}
				else if (name == "#Property#")
				{
					PropertyTagg propertyTagg = new PropertyTagg();
					propertyTagg.Name = "#Property#";
					propertyTagg.DataSize = tagg.DataSize;
					propertyTagg.read(input);
					return propertyTagg;
				}
			}
			else if (num != 3018140793u)
			{
				if (num == 4237887034u)
				{
					if (name == "#Lock#")
					{
						LockTagg lockTagg = new LockTagg();
						lockTagg.Name = "#Lock#";
						lockTagg.DataSize = tagg.DataSize;
						lockTagg.read(input, this.Points.Length, this.faces.Length);
						return lockTagg;
					}
				}
			}
			else if (name == "#Animation#")
			{
				AnimationTagg animationTagg = new AnimationTagg();
				animationTagg.Name = "#Animation#";
				animationTagg.DataSize = tagg.DataSize;
				animationTagg.read(input);
				return animationTagg;
			}
			NamedSelectionTagg namedSelectionTagg = new NamedSelectionTagg();
			namedSelectionTagg.Name = tagg.Name;
			namedSelectionTagg.DataSize = tagg.DataSize;
			namedSelectionTagg.read(input, this.Points.Length, this.faces.Length);
			return namedSelectionTagg;
		}

		// Token: 0x0600017E RID: 382 RVA: 0x00005CF4 File Offset: 0x00003EF4
		private void writeTagg(BinaryWriter output, Tagg tagg)
		{
			string name = tagg.Name;
			uint num = <PrivateImplementationDetails>.ComputeStringHash(name);
			if (num <= 1022465937u)
			{
				if (num <= 449865672u)
				{
					if (num != 334716037u)
					{
						if (num == 449865672u)
						{
							if (name == "#Selected#")
							{
								((SelectedTagg)tagg).write(output);
								return;
							}
						}
					}
					else if (name == "#EndOfFile#")
					{
						return;
					}
				}
				else if (num != 970158452u)
				{
					if (num == 1022465937u)
					{
						if (name == "#SharpEdges#")
						{
							((SharpEdgesTagg)tagg).write(output);
							return;
						}
					}
				}
				else if (name == "#UVSet#")
				{
					((UVSetTagg)tagg).write(output);
					return;
				}
			}
			else if (num <= 1836498403u)
			{
				if (num != 1450797708u)
				{
					if (num == 1836498403u)
					{
						if (name == "#Mass#")
						{
							((MassTagg)tagg).write(output);
							return;
						}
					}
				}
				else if (name == "#Property#")
				{
					((PropertyTagg)tagg).write(output);
					return;
				}
			}
			else if (num != 3018140793u)
			{
				if (num == 4237887034u)
				{
					if (name == "#Lock#")
					{
						((LockTagg)tagg).write(output);
						return;
					}
				}
			}
			else if (name == "#Animation#")
			{
				((AnimationTagg)tagg).write(output);
				return;
			}
			((NamedSelectionTagg)tagg).write(output);
		}

		// Token: 0x0600017F RID: 383 RVA: 0x00005E70 File Offset: 0x00004070
		public void read(BinaryReaderEx input)
		{
			if (input.ReadAscii(4) != "P3DM")
			{
				throw new Exception("Only P3DM LODs are supported");
			}
			if (input.ReadUInt32() != 28u || input.ReadUInt32() != 256u)
			{
				throw new Exception("Unknown P3DM version");
			}
			uint num = input.ReadUInt32();
			uint num2 = input.ReadUInt32();
			uint num3 = input.ReadUInt32();
			this.unk1 = input.ReadUInt32();
			this.points = new Point[num];
			this.normals = new Vector3P[num2];
			this.faces = new Face[num3];
			int num4 = 0;
			while ((long)num4 < (long)((ulong)num))
			{
				this.points[num4] = new Point(input);
				num4++;
			}
			int num5 = 0;
			while ((long)num5 < (long)((ulong)num2))
			{
				this.normals[num5] = new Vector3P(input);
				num5++;
			}
			int num6 = 0;
			while ((long)num6 < (long)((ulong)num3))
			{
				this.faces[num6] = new Face(input);
				num6++;
			}
			if (input.ReadAscii(4) != "TAGG")
			{
				throw new Exception("TAGG expected");
			}
			this.taggs = new List<Tagg>();
			Tagg tagg;
			do
			{
				tagg = this.readTagg(input);
				if (tagg.Name != "#EndOfFile#")
				{
					this.taggs.Add(tagg);
				}
			}
			while (tagg.Name != "#EndOfFile#");
			this.resolution = input.ReadSingle();
		}

		// Token: 0x06000180 RID: 384 RVA: 0x00005FD4 File Offset: 0x000041D4
		public void write(BinaryWriter output)
		{
			int num = this.points.Length;
			int num2 = this.normals.Length;
			int num3 = this.faces.Length;
			output.writeAscii("P3DM", 4u);
			output.Write(28);
			output.Write(256);
			output.Write(num);
			output.Write(num2);
			output.Write(num3);
			output.Write(this.unk1);
			for (int i = 0; i < num; i++)
			{
				this.points[i].write(output);
			}
			for (int j = 0; j < num2; j++)
			{
				this.normals[j].write(output);
			}
			for (int k = 0; k < num3; k++)
			{
				this.faces[k].write(output);
			}
			output.writeAscii("TAGG", 4u);
			foreach (Tagg tagg in this.taggs)
			{
				this.writeTagg(output, tagg);
			}
			output.Write(true);
			output.writeAsciiz("#EndOfFile#");
			output.Write(0);
			output.Write(this.resolution);
		}

		// Token: 0x06000181 RID: 385 RVA: 0x00006110 File Offset: 0x00004310
		public float getHeight()
		{
			int num = this.Points.Length;
			if ((long)num <= 1L)
			{
				return 0f;
			}
			float num2 = float.MaxValue;
			float num3 = float.MinValue;
			for (int i = 0; i < num; i++)
			{
				float y = this.points[i].Y;
				if (y > num3)
				{
					num3 = y;
				}
				if (y < num2)
				{
					num2 = y;
				}
			}
			return num3 - num2;
		}

		// Token: 0x04000197 RID: 407
		public uint unk1;

		// Token: 0x04000198 RID: 408
		public Point[] points;

		// Token: 0x04000199 RID: 409
		public Vector3P[] normals;

		// Token: 0x0400019A RID: 410
		public Face[] faces;

		// Token: 0x0400019B RID: 411
		public List<Tagg> taggs;
	}
}
