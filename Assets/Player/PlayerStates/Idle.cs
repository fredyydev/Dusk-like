using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : State
{
    [SerializeField]
    PlayerScript player;

    public override void OnEnter()
    {
        base.OnEnter();
        Debug.Log("Idle");
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if (player.isMoving)
        {
            stateMachine.SetState(GetComponent<Walking>());
        }
    }
}
