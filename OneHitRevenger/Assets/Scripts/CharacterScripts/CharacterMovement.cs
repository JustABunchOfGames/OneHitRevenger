using UnityEngine;
using UnityEngine.Events;

namespace CharacterScripts
{
    public class CharacterMovement : MonoBehaviour
    {
        public MoveEvent moveEvent = new MoveEvent();

        public class MoveEvent : UnityEvent<bool> { }
    }
}