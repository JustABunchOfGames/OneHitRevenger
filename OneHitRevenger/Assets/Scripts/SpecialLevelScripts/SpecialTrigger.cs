using UnityEngine;
using UnityEngine.Events;

namespace SpecialLevelScripts
{
    public class SpecialTrigger : MonoBehaviour
    {
        [System.Serializable]
        public enum TriggerState
        {
            TriggerOnEnter,
            TriggerOnDestroy,
            TriggerAndDestroyOnEnter
        }

        [SerializeField] private TriggerState _state;

        public SpecialTriggerEvent trigger = new SpecialTriggerEvent();

        private void OnTriggerEnter(Collider other)
        {
            if (_state == TriggerState.TriggerOnEnter)
            {
                trigger.Invoke();
                Destroy(this);
            }
            else if (_state == TriggerState.TriggerAndDestroyOnEnter)
            {
                trigger.Invoke();
                Destroy(gameObject);
            }
        }

        private void OnDestroy()
        {
            if (_state == TriggerState.TriggerOnDestroy)
                trigger.Invoke();
        }

        public class SpecialTriggerEvent : UnityEvent { }
    }
}