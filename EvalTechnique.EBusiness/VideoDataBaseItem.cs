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
    // TODO DONE: Add knowntype attributes to fix wcf polymorphism serialization/deserialization error

    [DataContract]
    [KnownType(typeof(Serie))]
    [KnownType(typeof(Movie))]
    [KnownType(typeof(Episode))]
    public abstract class VideoDataBaseItem
    {
        [DataMember]
        [XmlAttribute("Title")]
        public string Title { get; set; }
    }
}
