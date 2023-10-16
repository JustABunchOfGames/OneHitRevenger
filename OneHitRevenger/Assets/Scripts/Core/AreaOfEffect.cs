using UnityEngine;

namespace Core
{
    public class AreaOfEffect : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            IDamageable damageable = other.GetComponent<IDamageable>();
            if (damageable != null)
                damageable.TakeDamage();
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}