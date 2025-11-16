using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public abstract class State<EState> where EState : Enum {
    public State(StateMachine<EState> stateMachine) {
        this.stateMachine = stateMachine;
    }
    protected StateMachine<EState> stateMachine;
    public EState Key { get; protected set; }
    public abstract void Enter();
    public abstract void Exit();
    public abstract void Frame(float delta);
    public abstract void PhysicsFrame(float delta);
    public abstract EState GetNextState();
}
