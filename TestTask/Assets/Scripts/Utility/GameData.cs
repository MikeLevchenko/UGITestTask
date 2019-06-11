using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TestTask.Gameplay;

namespace TestTask.Resources
{
    [CreateAssetMenu(menuName = "ScriptableObjects/GameData")]
    public class GameData : ScriptableObject
    {
        private static GameData instance;

        public static GameData Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = UnityEngine.Resources.Load<GameData>("GameData");
#if UNITY_EDITOR
                    if (instance == null)
                    {
                        instance = CreateInstance<GameData>();

                        UnityEditor.AssetDatabase.CreateAsset(instance, "Assets/Resources/GameData.asset");
                        UnityEditor.AssetDatabase.SaveAssets();
                    }
#endif
                }
                return instance;
            }
        }

        public List<TargetPrefab> Prefabs = new List<TargetPrefab>();
        public List<TargetListEntrySprite> Sprites = new List<TargetListEntrySprite>();
        public List<TargetListEntryColor> Colors = new List<TargetListEntryColor>();

        public Sprite GetSprite(TargetData.Type type)
        {
            Sprite targetSprite = Sprites.Find(sprite => sprite.Type == type).Sprite;
            if (targetSprite == null)
                throw new System.Exception("No sprite for this target type is set");
            return targetSprite;
        }

        public Color GetColor(TargetData.Color colorName)
        {
            Color targetColor = Colors.Find(color => color.ColorName == colorName).Color;
            if (targetColor == null)
                throw new System.Exception("No color for this target type is set");
            return targetColor;
        }

        public Target GetPrefab(TargetData.Type type)
        {
            Target target = Prefabs.Find(prefab => prefab.Type == type).Target;
            if (target == null)
                throw new System.Exception("No prefab for this target type is set");
            return target;
        }
    }

    [System.Serializable]
    public class TargetListEntrySprite
    {
        public Sprite Sprite;
        public TargetData.Type Type;
    }

    [System.Serializable]
    public class TargetListEntryColor
    {
        public Color Color;
        public TargetData.Color ColorName;
    }

    [System.Serializable]
    public class TargetPrefab
    {
        public Target Target;
        public TargetData.Type Type;
    }
}
