using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EvalTechnique.EBusiness
{

    // TODO DONE: Add xml serialization attributes (if required) to match VideoDataBase.xml format
    [DataContract]
    public class Season
    {
        [DataMember]
        [XmlAttribute("Number")]
        public int Number { get; set; }

        [DataMember]
        [XmlArray("Episodes")]
        [XmlArrayItem("Episode")]
        public List<Episode> Episodes { get; set; }
    }
}
