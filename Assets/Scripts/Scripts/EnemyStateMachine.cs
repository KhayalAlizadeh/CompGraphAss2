using UnityEngine;

public class EnemyStateMachine : StateMachine<EnemyStateMachine.EnemyState> {
    [SerializeField] private AudioSource detectionAudio;
    public enum EnemyState {
        Idle,
        Chase
    }
    protected override State<EnemyState> CreateState(EnemyState key) {
        switch (key) {
            case EnemyState.Idle:
                return new EnemyIdle(this);
            case EnemyState.Chase:
                return new EnemyChase(this);
            default:
                return null;
        }
    }

    public void PlayDetectionAudio() {
        detectionAudio.Play();
    }
}
