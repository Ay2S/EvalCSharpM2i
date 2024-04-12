using System.IO;
using System.Xml.Serialization;

namespace EvalTechnique.Data
{
    public static class VideoDataBaseProvider
    {
        /// <summary>
        /// Deserialize xml database
        /// </summary>
        /// <param name="fileName">The fileName must given as the full path of the XML file</param>
        /// <returns></returns>
        public static EBusiness.VideoDataBase Load(string fileName)
        {
            // TODO DONE: Deserialize xml database VideoDataBase.xml
            XmlSerializer serializer = new XmlSerializer(typeof(EBusiness.VideoDataBase));

            EBusiness.VideoDataBase dbResult;

            using (Stream reader = new FileStream(fileName, FileMode.Open))
            {
                dbResult = (EBusiness.VideoDataBase)serializer.Deserialize(reader);
            }

            return dbResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName">The fileName must given as the full path of the XML file</param>
        /// <param name="db">The object in memory</param>
        public static void Save(string fileName, EBusiness.VideoDataBase db)
        {
            // TODO DONE: Serialize xml database VideoDataBase.xml
            XmlSerializer serializer = new XmlSerializer(typeof(EBusiness.VideoDataBase));
            TextWriter writer = new StreamWriter(fileName);

            serializer.Serialize(writer, db);
            writer.Close();
        }
    }
}
