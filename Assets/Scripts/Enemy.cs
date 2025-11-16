using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {
    [SerializeField] private float moveSpeed;
    [SerializeField] private float damage;
    [SerializeField] private float detectionRange;
    [SerializeField] private GameObject player;
    private NavMeshAgent agent;
    private float distanceFromPlayer;
    private Vector3 targetPos;
    private bool hasDetected = false;
    private void Start() {
        agent = GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate() {
        distanceFromPlayer = (player.transform.position - transform.position).magnitude;

        if (distanceFromPlayer <= detectionRange) {
            targetPos = player.transform.position;
            hasDetected = true;
            //Debug.Log("enemy detect");
        }
    }
}
