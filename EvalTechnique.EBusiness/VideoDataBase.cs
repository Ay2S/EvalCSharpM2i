using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace EvalTechnique.EBusiness
{

    // TODO DONE: Add xml serialization attributes (if required) to match VideoDataBase.xml format
    [DataContract]
    [XmlRoot("DataBase")]
    public class VideoDataBase
    {
        [DataMember]
        [XmlArray]
        [XmlArrayItem("Movie", typeof(Movie))]
        [XmlArrayItem("Serie", typeof(Serie))]
        
        public List<VideoDataBaseItem> Items { get; set; }
    }
}
