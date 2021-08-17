using HarmonyLib;
using SandBox.ViewModelCollection.Nameplate;
using System.Linq;
using TaleWorlds.CampaignSystem;

namespace PowerDisplay {
	[HarmonyPatch(typeof(PartyNameplateVM), "ExtraInfoText", MethodType.Getter)]
	public class HarmonyExtraInfoText {
		public static void Postfix(PartyNameplateVM __instance, ref string __result) {
			if (__result is not null && !__result.Contains('[')) {
				MobileParty party = __instance.Party;
				string modified = $" [{(int)party.GetTotalStrengthWithFollowers()}] " + __result;
				__result = modified;
			}
		}
	}
}
