using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace EvalTechnique.EBusiness
{

    // TODO DONE: Add xml serialization attributes (if required) to match VideoDataBase.xml format
    [DataContract]
    public class Serie : VideoDataBaseItem
    {
        [DataMember]
        [XmlArray]
        [XmlArrayItem("Season", typeof(Season))]
        public List<Season> Seasons { get; set; }
    }
}
