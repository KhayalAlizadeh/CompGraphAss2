using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {
    [SerializeField] private float moveSpeed;
    [SerializeField] private float damage;
    [SerializeField] public float detectionRange;
    [SerializeField] public GameObject target;
    private NavMeshAgent agent;
    private Vector3 basePos = Vector3.zero;
    private void Start() {
        basePos = transform.position;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = moveSpeed;
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            collision.gameObject.GetComponent<PlayerStats>().TakeDamage(damage);
            collision.gameObject.GetComponent<PlayerMovement>().ResetPosition();
            ResetPosition();
        }
    }

    private void ResetPosition() {
        transform.position = basePos;
        GetComponent<Animator>().SetInteger("State", (int)EnemyStateMachine.EnemyState.Idle);
    }
}
