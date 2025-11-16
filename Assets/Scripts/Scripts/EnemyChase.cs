using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : State<EnemyStateMachine.EnemyState> {
    private Enemy enemy;
    private GameObject target;
    private NavMeshAgent agent;
    private float distanceFromTarget;
    private int frames = 0;
    public EnemyChase(StateMachine<EnemyStateMachine.EnemyState> stateMachine) : base(stateMachine) {
        Key = EnemyStateMachine.EnemyState.Chase;
    }
    public override void Enter() {
        enemy = stateMachine.GetComponent<Enemy>();
        target = enemy.target;
        agent = enemy.GetComponent<NavMeshAgent>();
    }

    public override void Exit() {
        agent.ResetPath();
    }

    public override void Frame(float delta) {
    }

    public override void PhysicsFrame(float delta) {
        distanceFromTarget = (target.transform.position - enemy.transform.position).magnitude;
        if (frames == 5) {
            agent.SetDestination(target.transform.position);
            frames = 0;
        }
        frames++;
    }
    public override EnemyStateMachine.EnemyState GetNextState() {
        if (distanceFromTarget > enemy.detectionRange) {
            return EnemyStateMachine.EnemyState.Idle;
        }
        return Key;
    }
}
