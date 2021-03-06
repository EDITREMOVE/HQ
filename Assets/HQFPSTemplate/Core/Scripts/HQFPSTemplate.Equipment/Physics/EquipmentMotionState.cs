using System;
using UnityEngine;

namespace HQFPSTemplate.Equipment
{
	[Serializable]
	public class EquipmentMotionState : ICloneable
	{
		#region Internal
		[Serializable]
		public class EntryOffsetModule : CloneableObject<EntryOffsetModule>
		{
			public bool Enabled;

			[EnableIf("Enabled", true, 0f)]
			public float EntryOffsetDuration = 1f, LerpToOffsetSpeed = 4f;

			[EnableIf("Enabled", true, 0f)]
			public OffsetModule Offset;
		}

		[Serializable]
		public class OffsetModule : CloneableObject<OffsetModule>
		{
			public bool Enabled = true;

			[EnableIf("Enabled", true, 0f)]
			public Vector3 PositionOffset, RotationOffset;
		}

		[Serializable]
		public class BobModule : CloneableObject<BobModule>
		{
			public bool Enabled = true;

			[EnableIf("Enabled", true, 0f)]
			[Clamp(0,1000)]
			public float BobSpeed = 1f;

			[EnableIf("Enabled", true, 0f)]
			public Vector3 PositionAmplitude = new Vector3(0.35f, 0.5f, 0f), RotationAmplitude = new Vector3(0.35f, 0.5f, 0f);
		}

		[Serializable]
		public class NoiseModule : CloneableObject<NoiseModule>
		{
			public bool Enabled = true;

			[EnableIf("Enabled", true, 0f)]
			[Range(0f, 1f)]
			public float MaxJitter = 0f, NoiseSpeed = 1f;

			[EnableIf("Enabled", true, 0f)]
			public Vector3 PosNoiseAmplitude, RotNoiseAmplitude;
		}
		#endregion

		[BHeader("Main Settings")]

		[Group] public SpringSettings SpringSettings;

		[Space(3)]

		[Group("1: ")] public EntryOffsetModule EntryOffset;

		[Group("2: ")] public OffsetModule Offset;
		[Group("3: ")] public BobModule Bob;
		[Group("4: ")] public NoiseModule Noise;

		[BHeader("Additional Forces")]

		[Group("5: ")] public SpringForce PosEnterForce;
		[Group("6: ")] public SpringForce PosExitForce;
		[Group("7: ")] public SpringForce EnterForce;
		[Group("8: ")] public SpringForce ExitForce;

		public object Clone() => MemberwiseClone();
    }
}