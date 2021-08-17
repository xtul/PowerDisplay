using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PowerDisplay {
	[XmlRoot(ElementName = "Config")]
	public class Config {

		[XmlElement(ElementName = "DisplayOnInspect")]
		public bool DisplayOnInspect { get; set; }
	}
}
