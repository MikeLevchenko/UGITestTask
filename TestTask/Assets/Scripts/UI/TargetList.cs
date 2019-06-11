using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TestTask.Gameplay;

namespace TestTask.UI
{
    public class TargetList : MonoBehaviour
    {
        public event System.Action<TargetData> onEntryClicked;

        [SerializeField]
        private TargetListEntry _entryPrefab;

        private List<TargetListEntry> _entries = new List<TargetListEntry>();

        public void Init()
        {
            List<TargetData> targetData = Utility.XMLLoader.LoadItems().TargetData;

            foreach (TargetData data in targetData)
            {
                TargetListEntry entry = Instantiate(_entryPrefab, transform);
                entry.Init(data);
                entry.onSpawnClicked += RaiseOnEntryClicked;
            }
        }

        private void RaiseOnEntryClicked(TargetData data)
        {
            onEntryClicked?.Invoke(data);
        }
    }
}
