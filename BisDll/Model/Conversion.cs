using System;
using System.Collections.Generic;
using System.Linq;
using BisDll.Common.Math;
using BisDll.Model.MLOD;
using BisDll.Model.ODOL;

namespace BisDll.Model
{
	// Token: 0x02000006 RID: 6
	public static class Conversion
	{
		// Token: 0x0600002E RID: 46 RVA: 0x00002644 File Offset: 0x00000844
		private static PointFlags clipFlagsToPointFlags(ClipFlags clipFlags)
		{
			PointFlags pointFlags = PointFlags.NONE;
			if ((clipFlags & ClipFlags.ClipLandStep) != ClipFlags.ClipNone)
			{
				pointFlags |= PointFlags.ONLAND;
			}
			else if ((clipFlags & ClipFlags.ClipLandUnder) != ClipFlags.ClipNone)
			{
				pointFlags |= PointFlags.UNDERLAND;
			}
			else if ((clipFlags & ClipFlags.ClipLandAbove) != ClipFlags.ClipNone)
			{
				pointFlags |= PointFlags.ABOVELAND;
			}
			else if ((clipFlags & ClipFlags.ClipLandKeep) != ClipFlags.ClipNone)
			{
				pointFlags |= PointFlags.KEEPLAND;
			}
			if ((clipFlags & ClipFlags.ClipDecalStep) != ClipFlags.ClipNone)
			{
				pointFlags |= PointFlags.DECAL;
			}
			else if ((clipFlags & ClipFlags.ClipDecalVertical) != ClipFlags.ClipNone)
			{
				pointFlags |= PointFlags.VDECAL;
			}
			if ((clipFlags & (ClipFlags)209715200) != ClipFlags.ClipNone)
			{
				pointFlags |= PointFlags.NOLIGHT;
			}
			else if ((clipFlags & (ClipFlags)212860928) != ClipFlags.ClipNone)
			{
				pointFlags |= PointFlags.FULLLIGHT;
			}
			else if ((clipFlags & (ClipFlags)211812352) != ClipFlags.ClipNone)
			{
				pointFlags |= PointFlags.HALFLIGHT;
			}
			else if ((clipFlags & (ClipFlags)210763776) != ClipFlags.ClipNone)
			{
				pointFlags |= PointFlags.AMBIENT;
			}
			if ((clipFlags & ClipFlags.ClipFogStep) != ClipFlags.ClipNone)
			{
				pointFlags |= PointFlags.NOFOG;
			}
			else if ((clipFlags & ClipFlags.ClipFogSky) != ClipFlags.ClipNone)
			{
				pointFlags |= PointFlags.SKYFOG;
			}
			int num = (int)((clipFlags & ClipFlags.ClipUserMask) / ClipFlags.ClipUserStep);
			return pointFlags | (PointFlags)(65536 * num);
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00002730 File Offset: 0x00000930
		public static MLOD ODOL2MLOD(ODOL odol)
		{
			P3D_LOD[] lods = odol.LODs;
			int num = lods.Length;
			MLOD_LOD[] array = new MLOD_LOD[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = Conversion.OdolLod2MLOD(odol, (LOD)lods[i]);
			}
			return new MLOD(array);
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00002774 File Offset: 0x00000974
		private static MLOD_LOD OdolLod2MLOD(ODOL odol, LOD src)
		{
			MLOD_LOD mlod_LOD = new MLOD_LOD(src.Resolution);
			int vertexCount = src.VertexCount;
			Conversion.ConvertPoints(odol, mlod_LOD, src);
			mlod_LOD.normals = src.Normals;
			Conversion.ConvertFaces(odol, mlod_LOD, src);
			float mass = odol.modelInfo.mass;
			Skeleton skeleton = odol.Skeleton;
			mlod_LOD.taggs = new List<Tagg>();
			if (src.Resolution == 1E+13f)
			{
				MassTagg item = Conversion.createMassTagg(vertexCount, mass);
				mlod_LOD.taggs.Add(item);
			}
			IEnumerable<UVSetTagg> collection = Conversion.createUVSetTaggs(src);
			mlod_LOD.taggs.AddRange(collection);
			IEnumerable<PropertyTagg> collection2 = Conversion.createPropertyTaggs(src);
			mlod_LOD.taggs.AddRange(collection2);
			IEnumerable<NamedSelectionTagg> collection3 = Conversion.createNamedSelectionTaggs(src);
			mlod_LOD.taggs.AddRange(collection3);
			IEnumerable<AnimationTagg> collection4 = Conversion.createAnimTaggs(src);
			mlod_LOD.taggs.AddRange(collection4);
			if (Resolution.KeepsNamedSelections(src.Resolution))
			{
				return mlod_LOD;
			}
			Dictionary<string, List<Conversion.PointWeight>> nsPoints = new Dictionary<string, List<Conversion.PointWeight>>();
			Dictionary<string, List<int>> nsFaces = new Dictionary<string, List<int>>();
			Conversion.ReconstructNamedSelectionBySections(src, out nsPoints, out nsFaces);
			Dictionary<string, List<Conversion.PointWeight>> nsPoints2 = new Dictionary<string, List<Conversion.PointWeight>>();
			Dictionary<string, List<int>> nsFaces2 = new Dictionary<string, List<int>>();
			Conversion.ReconstructProxies(src, out nsPoints2, out nsFaces2);
			Dictionary<string, List<Conversion.PointWeight>> nsPoints3 = new Dictionary<string, List<Conversion.PointWeight>>();
			Conversion.ReconstructNamedSelectionsByBones(src, odol.Skeleton, out nsPoints3);
			Conversion.ApplySelectedPointsAndFaces(mlod_LOD, nsPoints, nsFaces);
			Conversion.ApplySelectedPointsAndFaces(mlod_LOD, nsPoints2, nsFaces2);
			Conversion.ApplySelectedPointsAndFaces(mlod_LOD, nsPoints3, null);
			return mlod_LOD;
		}

		// Token: 0x06000031 RID: 49 RVA: 0x000028B8 File Offset: 0x00000AB8
		private static void ApplySelectedPointsAndFaces(MLOD_LOD dstLod, Dictionary<string, List<Conversion.PointWeight>> nsPoints, Dictionary<string, List<int>> nsFaces)
		{
			foreach (Tagg tagg in dstLod.taggs)
			{
				if (tagg is NamedSelectionTagg)
				{
					NamedSelectionTagg namedSelectionTagg = tagg as NamedSelectionTagg;
					List<Conversion.PointWeight> list;
					if (nsPoints != null && nsPoints.TryGetValue(namedSelectionTagg.Name, out list))
					{
						foreach (Conversion.PointWeight pointWeight in list)
						{
							byte b = -pointWeight.weight;
							if (b != 0)
							{
								namedSelectionTagg.points[pointWeight.pointIndex] = b;
							}
						}
					}
					List<int> list2;
					if (nsFaces != null && nsFaces.TryGetValue(namedSelectionTagg.Name, out list2))
					{
						foreach (int num in list2)
						{
							namedSelectionTagg.faces[num] = 1;
						}
					}
				}
			}
		}

		// Token: 0x06000032 RID: 50 RVA: 0x000029DC File Offset: 0x00000BDC
		private static void ConvertPoints(ODOL odol, MLOD_LOD dstLod, LOD srcLod)
		{
			Vector3P boundingCenter = odol.modelInfo.boundingCenter;
			Vector3P bboxMinVisual = odol.modelInfo.bboxMinVisual;
			Vector3P bboxMaxVisual = odol.modelInfo.bboxMaxVisual;
			int num = srcLod.Vertices.Length;
			dstLod.points = new Point[num];
			for (int i = 0; i < num; i++)
			{
				Vector3P pos = srcLod.Vertices[i] + boundingCenter;
				dstLod.points[i] = new Point(pos, Conversion.clipFlagsToPointFlags(srcLod.ClipFlags[i]));
			}
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00002A58 File Offset: 0x00000C58
		private static void ConvertFaces(ODOL odol, MLOD_LOD dstLod, LOD srcLOD)
		{
			List<Face> list = new List<Face>(srcLOD.VertexCount * 2);
			foreach (Section section in srcLOD.Sections)
			{
				float[] uvdata = srcLOD.UVSets[0].UVData;
				foreach (uint num in section.getFaceIndexes(srcLOD.Faces))
				{
					int num2 = srcLOD.Faces[(int)num].VertexIndices.Length;
					Vertex[] array = new Vertex[num2];
					for (int k = 0; k < num2; k++)
					{
						int num3 = srcLOD.Faces[(int)num].VertexIndices[num2 - 1 - k];
						array[k] = new Vertex(num3, num3, uvdata[num3 * 2], uvdata[num3 * 2 + 1]);
					}
					string texture = (section.textureIndex == -1) ? "" : srcLOD.Textures[(int)section.textureIndex];
					string material = (section.materialIndex == -1) ? "" : srcLOD.Materials[section.materialIndex].materialName;
					Face item = new Face(num2, array, FaceFlags.DEFAULT, texture, material);
					list.Add(item);
				}
			}
			dstLod.faces = list.ToArray();
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00002BA4 File Offset: 0x00000DA4
		private static void ReconstructNamedSelectionBySections(LOD src, out Dictionary<string, List<Conversion.PointWeight>> points, out Dictionary<string, List<int>> faces)
		{
			points = new Dictionary<string, List<Conversion.PointWeight>>(src.NamedSelections.Length * 2);
			faces = new Dictionary<string, List<int>>(src.NamedSelections.Length * 2);
			Func<int, IEnumerable<uint>> <>9__0;
			Func<uint, IEnumerable<VertexIndex>> <>9__1;
			foreach (NamedSelection namedSelection in src.NamedSelections)
			{
				if (namedSelection.IsSectional)
				{
					IEnumerable<int> sections = namedSelection.Sections;
					Func<int, IEnumerable<uint>> selector;
					if ((selector = <>9__0) == null)
					{
						selector = (<>9__0 = ((int si) => src.Sections[si].getFaceIndexes(src.Faces)));
					}
					IEnumerable<uint> enumerable = sections.SelectMany(selector);
					IEnumerable<uint> source = enumerable;
					Func<uint, IEnumerable<VertexIndex>> selector2;
					if ((selector2 = <>9__1) == null)
					{
						selector2 = (<>9__1 = ((uint fi) => src.Faces[(int)fi].VertexIndices));
					}
					IEnumerable<Conversion.PointWeight> source2 = from vi in source.SelectMany(selector2)
					select new Conversion.PointWeight(vi, byte.MaxValue);
					faces[namedSelection.Name] = (from fi in enumerable
					select (int)fi).ToList<int>();
					points[namedSelection.Name] = source2.ToList<Conversion.PointWeight>();
				}
			}
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00002CE4 File Offset: 0x00000EE4
		private static void ReconstructProxies(LOD src, out Dictionary<string, List<Conversion.PointWeight>> points, out Dictionary<string, List<int>> faces)
		{
			points = new Dictionary<string, List<Conversion.PointWeight>>(src.NamedSelections.Length * 2);
			faces = new Dictionary<string, List<int>>(src.NamedSelections.Length * 2);
			for (int i = 0; i < src.Faces.Length; i++)
			{
				Polygon polygon = src.Faces[i];
				if (polygon.VertexIndices.Length == 3)
				{
					VertexIndex vi = polygon.VertexIndices[0];
					VertexIndex vi2 = polygon.VertexIndices[1];
					VertexIndex vi3 = polygon.VertexIndices[2];
					Vector3P vector3P = src.Vertices[vi];
					Vector3P vector3P2 = src.Vertices[vi2];
					Vector3P vector3P3 = src.Vertices[vi3];
					float num = vector3P.Distance(vector3P2);
					float num2 = vector3P.Distance(vector3P3);
					float num3 = vector3P2.Distance(vector3P3);
					if (num > num2)
					{
						Methods.Swap<Vector3P>(ref vector3P2, ref vector3P3);
						Methods.Swap<float>(ref num, ref num2);
					}
					if (num > num3)
					{
						Methods.Swap<Vector3P>(ref vector3P, ref vector3P3);
						Methods.Swap<float>(ref num, ref num3);
					}
					if (num2 > num3)
					{
						Methods.Swap<Vector3P>(ref vector3P, ref vector3P2);
						Methods.Swap<float>(ref num2, ref num3);
					}
					Vector3P vector3P4 = vector3P;
					Vector3P vector3P5 = vector3P2 - vector3P;
					Vector3P vector3P6 = vector3P3 - vector3P;
					vector3P5.Normalize();
					vector3P6.Normalize();
					if (Methods.EqualsFloat(vector3P6 * vector3P5, 0f, 0.05f))
					{
						for (int j = 0; j < src.Proxies.Length; j++)
						{
							Vector3P position = src.Proxies[j].transformation.Position;
							Vector3P up = src.Proxies[j].transformation.Orientation.Up;
							Vector3P dir = src.Proxies[j].transformation.Orientation.Dir;
							if (vector3P4.Equals(position) && vector3P5.Equals(dir) && vector3P6.Equals(up))
							{
								Proxy proxy = src.Proxies[j];
								string name = src.NamedSelections[proxy.namedSelectionIndex].Name;
								if (!faces.ContainsKey(name))
								{
									faces[name] = i.Yield<int>().ToList<int>();
									points[name] = Methods.Yield<Conversion.PointWeight>(new Conversion.PointWeight[]
									{
										new Conversion.PointWeight(vi, byte.MaxValue),
										new Conversion.PointWeight(vi2, byte.MaxValue),
										new Conversion.PointWeight(vi3, byte.MaxValue)
									}).ToList<Conversion.PointWeight>();
									break;
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00002F78 File Offset: 0x00001178
		private static void ReconstructNamedSelectionsByBones(LOD src, Skeleton skeleton, out Dictionary<string, List<Conversion.PointWeight>> points)
		{
			points = new Dictionary<string, List<Conversion.PointWeight>>(src.NamedSelections.Length * 2);
			if (src.VertexBoneRef.Length != 0)
			{
				ushort num = 0;
				AnimationRTWeight[] vertexBoneRef = src.VertexBoneRef;
				for (int i = 0; i < vertexBoneRef.Length; i++)
				{
					foreach (AnimationRTPair animationRTPair in vertexBoneRef[i].AnimationRTPairs)
					{
						byte selectionIndex = animationRTPair.SelectionIndex;
						byte weight = animationRTPair.Weight;
						int num2 = src.SubSkeletonsToSkeleton[(int)selectionIndex];
						string key = skeleton.bones[num2 * 2];
						Conversion.PointWeight item = new Conversion.PointWeight((int)num, weight);
						List<Conversion.PointWeight> list;
						if (!points.TryGetValue(key, out list))
						{
							list = new List<Conversion.PointWeight>(10000);
							list.Add(item);
							points[key] = list;
						}
						else
						{
							list.Add(item);
						}
					}
					num += 1;
				}
			}
		}

		// Token: 0x06000037 RID: 55 RVA: 0x0000304C File Offset: 0x0000124C
		private static IEnumerable<NamedSelectionTagg> createNamedSelectionTaggs(LOD src)
		{
			int nPoints = src.VertexCount;
			int nFaces = src.Faces.Length;
			foreach (NamedSelection namedSelection in src.NamedSelections)
			{
				NamedSelectionTagg namedSelectionTagg = new NamedSelectionTagg();
				namedSelectionTagg.Name = namedSelection.Name;
				namedSelectionTagg.DataSize = (uint)(nPoints + nFaces);
				namedSelectionTagg.points = new byte[nPoints];
				namedSelectionTagg.faces = new byte[nFaces];
				bool flag = namedSelection.SelectedVerticesWeights.Length != 0;
				int num = 0;
				VertexIndex[] array2 = namedSelection.SelectedVertices;
				for (int j = 0; j < array2.Length; j++)
				{
					int num2 = array2[j];
					byte b = flag ? (-namedSelection.SelectedVerticesWeights[num++]) : 1;
					namedSelectionTagg.points[num2] = b;
				}
				array2 = namedSelection.SelectedFaces;
				for (int j = 0; j < array2.Length; j++)
				{
					int num3 = array2[j];
					namedSelectionTagg.faces[num3] = 1;
				}
				yield return namedSelectionTagg;
			}
			NamedSelection[] array = null;
			yield break;
		}

		// Token: 0x06000038 RID: 56 RVA: 0x0000305C File Offset: 0x0000125C
		private static IEnumerable<AnimationTagg> createAnimTaggs(LOD src)
		{
			foreach (Keyframe keyframe in src.Frames)
			{
				int num = keyframe.points.Length;
				AnimationTagg animationTagg = new AnimationTagg();
				animationTagg.Name = "#Animation#";
				animationTagg.DataSize = (uint)(num * 12 + 4);
				animationTagg.frameTime = keyframe.time;
				animationTagg.framePoints = new Vector3P[num];
				Array.Copy(keyframe.points, animationTagg.framePoints, num);
				yield return animationTagg;
			}
			Keyframe[] array = null;
			yield break;
		}

		// Token: 0x06000039 RID: 57 RVA: 0x0000306C File Offset: 0x0000126C
		private static MassTagg createMassTagg(int nPoints, float totalMass)
		{
			MassTagg massTagg = new MassTagg();
			massTagg.Name = "#Mass#";
			massTagg.DataSize = (uint)(nPoints * 4);
			massTagg.mass = new float[nPoints];
			for (int i = 0; i < nPoints; i++)
			{
				massTagg.mass[i] = totalMass / (float)nPoints;
			}
			return massTagg;
		}

		// Token: 0x0600003A RID: 58 RVA: 0x000030B8 File Offset: 0x000012B8
		private static IEnumerable<UVSetTagg> createUVSetTaggs(LOD src)
		{
			int nFaces = src.Faces.Length;
			int num3;
			for (int i = 0; i < src.UVSets.Length; i = num3)
			{
				UVSetTagg uvsetTagg = new UVSetTagg();
				uvsetTagg.Name = "#UVSet#";
				uvsetTagg.uvSetNr = (uint)i;
				uvsetTagg.faceUVs = new float[nFaces][,];
				float[] uvdata = src.UVSets[i].UVData;
				uint num = 4u;
				for (int j = 0; j < nFaces; j++)
				{
					Polygon polygon = src.Faces[j];
					int num2 = polygon.VertexIndices.Length;
					uvsetTagg.faceUVs[j] = new float[num2, 2];
					for (int k = 0; k < num2; k++)
					{
						VertexIndex vi = polygon.VertexIndices[num2 - 1 - k];
						uvsetTagg.faceUVs[j][k, 0] = uvdata[vi * 2];
						uvsetTagg.faceUVs[j][k, 1] = uvdata[vi * 2 + 1];
						num += 8u;
					}
				}
				uvsetTagg.DataSize = num;
				yield return uvsetTagg;
				num3 = i + 1;
			}
			yield break;
		}

		// Token: 0x0600003B RID: 59 RVA: 0x000030C8 File Offset: 0x000012C8
		private static IEnumerable<PropertyTagg> createPropertyTaggs(LOD src)
		{
			int num;
			for (int i = 0; i < src.NamedProperties.Length / 2; i = num)
			{
				yield return new PropertyTagg
				{
					Name = "#Property#",
					DataSize = 128u,
					name = src.NamedProperties[i, 0],
					value = src.NamedProperties[i, 1]
				};
				num = i + 1;
			}
			yield break;
		}

		// Token: 0x0200004C RID: 76
		private struct PointWeight
		{
			// Token: 0x0600023A RID: 570 RVA: 0x00008937 File Offset: 0x00006B37
			public PointWeight(int index, byte weight)
			{
				this.pointIndex = index;
				this.weight = weight;
			}

			// Token: 0x040001D5 RID: 469
			public int pointIndex;

			// Token: 0x040001D6 RID: 470
			public byte weight;
		}
	}
}
