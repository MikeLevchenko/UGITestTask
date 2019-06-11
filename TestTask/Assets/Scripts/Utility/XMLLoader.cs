using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using TestTask.Gameplay;

namespace TestTask.Utility
{
    public static class XMLLoader
    {
        private static string _fileName = "XML/targetdata.xml";


        private static string _path
        {
            get
            {
#if UNITY_EDITOR
                return Path.Combine(Application.dataPath, "Resources", _fileName);
#elif UNITY_ANDROID
        return Path.Combine(Application.persistentDataPath, _fileName);
#else
                return Path.Combine(Application.dataPath,_fileName);
#endif
            }
        }

        public static void SaveItems(TargetDatabase targetData)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TargetDatabase));
            FileStream stream = new FileStream(_path, FileMode.Create);
            serializer.Serialize(stream, targetData);
            stream.Close();
        }

        public static TargetDatabase LoadItems()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TargetDatabase));
            FileStream stream = new FileStream(_path, FileMode.Open);
            TargetDatabase targetData = serializer.Deserialize(stream) as TargetDatabase;
            stream.Close();
            return targetData;
        }
    }
}
