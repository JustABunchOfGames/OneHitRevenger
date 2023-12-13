using UnityEngine;

namespace Core
{
    public class AreaOfEffect : MonoBehaviour
    {
        public string tagToIgnore { private get; set; }

        private void OnTriggerEnter(Collider other)
        {
            IDamageable damageable = other.GetComponent<IDamageable>();
            if (damageable != null && other.tag != tagToIgnore)
                damageable.TakeDamage();
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}