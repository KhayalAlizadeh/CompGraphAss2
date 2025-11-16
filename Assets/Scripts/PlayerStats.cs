using UnityEngine;

public class PlayerStats : MonoBehaviour {
    private float health;
    [SerializeField] private float maxHealth;
    public float Health {
        private get {
            return health;
        }
        set {
            if (value >= maxHealth) {
                health = maxHealth;
            }
            else if (value < 0) {
                health = 0;
                // dead
            }
            else {
                health = value;
            }
        }
    }

    private void Start() {
        health = maxHealth;
    }

    public void TakeDamage(float damage) {
        Health -= damage;
        Debug.Log($"Player Health: {Health}");
    }
}
