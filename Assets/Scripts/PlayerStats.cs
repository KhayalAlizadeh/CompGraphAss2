using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {
    private float health;
    [SerializeField] private float maxHealth;
    [SerializeField] private AudioSource takeDamageAudio;
    [SerializeField] private Slider healthBar;
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
                Die();
            }
            else {
                health = value;
            }
            healthBar.value = health;
        }
    }

    private void Start() {
        health = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = health;
    }

    public void TakeDamage(float damage) {
        Health -= damage;
        takeDamageAudio.Play();
        Debug.Log($"Player Health: {Health}");
    }

    private void Die() {
        Debug.Log("Application quit");
        Application.Quit();
    }
}
