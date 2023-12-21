using UnityEditor.Animations;
using UnityEngine;
using Core;

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
        [SerializeField] private GameObject _onGroundIndicator;

        private Transform _onGroundParent = null; // Easier to find & clear this way

        [Space(5)]
        [Header("AreaOfEffect")]
        [SerializeField] private AreaOfEffect _aoePrefab;

        private void Start()
        {
            _onGroundParent = GameObject.FindGameObjectWithTag("WeaponManager").transform;

            if (transform.parent == null && transform.rotation != _onGroundRotation)
            {
                PutOnGround(transform.position);
            }
        }

        public void GetGrabbed(Transform parent)
        {
            transform.SetParent(parent);

            transform.SetLocalPositionAndRotation(_grabPosition, _grabRotation);

            _onGroundIndicator.SetActive(false);
        }

        public void PutOnGround(Vector3 position)
        {
            transform.parent = _onGroundParent;
            transform.position = new Vector3(position.x, _onGroundPosition.y, position.z);
            transform.rotation = _onGroundRotation;
            _onGroundIndicator.SetActive(true);
        }

        public void CreateAoe(Transform attacker, string tag)
        {
            AreaOfEffect aoe = Instantiate(_aoePrefab, attacker.position + _aoePrefab.transform.position, attacker.rotation * _aoePrefab.transform.rotation);
            aoe.tagToIgnore = tag;
        }
    }
}