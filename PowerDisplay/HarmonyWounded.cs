using HarmonyLib;
using SandBox.ViewModelCollection.Nameplate;
using System.Linq;
using TaleWorlds.CampaignSystem;

namespace PowerDisplay {
	[HarmonyPatch(typeof(PartyNameplateVM), "Wounded", MethodType.Getter)]
	public class HarmonyWounded {
		public static void Postfix(PartyNameplateVM __instance, ref string __result) {
			if (!string.IsNullOrEmpty(__result) && !__result.Contains('[')) {
				MobileParty party = __instance.Party;
				string modified = __result + $" [{(int)party.GetTotalStrengthWithFollowers()}]";
				__result = modified;
			}
		}
	}
}
