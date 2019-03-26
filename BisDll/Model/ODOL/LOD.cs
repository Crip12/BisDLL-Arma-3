using System;
using System.Linq;
using BisDll.Common.Math;
using BisDll.Stream;

namespace BisDll.Model.ODOL
{
	// Token: 0x02000010 RID: 16
	public class LOD : P3D_LOD, IComparable<LOD>
	{
		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000057 RID: 87 RVA: 0x0000361C File Offset: 0x0000181C
		public NamedSelection[] NamedSelections
		{
			get
			{
				return this.namedSelections;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000058 RID: 88 RVA: 0x00003624 File Offset: 0x00001824
		public override string[] MaterialNames
		{
			get
			{
				return (from m in this.materials
				select m.materialName).ToArray<string>();
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000059 RID: 89 RVA: 0x00003655 File Offset: 0x00001855
		public EmbeddedMaterial[] Materials
		{
			get
			{
				return this.materials;
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600005A RID: 90 RVA: 0x0000365D File Offset: 0x0000185D
		public int VertexCount
		{
			get
			{
				return this.vertices.Length;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600005B RID: 91 RVA: 0x00003667 File Offset: 0x00001867
		public int SectionCount
		{
			get
			{
				return this.sections.Length;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600005C RID: 92 RVA: 0x00003671 File Offset: 0x00001871
		public int TextureCount
		{
			get
			{
				return this.textures.Length;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600005D RID: 93 RVA: 0x0000367B File Offset: 0x0000187B
		public int PolygonCount
		{
			get
			{
				return this.polygons.Faces.Length;
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600005E RID: 94 RVA: 0x0000368A File Offset: 0x0000188A
		public int MaterialCount
		{
			get
			{
				return this.materials.Length;
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600005F RID: 95 RVA: 0x00003694 File Offset: 0x00001894
		public AnimationRTWeight[] VertexBoneRef
		{
			get
			{
				return this.vertexBoneRef;
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000060 RID: 96 RVA: 0x0000369C File Offset: 0x0000189C
		public VertexNeighborInfo[] NeighborBoneRef
		{
			get
			{
				return this.neighborBoneRef;
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000061 RID: 97 RVA: 0x000036A4 File Offset: 0x000018A4
		public ClipFlags[] ClipFlags
		{
			get
			{
				if (this.odolVersion < 50u)
				{
					return this.clipOldFormat;
				}
				return this.clip;
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000062 RID: 98 RVA: 0x000036BD File Offset: 0x000018BD
		public Vector3P[] Vertices
		{
			get
			{
				return this.vertices;
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000063 RID: 99 RVA: 0x000036C5 File Offset: 0x000018C5
		public override Vector3P[] Normals
		{
			get
			{
				return this.normals;
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000064 RID: 100 RVA: 0x000036CD File Offset: 0x000018CD
		public Section[] Sections
		{
			get
			{
				return this.sections;
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000065 RID: 101 RVA: 0x000036D5 File Offset: 0x000018D5
		public UVSet[] UVSets
		{
			get
			{
				return this.uvSets;
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000066 RID: 102 RVA: 0x000036DD File Offset: 0x000018DD
		public Polygon[] Faces
		{
			get
			{
				return this.polygons.Faces;
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000067 RID: 103 RVA: 0x000036EA File Offset: 0x000018EA
		public string[,] NamedProperties
		{
			get
			{
				return this.namedProperties;
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000068 RID: 104 RVA: 0x000036F2 File Offset: 0x000018F2
		public Keyframe[] Frames
		{
			get
			{
				return this.frames;
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000069 RID: 105 RVA: 0x000036FA File Offset: 0x000018FA
		public int[] SubSkeletonsToSkeleton
		{
			get
			{
				return this.subSkeletonsToSkeleton;
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x0600006A RID: 106 RVA: 0x00003702 File Offset: 0x00001902
		public Proxy[] Proxies
		{
			get
			{
				return this.proxies;
			}
		}

		// Token: 0x0600006B RID: 107 RVA: 0x0000370C File Offset: 0x0000190C
		public void read(BinaryReaderEx input, float resolution)
		{
			this.odolVersion = (uint)input.Version;
			this.resolution = resolution;
			this.proxies = input.ReadArray<Proxy>();
			this.subSkeletonsToSkeleton = input.ReadIntArray();
			this.skeletonToSubSkeleton = input.ReadArray<SubSkeletonIndexSet>();
			if (this.odolVersion >= 50u)
			{
				this.vertexCount = input.ReadUInt32();
			}
			else
			{
				int[] array = input.ReadCondensedIntArray();
				this.clipOldFormat = Array.ConvertAll<int, ClipFlags>(array, (int item) => (ClipFlags)item);
			}
			if (this.odolVersion >= 51u)
			{
				this.faceArea = input.ReadSingle();
			}
			this.orHints = (ClipFlags)input.ReadInt32();
			this.andHints = (ClipFlags)input.ReadInt32();
			this.bMin = new Vector3P(input);
			this.bMax = new Vector3P(input);
			this.bCenter = new Vector3P(input);
			this.bRadius = input.ReadSingle();
			this.textures = input.ReadStringArray();
			this.materials = input.ReadArray<EmbeddedMaterial>();
			this.pointToVertex = input.ReadCompressedVertexIndexArray();
			this.vertexToPoint = input.ReadCompressedVertexIndexArray();
			this.polygons = new Polygons(input);
			this.sections = input.ReadArray<Section>();
			this.namedSelections = input.ReadArray<NamedSelection>();
			this.nNamedProperties = input.ReadUInt32();
			this.namedProperties = new string[(int)this.nNamedProperties, 2];
			int num = 0;
			while ((long)num < (long)((ulong)this.nNamedProperties))
			{
				this.namedProperties[num, 0] = input.ReadAsciiz();
				this.namedProperties[num, 1] = input.ReadAsciiz();
				num++;
			}
			this.frames = input.ReadArray<Keyframe>();
			this.colorTop = input.ReadInt32();
			this.color = input.ReadInt32();
			this.special = input.ReadInt32();
			this.vertexBoneRefIsSimple = input.ReadBoolean();
			this.sizeOfRestData = input.ReadUInt32();
			if (this.odolVersion >= 50u)
			{
				int[] array2 = input.ReadCondensedIntArray();
				this.clip = Array.ConvertAll<int, ClipFlags>(array2, (int item) => (ClipFlags)item);
			}
			UVSet uvset = new UVSet();
			uvset.read(input, this.odolVersion);
			this.nUVSets = input.ReadUInt32();
			this.uvSets = new UVSet[this.nUVSets];
			this.uvSets[0] = uvset;
			int num2 = 1;
			while ((long)num2 < (long)((ulong)this.nUVSets))
			{
				this.uvSets[num2] = new UVSet();
				this.uvSets[num2].read(input, this.odolVersion);
				num2++;
			}
			this.vertices = input.ReadCompressedObjectArray<Vector3P>(12);
			if (this.odolVersion >= 45u)
			{
				Vector3PCompressed[] array3 = input.ReadCondensedObjectArray<Vector3PCompressed>(4);
				this.normals = Array.ConvertAll<Vector3PCompressed, Vector3P>(array3, (Vector3PCompressed item) => item);
			}
			else
			{
				this.normals = input.ReadCondensedObjectArray<Vector3P>(12);
			}
			this.STCoords = ((this.odolVersion >= 45u) ? input.ReadCompressedObjectArray<STPairCompressed>(8) : input.ReadCompressedObjectArray<STPairUncompressed>(24));
			this.vertexBoneRef = input.ReadCompressedObjectArray<AnimationRTWeight>(12);
			this.neighborBoneRef = input.ReadCompressedObjectArray<VertexNeighborInfo>(32);
			if (this.odolVersion >= 67u)
			{
				input.ReadUInt32();
			}
			if (this.odolVersion >= 68u)
			{
				input.ReadByte();
			}
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00003A56 File Offset: 0x00001C56
		public void write(BinaryWriter output)
		{
			throw new NotImplementedException();
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x0600006D RID: 109 RVA: 0x00003A5D File Offset: 0x00001C5D
		public override Vector3P[] Points
		{
			get
			{
				return this.Vertices;
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x0600006E RID: 110 RVA: 0x00003A65 File Offset: 0x00001C65
		public override string[] Textures
		{
			get
			{
				return this.textures;
			}
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00003A6D File Offset: 0x00001C6D
		public int CompareTo(LOD other)
		{
			return this.resolution.CompareTo(other.resolution);
		}

		// Token: 0x0400006A RID: 106
		private uint odolVersion;

		// Token: 0x0400006B RID: 107
		private Proxy[] proxies;

		// Token: 0x0400006C RID: 108
		private int[] subSkeletonsToSkeleton;

		// Token: 0x0400006D RID: 109
		private SubSkeletonIndexSet[] skeletonToSubSkeleton;

		// Token: 0x0400006E RID: 110
		private uint vertexCount;

		// Token: 0x0400006F RID: 111
		private float faceArea;

		// Token: 0x04000070 RID: 112
		private ClipFlags[] clipOldFormat;

		// Token: 0x04000071 RID: 113
		private ClipFlags[] clip;

		// Token: 0x04000072 RID: 114
		private ClipFlags orHints;

		// Token: 0x04000073 RID: 115
		private ClipFlags andHints;

		// Token: 0x04000074 RID: 116
		private Vector3P bMin;

		// Token: 0x04000075 RID: 117
		private Vector3P bMax;

		// Token: 0x04000076 RID: 118
		private Vector3P bCenter;

		// Token: 0x04000077 RID: 119
		private float bRadius;

		// Token: 0x04000078 RID: 120
		private string[] textures;

		// Token: 0x04000079 RID: 121
		private EmbeddedMaterial[] materials;

		// Token: 0x0400007A RID: 122
		private VertexIndex[] pointToVertex;

		// Token: 0x0400007B RID: 123
		private VertexIndex[] vertexToPoint;

		// Token: 0x0400007C RID: 124
		private Polygons polygons;

		// Token: 0x0400007D RID: 125
		private Section[] sections;

		// Token: 0x0400007E RID: 126
		private NamedSelection[] namedSelections;

		// Token: 0x0400007F RID: 127
		private uint nNamedProperties;

		// Token: 0x04000080 RID: 128
		private string[,] namedProperties;

		// Token: 0x04000081 RID: 129
		private Keyframe[] frames;

		// Token: 0x04000082 RID: 130
		private int colorTop;

		// Token: 0x04000083 RID: 131
		private int color;

		// Token: 0x04000084 RID: 132
		private int special;

		// Token: 0x04000085 RID: 133
		private bool vertexBoneRefIsSimple;

		// Token: 0x04000086 RID: 134
		private uint sizeOfRestData;

		// Token: 0x04000087 RID: 135
		private uint nUVSets;

		// Token: 0x04000088 RID: 136
		private UVSet[] uvSets;

		// Token: 0x04000089 RID: 137
		private Vector3P[] vertices;

		// Token: 0x0400008A RID: 138
		private Vector3P[] normals;

		// Token: 0x0400008B RID: 139
		private STPair[] STCoords;

		// Token: 0x0400008C RID: 140
		private AnimationRTWeight[] vertexBoneRef;

		// Token: 0x0400008D RID: 141
		private VertexNeighborInfo[] neighborBoneRef;

		// Token: 0x02000055 RID: 85
		private struct PointWeight
		{
			// Token: 0x06000266 RID: 614 RVA: 0x0000918B File Offset: 0x0000738B
			public PointWeight(int index, byte weight)
			{
				this.pointIndex = index;
				this.weight = weight;
			}

			// Token: 0x0400020E RID: 526
			public int pointIndex;

			// Token: 0x0400020F RID: 527
			public byte weight;
		}
	}
}
