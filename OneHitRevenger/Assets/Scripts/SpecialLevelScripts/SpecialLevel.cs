using UnityEngine;
using UnityEngine.Events;

namespace SpecialLevelScripts
{
    public abstract class SpecialLevel : MonoBehaviour
    {
        [SerializeField] private bool _hasSpecialWinCondition;
        public bool hasSpecialWinCondition { get { return _hasSpecialWinCondition; } protected set { _hasSpecialWinCondition = value; } }
    }
}