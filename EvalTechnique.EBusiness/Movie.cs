using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace EvalTechnique.EBusiness
{

    // TODO DONE: Add xml serialization attributes (if required) to match VideoDataBase.xml format
    [DataContract]
    public class Movie : VideoDataBaseItem
    {
        [DataMember]
        [XmlElement("Duration")]
        public int Duration { get; set; }
    }
}
