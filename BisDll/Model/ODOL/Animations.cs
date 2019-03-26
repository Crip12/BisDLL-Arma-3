using System;
using BisDll.Common.Math;
using BisDll.Stream;

namespace BisDll.Model.ODOL
{
	// Token: 0x0200000E RID: 14
	public class Animations
	{
		// Token: 0x06000053 RID: 83 RVA: 0x00003430 File Offset: 0x00001630
		public void read(BinaryReaderEx input)
		{
			this.animationClasses = input.ReadArray<Animations.AnimationClass>();
			int num = this.animationClasses.Length;
			this.nAnimLODs = input.ReadInt32();
			this.Bones2Anims = new uint[this.nAnimLODs][][];
			for (int i = 0; i < this.nAnimLODs; i++)
			{
				uint num2 = input.ReadUInt32();
				this.Bones2Anims[i] = new uint[num2][];
				int num3 = 0;
				while ((long)num3 < (long)((ulong)num2))
				{
					uint num4 = input.ReadUInt32();
					this.Bones2Anims[i][num3] = new uint[num4];
					int num5 = 0;
					while ((long)num5 < (long)((ulong)num4))
					{
						this.Bones2Anims[i][num3][num5] = input.ReadUInt32();
						num5++;
					}
					num3++;
				}
			}
			this.Anims2Bones = new int[this.nAnimLODs][];
			this.axisData = new Vector3P[this.nAnimLODs][][];
			for (int j = 0; j < this.nAnimLODs; j++)
			{
				this.Anims2Bones[j] = new int[num];
				this.axisData[j] = new Vector3P[num][];
				for (int k = 0; k < num; k++)
				{
					this.Anims2Bones[j][k] = input.ReadInt32();
					if (this.Anims2Bones[j][k] != -1 && this.animationClasses[k].animType != Animations.AnimationClass.AnimType.Direct && this.animationClasses[k].animType != Animations.AnimationClass.AnimType.Hide)
					{
						this.axisData[j][k] = new Vector3P[2];
						this.axisData[j][k][0] = new Vector3P(input);
						this.axisData[j][k][1] = new Vector3P(input);
					}
				}
			}
		}

		// Token: 0x04000063 RID: 99
		private Animations.AnimationClass[] animationClasses;

		// Token: 0x04000064 RID: 100
		private int nAnimLODs;

		// Token: 0x04000065 RID: 101
		private uint[][][] Bones2Anims;

		// Token: 0x04000066 RID: 102
		private int[][] Anims2Bones;

		// Token: 0x04000067 RID: 103
		private Vector3P[][][] axisData;

		// Token: 0x02000054 RID: 84
		public class AnimationClass : IDeserializable
		{
			// Token: 0x06000264 RID: 612 RVA: 0x0000902C File Offset: 0x0000722C
			public void ReadObject(BinaryReaderEx input)
			{
				int version = input.Version;
				this.animType = (Animations.AnimationClass.AnimType)input.ReadUInt32();
				this.animName = input.ReadAsciiz();
				this.animSource = input.ReadAsciiz();
				this.minPhase = input.ReadSingle();
				this.maxPhase = input.ReadSingle();
				this.minValue = input.ReadSingle();
				this.maxValue = input.ReadSingle();
				if (version >= 56)
				{
					this.animPeriod = input.ReadSingle();
					this.initPhase = input.ReadSingle();
				}
				this.sourceAddress = (Animations.AnimationClass.AnimAddress)input.ReadUInt32();
				switch (this.animType)
				{
				case Animations.AnimationClass.AnimType.Rotation:
				case Animations.AnimationClass.AnimType.RotationX:
				case Animations.AnimationClass.AnimType.RotationY:
				case Animations.AnimationClass.AnimType.RotationZ:
					this.angle0 = input.ReadSingle();
					this.angle1 = input.ReadSingle();
					return;
				case Animations.AnimationClass.AnimType.Translation:
				case Animations.AnimationClass.AnimType.TranslationX:
				case Animations.AnimationClass.AnimType.TranslationY:
				case Animations.AnimationClass.AnimType.TranslationZ:
					this.offset0 = input.ReadSingle();
					this.offset1 = input.ReadSingle();
					return;
				case Animations.AnimationClass.AnimType.Direct:
					this.axisPos = new Vector3P(input);
					this.axisDir = new Vector3P(input);
					this.angle = input.ReadSingle();
					this.axisOffset = input.ReadSingle();
					return;
				case Animations.AnimationClass.AnimType.Hide:
					this.hideValue = input.ReadSingle();
					if (version >= 55)
					{
						input.ReadSingle();
						return;
					}
					return;
				default:
					throw new Exception("Unknown AnimType encountered: " + this.animType);
				}
			}

			// Token: 0x040001FB RID: 507
			public Animations.AnimationClass.AnimType animType;

			// Token: 0x040001FC RID: 508
			private string animName;

			// Token: 0x040001FD RID: 509
			private string animSource;

			// Token: 0x040001FE RID: 510
			private float minValue;

			// Token: 0x040001FF RID: 511
			private float maxValue;

			// Token: 0x04000200 RID: 512
			private float minPhase;

			// Token: 0x04000201 RID: 513
			private float maxPhase;

			// Token: 0x04000202 RID: 514
			private float animPeriod;

			// Token: 0x04000203 RID: 515
			private float initPhase;

			// Token: 0x04000204 RID: 516
			private Animations.AnimationClass.AnimAddress sourceAddress;

			// Token: 0x04000205 RID: 517
			private float angle0;

			// Token: 0x04000206 RID: 518
			private float angle1;

			// Token: 0x04000207 RID: 519
			private float offset0;

			// Token: 0x04000208 RID: 520
			private float offset1;

			// Token: 0x04000209 RID: 521
			private Vector3P axisPos;

			// Token: 0x0400020A RID: 522
			private Vector3P axisDir;

			// Token: 0x0400020B RID: 523
			private float angle;

			// Token: 0x0400020C RID: 524
			private float axisOffset;

			// Token: 0x0400020D RID: 525
			private float hideValue;

			// Token: 0x02000062 RID: 98
			public enum AnimType
			{
				// Token: 0x040002EB RID: 747
				Rotation,
				// Token: 0x040002EC RID: 748
				RotationX,
				// Token: 0x040002ED RID: 749
				RotationY,
				// Token: 0x040002EE RID: 750
				RotationZ,
				// Token: 0x040002EF RID: 751
				Translation,
				// Token: 0x040002F0 RID: 752
				TranslationX,
				// Token: 0x040002F1 RID: 753
				TranslationY,
				// Token: 0x040002F2 RID: 754
				TranslationZ,
				// Token: 0x040002F3 RID: 755
				Direct,
				// Token: 0x040002F4 RID: 756
				Hide
			}

			// Token: 0x02000063 RID: 99
			public enum AnimAddress
			{
				// Token: 0x040002F6 RID: 758
				AnimClamp,
				// Token: 0x040002F7 RID: 759
				AnimLoop,
				// Token: 0x040002F8 RID: 760
				AnimMirror,
				// Token: 0x040002F9 RID: 761
				NAnimAddress
			}
		}
	}
}
