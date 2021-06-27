using Dalamud.Game.ClientState.Structs.JobGauge;

namespace XIVComboVeryExpandedPlugin.Combos {
	internal static class SCH {
		public const byte JobID = 28;

		public const uint
			FeyBless = 16543,
			Consolation = 16546,
			EnergyDrain = 167,
			Aetherflow = 166;

		public static class Buffs {
			// public const short placeholder = 0;
		}

		public static class Debuffs {
			// public const short placeholder = 0;
		}

		public static class Levels {
			// public const byte placeholder = 0;
		}
	}

	internal class ScholarSeraphConsolationFeature: CustomCombo {
		protected override CustomComboPreset Preset => CustomComboPreset.ScholarSeraphConsolationFeature;

		protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
			if (actionID == SCH.FeyBless) {
				SCHGauge gauge = GetJobGauge<SCHGauge>();
				if (gauge.SeraphTimer > 0)
					return SCH.Consolation;
			}

			return actionID;
		}
	}

	internal class ScholarEnergyDrainFeature: CustomCombo {
		protected override CustomComboPreset Preset => CustomComboPreset.ScholarEnergyDrainFeature;

		protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
			if (actionID == SCH.EnergyDrain) {
				SCHGauge gauge = GetJobGauge<SCHGauge>();
				if (gauge.NumAetherflowStacks == 0)
					return SCH.Aetherflow;
			}

			return actionID;
		}
	}
}
