using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine<Estate> : MonoBehaviour where Estate : Enum {
    [SerializeField] private Estate initialStateKey;
    [SerializeField] private List<Estate> stateKeys = new();
    protected Dictionary<Estate, State<Estate>> states = new();
    private State<Estate> initialState;
    private State<Estate> currentState;
    bool isTransitioningState = false;
    public void Awake() {
        foreach (Estate stateKey in stateKeys) {
            states.Add(stateKey, CreateState(stateKey));
        }
        initialState = states[initialStateKey];
    }
    public void OnEnable() {
        currentState = initialState;
        currentState.Enter();
    }

    public void Update() {
        Estate nextStateKey = currentState.GetNextState();

        if (!isTransitioningState && nextStateKey.Equals(currentState.Key)) {
            currentState.Frame(Time.deltaTime);
        }
        else {
            TransitionToState(nextStateKey);
        }
    }

    public void FixedUpdate() {
        if (currentState != null) {
            currentState.PhysicsFrame(Time.fixedDeltaTime);
        }
    }

    private void TransitionToState(Estate stateKey) {
        isTransitioningState = true;
        currentState.Exit();
        currentState = states[stateKey];
        currentState.Enter();
        isTransitioningState = false;
    }
    protected abstract State<Estate> CreateState(Estate key);
}
