using UnityEngine;
using UnityEngine.AI;

public class EnemyIdle : State<EnemyStateMachine.EnemyState> {
    private Enemy enemy;
    private GameObject target;
    private float distanceFromTarget;
    public EnemyIdle(StateMachine<EnemyStateMachine.EnemyState> stateMachine) : base(stateMachine) {
        Key = EnemyStateMachine.EnemyState.Idle;
    }

    public override void Enter() {
        enemy = stateMachine.GetComponent<Enemy>();
        target = enemy.target;
    }

    public override void Exit() {
    }

    public override void Frame(float delta) {
    }
    public override void PhysicsFrame(float delta) {
        distanceFromTarget = (target.transform.position - enemy.transform.position).magnitude;
    }
    //Before Frame()
    public override EnemyStateMachine.EnemyState GetNextState() {
        if (distanceFromTarget <= enemy.detectionRange) {
            (stateMachine as EnemyStateMachine).PlayDetectionAudio();
            stateMachine.GetComponent<Animator>().SetInteger("State", (int)EnemyStateMachine.EnemyState.Chase);
            return EnemyStateMachine.EnemyState.Chase;
        }
        return Key;
    }
}
