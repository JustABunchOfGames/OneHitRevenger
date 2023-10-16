using UnityEditor.Animations;
using UnityEngine;

namespace WeaponScripts
{
    public class Weapon : MonoBehaviour
    {
        [Header("WeaponAnimator")]
        [SerializeField] private AnimatorController _animator;
        public AnimatorController animator { get { return _animator; } private set { } }

        [Header("Grab")]
        [SerializeField] private Vector3 _grabPosition;
        [SerializeField] private Quaternion _grabRotation;

        [Space(5)]
        [Header("OnGround")]
        [SerializeField] private Vector3 _onGroundPosition;
        [SerializeField] private Quaternion _onGroundRotation;

        [Space(5)]
        [Header("AreaOfEffect")]
        [SerializeField] private GameObject _aoeGo;

        public void GetGrabbed(Transform parent)
        {
            transform.SetParent(parent);

            transform.SetLocalPositionAndRotation(_grabPosition, _grabRotation);
        }

        public void PutOnGround(Vector3 position)
        {
            transform.parent = null;
            transform.position = new Vector3(position.x, _onGroundPosition.y, position.z);
            transform.rotation = _onGroundRotation;
        }

        public void CreateAoe(Quaternion playerRotation)
        {
            Instantiate(_aoeGo, transform.position, playerRotation * _aoeGo.transform.rotation);
        }
    }
}