using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActorMovement : ActorMovmement
{

    private bool inRange = false;
	// Update is called once per frame
	protected override void Update ()
    {
        base.Update();

        if (Utilities.currentPhase == Phase.PlayerMovement && !CheckForEnemies())
        {
            ClickToMove();
        }

    }

    private void ClickToMove()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        base.DrawMoveLine(transform.position);
        if (Input.GetMouseButtonDown(0) && !inRange && !CheckForEnemies() && !isMoving)
        {
            isMoving = true;
            StartCoroutine(MoveTo(mousePos));
        }
    }

    


    private void OnDrawGizmos()
    {
        if (actorStats != null)
        {
            Gizmos.DrawWireSphere(transform.position, actorStats.Weapon_Range);
        }
        
    }
}
