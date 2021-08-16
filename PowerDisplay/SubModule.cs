using HarmonyLib;
using TaleWorlds.MountAndBlade;

namespace PowerDisplay {
	public class SubModule : MBSubModuleBase {

		protected override void OnSubModuleLoad() {
			var harmony = new Harmony("PowerDisplay");

			harmony.PatchAll();
		}
	}
}