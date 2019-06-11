using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace TestTask.Gameplay
{
    [System.Serializable]
    public class TargetData
    {
        public Color TargetColor;
        public Type TargetType;
        public int TargetReward;

        public TargetData() { }

        public TargetData(Color color, Type type, int reward)
        {
            TargetColor = color;
            TargetType = type;
            TargetReward = reward;
        }

        public enum Color
        {
            Red,
            Blue,
            Green,
            Yellow,
            Pink
        }

        public enum Type
        {
            Cube,
            Sphere
        }
    }

    [XmlRoot("TargetDatabase")]
    public class TargetDatabase
    {
        public TargetDatabase() { }

        public TargetDatabase(List<TargetData> targetData)
        {
            TargetData = targetData;
        }

        [XmlArray("TargetCollection"), XmlArrayItem("TargetData")]
        public List<TargetData> TargetData;
    }
}
