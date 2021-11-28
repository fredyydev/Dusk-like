using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State currentState;

    private void Start()
    {

        /*
        There is always an initial state, so we need
        to call it's enter function on start.
        */
        currentState.OnEnter();
    }

    private void Update()
    {
        currentState.OnUpdate();
    }

    private void FixedUpdate()
    {
        currentState.OnFixedUpdate();
    }

    public void SetState(State desired_state)
    {
        //Call the exit function for the current state
        currentState.OnExit();
        //change current state
        currentState = desired_state;
        //call enter funcion on new state
        currentState.OnEnter();
    }

 }

public abstract class State : MonoBehaviour
{
    //base class for states to inherit from.
    [HideInInspector]
    public StateMachine stateMachine;

    private void Start()
    {
        stateMachine = GetComponent<StateMachine>();
    }

    public virtual void OnEnter()
    {
        //virtual class, called when entering the state.
    }

    public virtual void OnExit()
    {
        //called when exiting the state.
    }

    public virtual void OnUpdate()
    {
        //called every frame while state is active.
    }

    public virtual void OnFixedUpdate()
    {
        //called every fixed update while state is active.
    }
}
