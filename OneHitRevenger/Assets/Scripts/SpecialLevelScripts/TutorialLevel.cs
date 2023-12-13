using System.Collections.Generic;
using UnityEngine;

namespace SpecialLevelScripts
{
    public class TutorialLevel : SpecialLevel
    {
        [System.Serializable]
        public class TutorialTriggerPosition
        {
            public Vector3 position;
            public SpecialTrigger trigger;
        }

        [System.Serializable]
        public class TutorialTriggerPositionList
        {
            public List<TutorialTriggerPosition> list;
        }

        [SerializeField] private List<TutorialTriggerPositionList> _triggerList;
        private int _triggerIndex;
        private int _nbOfTriggerToWait;

        private void Awake()
        {
            _triggerIndex = 0;
            InstantiateTrigger(_triggerIndex++);
        }
        
        private void InstantiateTrigger(int index)
        {
            _nbOfTriggerToWait = _triggerList[index].list.Count;
            foreach (TutorialTriggerPosition triggerPos in _triggerList[index].list)
            {
                SpecialTrigger trigger = Instantiate(triggerPos.trigger, triggerPos.position, Quaternion.identity);
                trigger.trigger.AddListener(GetTriggered);

                
            }
        }
        

        private void GetTriggered()
        {
            if (_triggerIndex >= _triggerList.Count)
            {
                Debug.Log("TutorialComplete");
                // Special Level Complete
                return;
            }
            else
            {
                _nbOfTriggerToWait--;

                if (_nbOfTriggerToWait == 0)
                    InstantiateTrigger(_triggerIndex++);
            }
        }


    }
}