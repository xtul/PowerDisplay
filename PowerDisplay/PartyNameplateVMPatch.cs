using HarmonyLib;
using SandBox.ViewModelCollection.Nameplate;
using System.Linq;
using TaleWorlds.CampaignSystem;

namespace PowerDisplay {
	[HarmonyPatch(typeof(PartyNameplateVM), "Count", MethodType.Getter)]
	public class PartyNameplateVMPatch {
		public static void Postfix(PartyNameplateVM __instance, ref string __result) {
			if (!string.IsNullOrEmpty(__result) && !__result.Contains('[')) {
				MobileParty party = __instance.Party;
				__result += $" [{(int)party.GetTotalStrengthWithFollowers()}]";
			}
		}
	}
}
