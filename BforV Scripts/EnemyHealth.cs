using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{

        [SerializeField]
        private int minimumCoinReward = 3;
        [SerializeField]
        private int maximumCoinReward = 5;


        public int MinimumCoinReward
        {
            get { return this.minimumCoinReward; }
            set { this.minimumCoinReward = value; }
        }

        public int MaximumCoinReward
        {
            get { return this.maximumCoinReward; }
            set { this.maximumCoinReward = value; }
        }


        public void Reward()
        {
           
        }
    // PrefabSpawner.cs
    // Attach this to any game object that can spawn prefabs for whatever reason
    // (be it coins, gold, explosion particles, etc.).
    public sealed class PrefabSpawner : MonoBehaviour
    {
        [SerializeField]
        private int minimumCount = 3;
        [SerializeField]
        private int maximumCount = 5;
        [SerializeField]
        private GameObject prefab = null;

        public int MinimumCount
        {
            get { return this.minimumCount; }
            set { this.minimumCount = value; }
        }
        public int MaximumCount
        {
            get { return this.maximumCount; }
            set { this.maximumCount = value; }
        }
        public GameObject Prefab
        {
            get { return this.prefab; }
            set { this.prefab = value; }
        }

        public void Spawn()
        {
            // Randomly pick the count of prefabs to spawn.
            int count = Random.Range(this.MinimumCount, this.MaximumCount);
            // Spawn them!
            for (int i = 0; i < count; ++i)
            {
                Instantiate(this.prefab, this.transform.position, Quaternion.identity);
            }
        }
    }

    // IDamagable.cs
    // The interface for something that can take damage.
    public interface IDamagable
    {
        void TakeDamage(float damage, Object instigator);
    }
    // HealthComponent.cs
    // Attach this to any character that has health and can die
    // (be it player or enemy or a destructible chest)
    public sealed class HealthComponent : MonoBehaviour, IDamagable
    {
        [SerializeField]
        private float initialHealth = 100f;
        [SerializeField]
        private float initialMaximumHealth = 100f;

        [SerializeField]
        private UnityEvent onDied;


        private float health;
        private float maximumHealth;


        public float InitialHealth
        {
            get { return this.initialHealth; }
            set { this.initialHealth = Mathf.Max(0f, value); }
        }

        public float InitialMaximumHealth
        {
            get { return this.initialMaximumHealth; }
            set { this.initialMaximumHealth = Mathf.Max(0f, value); }
        }

        public float Health
        {
            get { return this.health; }
            set { this.health = Mathf.Clamp(value, 0f, this.MaximumHealth); }
        }

        public float MaximumHealth
        {
            get { return this.maximumHealth; }
            set { this.maximumHealth = Mathf.Max(0f, value); }
        }


        public UnityEvent DiedEvent
        {
            get { return this.onDied; }
        }


        private void OnEnable()
        {
            this.Health = this.InitialHealth;
            this.MaximumHealth = this.InitialMaximumHealth;
        }

        private void OnDiedEvent()
        {
            var handler = this.onDied;
            if (handler != null)
            {
                handler.Invoke();
            }
        }


        public void TakeDamage(float damage, Object instigator)
        {
            this.Health -= damage;

            // Has the player just died?
            if (Mathf.Approximately(this.Health, 0f))
            {
                this.OnDiedEvent();
            }
        }
    }

}
