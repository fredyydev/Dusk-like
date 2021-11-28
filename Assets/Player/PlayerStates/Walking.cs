using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : State
{
    [SerializeField]
    PlayerScript player;

    [SerializeField]
    Transform playerTransform;

    public override void OnEnter()
    {
        base.OnEnter();
        Debug.Log("Walking");
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();

        Vector3 movementAxes = playerTransform.right * Input.GetAxisRaw("Horizontal") + playerTransform.forward * Input.GetAxisRaw("Vertical");

        Vector2 finalAxis = new Vector2(movementAxes.x, movementAxes.z);

        player.MoveChar(finalAxis);

        if (!player.isMoving)
            stateMachine.SetState(GetComponent<Idle>());
    }
}
