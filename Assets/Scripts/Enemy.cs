using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {
    [SerializeField] private float moveSpeed;
    [SerializeField] private float damage;
    [SerializeField] public float detectionRange;
    [SerializeField] public GameObject target;
    private NavMeshAgent agent;
    private void Start() {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = moveSpeed;
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            collision.gameObject.GetComponent<PlayerStats>().TakeDamage(damage);
        }
    }
}
