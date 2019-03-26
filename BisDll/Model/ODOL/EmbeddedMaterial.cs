using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using BisDll.Common;
using BisDll.Stream;

namespace BisDll.Model.ODOL
{
	// Token: 0x02000011 RID: 17
	public class EmbeddedMaterial : IDeserializable
	{
		// Token: 0x06000071 RID: 113 RVA: 0x00003A88 File Offset: 0x00001C88
		public void writeToFile(string fileName)
		{
			List<string> list = new List<string>();
			string item = "Emissive[] = " + this.emissive + ";";
			string item2 = "Ambient[] = " + this.ambient + ";";
			string item3 = "Diffuse[] = " + this.diffuse + ";";
			string item4 = "forcedDiffuse[] = " + this.forcedDiffuse + ";";
			string item5 = "Specular[] = " + this.specular + ";";
			string item6 = "specularPower = " + this.specularPower.ToString(new CultureInfo("en-GB").NumberFormat) + ";";
			string text = Enum.GetName(this.pixelShader.GetType(), this.pixelShader);
			string text2 = Enum.GetName(this.vertexShader.GetType(), this.vertexShader);
			if (text == "")
			{
				text = "Unknown PixelShaderID (" + this.pixelShader + ")";
			}
			if (text2 == "")
			{
				text2 = "Unknown VertexShaderID (" + this.vertexShader + ")";
			}
			string item7 = "PixelShader = " + text + ";";
			string item8 = "VertexShader = " + text2 + ";";
			list.Add(item);
			list.Add(item2);
			list.Add(item3);
			list.Add(item4);
			list.Add(item5);
			list.Add(item6);
			list.Add(item7);
			list.Add(item8);
			if (this.surfaceFile != "")
			{
				list.Add("surfaceInfo = " + this.surfaceFile + ";");
			}
			if (this.stageTextures != null)
			{
				for (int i = 0; i < this.stageTextures.Length; i++)
				{
					list.Add("class Stage" + i + 1);
					list.Add("{");
					list.Add("\tfilter = " + Enum.GetName(this.stageTextures[i].textureFilter.GetType(), this.stageTextures[i].textureFilter) + ";");
					list.Add("\ttexture = " + this.stageTextures[i].texture + ";");
					list.Add("\tuvSource = " + this.stageTransforms[i].uvSource + ";");
					list.Add("\tclass uvTransform");
					list.Add("\t{");
					list.Add("\t\taside[] = " + this.stageTransforms[i].transformation.Orientation.Aside + ";");
					list.Add("\t\tup[] = " + this.stageTransforms[i].transformation.Orientation.Up + ";");
					list.Add("\t\tdir[] = " + this.stageTransforms[i].transformation.Orientation.Dir + ";");
					list.Add("\t\tpos[] = " + this.stageTransforms[i].transformation.Position + ";");
					list.Add("\t};");
					list.Add("};");
				}
			}
			File.WriteAllLines(fileName, list.ToArray());
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00003E40 File Offset: 0x00002040
		public void ReadObject(BinaryReaderEx input)
		{
			this.materialName = input.ReadAsciiz();
			this.version = input.ReadUInt32();
			this.emissive.read(input);
			this.ambient.read(input);
			this.diffuse.read(input);
			this.forcedDiffuse.read(input);
			this.specular.read(input);
			this.specularCopy.read(input);
			this.specularPower = input.ReadSingle();
			this.pixelShader = (EmbeddedMaterial.PixelShaderID)input.ReadUInt32();
			this.vertexShader = (EmbeddedMaterial.VertexShaderID)input.ReadUInt32();
			this.mainLight = (EmbeddedMaterial.EMainLight)input.ReadUInt32();
			this.fogMode = (EmbeddedMaterial.EFogMode)input.ReadUInt32();
			if (this.version == 3u)
			{
				input.ReadBoolean();
			}
			if (this.version >= 6u)
			{
				this.surfaceFile = input.ReadAsciiz();
			}
			if (this.version >= 4u)
			{
				this.nRenderFlags = input.ReadUInt32();
				this.renderFlags = input.ReadUInt32();
			}
			if (this.version > 6u)
			{
				this.nStages = input.ReadUInt32();
			}
			if (this.version > 8u)
			{
				this.nTexGens = input.ReadUInt32();
			}
			this.stageTextures = new StageTexture[this.nStages];
			this.stageTransforms = new StageTransform[this.nTexGens];
			if (this.version < 8u)
			{
				int num = 0;
				while ((long)num < (long)((ulong)this.nStages))
				{
					this.stageTransforms[num] = new StageTransform(input);
					this.stageTextures[num].read(input, this.version);
					num++;
				}
			}
			else
			{
				int num2 = 0;
				while ((long)num2 < (long)((ulong)this.nStages))
				{
					this.stageTextures[num2] = new StageTexture();
					this.stageTextures[num2].read(input, this.version);
					num2++;
				}
				int num3 = 0;
				while ((long)num3 < (long)((ulong)this.nTexGens))
				{
					this.stageTransforms[num3] = new StageTransform(input);
					num3++;
				}
			}
			if (this.version >= 10u)
			{
				this.stageTI.read(input, this.version);
			}
		}

		// Token: 0x0400008E RID: 142
		public string materialName;

		// Token: 0x0400008F RID: 143
		private uint version;

		// Token: 0x04000090 RID: 144
		private ColorP emissive;

		// Token: 0x04000091 RID: 145
		private ColorP ambient;

		// Token: 0x04000092 RID: 146
		private ColorP diffuse;

		// Token: 0x04000093 RID: 147
		private ColorP forcedDiffuse;

		// Token: 0x04000094 RID: 148
		private ColorP specular;

		// Token: 0x04000095 RID: 149
		private ColorP specularCopy;

		// Token: 0x04000096 RID: 150
		public float specularPower;

		// Token: 0x04000097 RID: 151
		public EmbeddedMaterial.PixelShaderID pixelShader;

		// Token: 0x04000098 RID: 152
		public EmbeddedMaterial.VertexShaderID vertexShader;

		// Token: 0x04000099 RID: 153
		private EmbeddedMaterial.EMainLight mainLight;

		// Token: 0x0400009A RID: 154
		private EmbeddedMaterial.EFogMode fogMode;

		// Token: 0x0400009B RID: 155
		public string surfaceFile;

		// Token: 0x0400009C RID: 156
		private uint nRenderFlags;

		// Token: 0x0400009D RID: 157
		private uint renderFlags;

		// Token: 0x0400009E RID: 158
		private uint nStages;

		// Token: 0x0400009F RID: 159
		private uint nTexGens;

		// Token: 0x040000A0 RID: 160
		public StageTexture[] stageTextures;

		// Token: 0x040000A1 RID: 161
		public StageTransform[] stageTransforms;

		// Token: 0x040000A2 RID: 162
		private StageTexture stageTI = new StageTexture();

		// Token: 0x02000057 RID: 87
		private enum EFogMode
		{
			// Token: 0x04000216 RID: 534
			FM_None,
			// Token: 0x04000217 RID: 535
			FM_Fog,
			// Token: 0x04000218 RID: 536
			FM_Alpha,
			// Token: 0x04000219 RID: 537
			FM_FogAlpha
		}

		// Token: 0x02000058 RID: 88
		private enum EMainLight
		{
			// Token: 0x0400021B RID: 539
			ML_None,
			// Token: 0x0400021C RID: 540
			ML_Sun,
			// Token: 0x0400021D RID: 541
			ML_Sky,
			// Token: 0x0400021E RID: 542
			ML_Horizon,
			// Token: 0x0400021F RID: 543
			ML_Stars,
			// Token: 0x04000220 RID: 544
			ML_SunObject,
			// Token: 0x04000221 RID: 545
			ML_SunHaloObject,
			// Token: 0x04000222 RID: 546
			ML_MoonObject,
			// Token: 0x04000223 RID: 547
			ML_MoonHaloObject
		}

		// Token: 0x02000059 RID: 89
		public enum PixelShaderID : uint
		{
			// Token: 0x04000225 RID: 549
			PSNormal,
			// Token: 0x04000226 RID: 550
			PSNormalDXTA,
			// Token: 0x04000227 RID: 551
			PSNormalMap,
			// Token: 0x04000228 RID: 552
			PSNormalMapThrough,
			// Token: 0x04000229 RID: 553
			PSNormalMapGrass,
			// Token: 0x0400022A RID: 554
			PSNormalMapDiffuse,
			// Token: 0x0400022B RID: 555
			PSDetail,
			// Token: 0x0400022C RID: 556
			PSInterpolation,
			// Token: 0x0400022D RID: 557
			PSWater,
			// Token: 0x0400022E RID: 558
			PSWaterSimple,
			// Token: 0x0400022F RID: 559
			PSWhite,
			// Token: 0x04000230 RID: 560
			PSWhiteAlpha,
			// Token: 0x04000231 RID: 561
			PSAlphaShadow,
			// Token: 0x04000232 RID: 562
			PSAlphaNoShadow,
			// Token: 0x04000233 RID: 563
			PSDummy0,
			// Token: 0x04000234 RID: 564
			PSDetailMacroAS,
			// Token: 0x04000235 RID: 565
			PSNormalMapMacroAS,
			// Token: 0x04000236 RID: 566
			PSNormalMapDiffuseMacroAS,
			// Token: 0x04000237 RID: 567
			PSNormalMapSpecularMap,
			// Token: 0x04000238 RID: 568
			PSNormalMapDetailSpecularMap,
			// Token: 0x04000239 RID: 569
			PSNormalMapMacroASSpecularMap,
			// Token: 0x0400023A RID: 570
			PSNormalMapDetailMacroASSpecularMap,
			// Token: 0x0400023B RID: 571
			PSNormalMapSpecularDIMap,
			// Token: 0x0400023C RID: 572
			PSNormalMapDetailSpecularDIMap,
			// Token: 0x0400023D RID: 573
			PSNormalMapMacroASSpecularDIMap,
			// Token: 0x0400023E RID: 574
			PSNormalMapDetailMacroASSpecularDIMap,
			// Token: 0x0400023F RID: 575
			PSTerrain1,
			// Token: 0x04000240 RID: 576
			PSTerrain2,
			// Token: 0x04000241 RID: 577
			PSTerrain3,
			// Token: 0x04000242 RID: 578
			PSTerrain4,
			// Token: 0x04000243 RID: 579
			PSTerrain5,
			// Token: 0x04000244 RID: 580
			PSTerrain6,
			// Token: 0x04000245 RID: 581
			PSTerrain7,
			// Token: 0x04000246 RID: 582
			PSTerrain8,
			// Token: 0x04000247 RID: 583
			PSTerrain9,
			// Token: 0x04000248 RID: 584
			PSTerrain10,
			// Token: 0x04000249 RID: 585
			PSTerrain11,
			// Token: 0x0400024A RID: 586
			PSTerrain12,
			// Token: 0x0400024B RID: 587
			PSTerrain13,
			// Token: 0x0400024C RID: 588
			PSTerrain14,
			// Token: 0x0400024D RID: 589
			PSTerrain15,
			// Token: 0x0400024E RID: 590
			PSTerrainSimple1,
			// Token: 0x0400024F RID: 591
			PSTerrainSimple2,
			// Token: 0x04000250 RID: 592
			PSTerrainSimple3,
			// Token: 0x04000251 RID: 593
			PSTerrainSimple4,
			// Token: 0x04000252 RID: 594
			PSTerrainSimple5,
			// Token: 0x04000253 RID: 595
			PSTerrainSimple6,
			// Token: 0x04000254 RID: 596
			PSTerrainSimple7,
			// Token: 0x04000255 RID: 597
			PSTerrainSimple8,
			// Token: 0x04000256 RID: 598
			PSTerrainSimple9,
			// Token: 0x04000257 RID: 599
			PSTerrainSimple10,
			// Token: 0x04000258 RID: 600
			PSTerrainSimple11,
			// Token: 0x04000259 RID: 601
			PSTerrainSimple12,
			// Token: 0x0400025A RID: 602
			PSTerrainSimple13,
			// Token: 0x0400025B RID: 603
			PSTerrainSimple14,
			// Token: 0x0400025C RID: 604
			PSTerrainSimple15,
			// Token: 0x0400025D RID: 605
			PSGlass,
			// Token: 0x0400025E RID: 606
			PSNonTL,
			// Token: 0x0400025F RID: 607
			PSNormalMapSpecularThrough,
			// Token: 0x04000260 RID: 608
			PSGrass,
			// Token: 0x04000261 RID: 609
			PSNormalMapThroughSimple,
			// Token: 0x04000262 RID: 610
			PSNormalMapSpecularThroughSimple,
			// Token: 0x04000263 RID: 611
			PSRoad,
			// Token: 0x04000264 RID: 612
			PSShore,
			// Token: 0x04000265 RID: 613
			PSShoreWet,
			// Token: 0x04000266 RID: 614
			PSRoad2Pass,
			// Token: 0x04000267 RID: 615
			PSShoreFoam,
			// Token: 0x04000268 RID: 616
			PSNonTLFlare,
			// Token: 0x04000269 RID: 617
			PSNormalMapThroughLowEnd,
			// Token: 0x0400026A RID: 618
			PSTerrainGrass1,
			// Token: 0x0400026B RID: 619
			PSTerrainGrass2,
			// Token: 0x0400026C RID: 620
			PSTerrainGrass3,
			// Token: 0x0400026D RID: 621
			PSTerrainGrass4,
			// Token: 0x0400026E RID: 622
			PSTerrainGrass5,
			// Token: 0x0400026F RID: 623
			PSTerrainGrass6,
			// Token: 0x04000270 RID: 624
			PSTerrainGrass7,
			// Token: 0x04000271 RID: 625
			PSTerrainGrass8,
			// Token: 0x04000272 RID: 626
			PSTerrainGrass9,
			// Token: 0x04000273 RID: 627
			PSTerrainGrass10,
			// Token: 0x04000274 RID: 628
			PSTerrainGrass11,
			// Token: 0x04000275 RID: 629
			PSTerrainGrass12,
			// Token: 0x04000276 RID: 630
			PSTerrainGrass13,
			// Token: 0x04000277 RID: 631
			PSTerrainGrass14,
			// Token: 0x04000278 RID: 632
			PSTerrainGrass15,
			// Token: 0x04000279 RID: 633
			PSCrater1,
			// Token: 0x0400027A RID: 634
			PSCrater2,
			// Token: 0x0400027B RID: 635
			PSCrater3,
			// Token: 0x0400027C RID: 636
			PSCrater4,
			// Token: 0x0400027D RID: 637
			PSCrater5,
			// Token: 0x0400027E RID: 638
			PSCrater6,
			// Token: 0x0400027F RID: 639
			PSCrater7,
			// Token: 0x04000280 RID: 640
			PSCrater8,
			// Token: 0x04000281 RID: 641
			PSCrater9,
			// Token: 0x04000282 RID: 642
			PSCrater10,
			// Token: 0x04000283 RID: 643
			PSCrater11,
			// Token: 0x04000284 RID: 644
			PSCrater12,
			// Token: 0x04000285 RID: 645
			PSCrater13,
			// Token: 0x04000286 RID: 646
			PSCrater14,
			// Token: 0x04000287 RID: 647
			PSSprite,
			// Token: 0x04000288 RID: 648
			PSSpriteSimple,
			// Token: 0x04000289 RID: 649
			PSCloud,
			// Token: 0x0400028A RID: 650
			PSHorizon,
			// Token: 0x0400028B RID: 651
			PSSuper,
			// Token: 0x0400028C RID: 652
			PSMulti,
			// Token: 0x0400028D RID: 653
			PSTerrainX,
			// Token: 0x0400028E RID: 654
			PSTerrainSimpleX,
			// Token: 0x0400028F RID: 655
			PSTerrainGrassX,
			// Token: 0x04000290 RID: 656
			PSTree,
			// Token: 0x04000291 RID: 657
			PSTreePRT,
			// Token: 0x04000292 RID: 658
			PSTreeSimple,
			// Token: 0x04000293 RID: 659
			PSSkin,
			// Token: 0x04000294 RID: 660
			PSCalmWater,
			// Token: 0x04000295 RID: 661
			PSTreeAToC,
			// Token: 0x04000296 RID: 662
			PSGrassAToC,
			// Token: 0x04000297 RID: 663
			PSTreeAdv,
			// Token: 0x04000298 RID: 664
			PSTreeAdvSimple,
			// Token: 0x04000299 RID: 665
			PSTreeAdvTrunk,
			// Token: 0x0400029A RID: 666
			PSTreeAdvTrunkSimple,
			// Token: 0x0400029B RID: 667
			PSTreeAdvAToC,
			// Token: 0x0400029C RID: 668
			PSTreeAdvSimpleAToC,
			// Token: 0x0400029D RID: 669
			PSTreeSN,
			// Token: 0x0400029E RID: 670
			PSSpriteExtTi,
			// Token: 0x0400029F RID: 671
			PSTerrainSNX,
			// Token: 0x040002A0 RID: 672
			PSSimulWeatherClouds,
			// Token: 0x040002A1 RID: 673
			PSSimulWeatherCloudsWithLightning,
			// Token: 0x040002A2 RID: 674
			PSSimulWeatherCloudsCPU,
			// Token: 0x040002A3 RID: 675
			PSSimulWeatherCloudsWithLightningCPU,
			// Token: 0x040002A4 RID: 676
			PSSuperExt,
			// Token: 0x040002A5 RID: 677
			PSSuperAToC,
			// Token: 0x040002A6 RID: 678
			NPixelShaderID,
			// Token: 0x040002A7 RID: 679
			PSNone = 129u,
			// Token: 0x040002A8 RID: 680
			PSUninitialized = 4294967295u
		}

		// Token: 0x0200005A RID: 90
		public enum VertexShaderID
		{
			// Token: 0x040002AA RID: 682
			VSBasic,
			// Token: 0x040002AB RID: 683
			VSNormalMap,
			// Token: 0x040002AC RID: 684
			VSNormalMapDiffuse,
			// Token: 0x040002AD RID: 685
			VSGrass,
			// Token: 0x040002AE RID: 686
			VSDummy1,
			// Token: 0x040002AF RID: 687
			VSDummy2,
			// Token: 0x040002B0 RID: 688
			VSShadowVolume,
			// Token: 0x040002B1 RID: 689
			VSWater,
			// Token: 0x040002B2 RID: 690
			VSWaterSimple,
			// Token: 0x040002B3 RID: 691
			VSSprite,
			// Token: 0x040002B4 RID: 692
			VSPoint,
			// Token: 0x040002B5 RID: 693
			VSNormalMapThrough,
			// Token: 0x040002B6 RID: 694
			VSDummy3,
			// Token: 0x040002B7 RID: 695
			VSTerrain,
			// Token: 0x040002B8 RID: 696
			VSBasicAS,
			// Token: 0x040002B9 RID: 697
			VSNormalMapAS,
			// Token: 0x040002BA RID: 698
			VSNormalMapDiffuseAS,
			// Token: 0x040002BB RID: 699
			VSGlass,
			// Token: 0x040002BC RID: 700
			VSNormalMapSpecularThrough,
			// Token: 0x040002BD RID: 701
			VSNormalMapThroughNoFade,
			// Token: 0x040002BE RID: 702
			VSNormalMapSpecularThroughNoFade,
			// Token: 0x040002BF RID: 703
			VSShore,
			// Token: 0x040002C0 RID: 704
			VSTerrainGrass,
			// Token: 0x040002C1 RID: 705
			VSSuper,
			// Token: 0x040002C2 RID: 706
			VSMulti,
			// Token: 0x040002C3 RID: 707
			VSTree,
			// Token: 0x040002C4 RID: 708
			VSTreeNoFade,
			// Token: 0x040002C5 RID: 709
			VSTreePRT,
			// Token: 0x040002C6 RID: 710
			VSTreePRTNoFade,
			// Token: 0x040002C7 RID: 711
			VSSkin,
			// Token: 0x040002C8 RID: 712
			VSCalmWater,
			// Token: 0x040002C9 RID: 713
			VSTreeAdv,
			// Token: 0x040002CA RID: 714
			VSTreeAdvTrunk,
			// Token: 0x040002CB RID: 715
			VSSimulWeatherClouds,
			// Token: 0x040002CC RID: 716
			VSSimulWeatherCloudsCPU,
			// Token: 0x040002CD RID: 717
			NVertexShaderID
		}
	}
}
