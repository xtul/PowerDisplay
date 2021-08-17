using HarmonyLib;
using SandBox.ViewModelCollection.Nameplate;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace PowerDisplay {
	public class SubModule : MBSubModuleBase {

		private readonly string ConfigFile = BasePath.Name + "Modules/PowerDisplay/Config.xml";

		protected override void OnSubModuleLoad() {
			var harmony = new Harmony("PowerDisplay");
			Config config = ReadXML(ConfigFile);

			if (config.DisplayOnInspect) {
				var original = typeof(PartyNameplateVM).GetProperty("ExtraInfoText").GetGetMethod();
				var postfix = typeof(HarmonyExtraInfoText).GetMethod("Postfix");

				harmony.Patch(original, null, new HarmonyMethod(postfix));
			} else {
				var original = typeof(PartyNameplateVM).GetProperty("Count").GetGetMethod();
				var postfix = typeof(HarmonyCount).GetMethod("Postfix");

				harmony.Patch(original, null, new HarmonyMethod(postfix));
			}
		}

		private Config ReadXML(string xml) {
			Config config = new();
			XmlSerializer serializer = new XmlSerializer(typeof(Config));
			//string file = File.ReadAllText(xml, Encoding.UTF8);

			using (FileStream fs = new FileStream(xml, FileMode.Open)) {
				config = (Config)serializer.Deserialize(fs);
			}

			return config;
		}
	}
}