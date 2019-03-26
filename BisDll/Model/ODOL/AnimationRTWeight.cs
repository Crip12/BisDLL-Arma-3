using System;

namespace BisDll.Model.ODOL
{
	// Token: 0x02000019 RID: 25
	public class AnimationRTWeight : VerySmallArray
	{
		// Token: 0x1700006F RID: 111
		// (get) Token: 0x06000113 RID: 275 RVA: 0x00004D28 File Offset: 0x00002F28
		public AnimationRTPair[] AnimationRTPairs
		{
			get
			{
				AnimationRTPair[] array = new AnimationRTPair[this.nSmall];
				for (int i = 0; i < this.nSmall; i++)
				{
					array[i] = new AnimationRTPair(this.smallSpace[i * 2], this.smallSpace[i * 2 + 1]);
				}
				return array;
			}
		}
	}
}
