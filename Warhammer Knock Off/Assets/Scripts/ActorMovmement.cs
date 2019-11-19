using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorMovmement : MonoBehaviour
{

    protected Actor actorStats;
    private int moveRange;
    protected bool isMoving = false;
    public BattleSystem battleSystem;

    public Animator _anims;

    protected void Awake()
    {
        actorStats = GetComponent<Actor>();
        moveRange = actorStats.Unit_MovementDist;
        _anims = GetComponent<Animator>();
    }

    protected virtual void Update()
    {
        _anims.SetBool("IsMoving", isMoving);
    }



    protected virtual void DrawMoveLine(Vector3 startPos)
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        if (Mathf.Abs(Vector3.Distance(startPos, mousePos)) <= actorStats.Unit_MovementDist)
        {
            Debug.DrawLine(startPos, mousePos, Color.green);
        }
        else
        {
            Debug.DrawLine(startPos, mousePos, Color.red);
        }

    }

    protected virtual IEnumerator MoveTo(Vector3 target)
    {
        
        target.z = 0f;
        float distance = Vector3.Distance(transform.position, target);
        Vector3 v = target - transform.position;
        

        while (distance > 0.1f || CheckForEnemies())
        {
            isMoving = true;
            //_anims.SetBool("IsMoving", isMoving);
            transform.Translate(v * Time.deltaTime);
            distance = Vector3.Distance(transform.position, target);
            yield return new WaitForEndOfFrame();
        }

        transform.Translate(Vector3.zero);

        isMoving = false;
        //_anims.SetBool("IsMoving", isMoving);

        yield return null;
    }

    protected bool CheckForEnemies()
    {
        
        Collider2D hit = Physics2D.OverlapCircle(transform.position, actorStats.Weapon_Range);


        if (hit != null && hit.gameObject.CompareTag("Enemy"))
        {
            StopAllCoroutines();
            isMoving = false;
            Debug.Log("Found: " + hit.name);
            Debug.DrawLine(transform.position, hit.transform.position, Color.blue);
            
            battleSystem.playerUnit = this.GetComponent<Actor>();
            BattleCanvas.instance.PlayerActor = this.GetComponent<Actor>();
            
            battleSystem.enemyUnit = hit.GetComponent<Actor>();
            BattleCanvas.instance.EnemyActor = hit.GetComponent<Actor>();
            
            Utilities.ChangePhases(Phase.Fight);

            return true;
        }

        return false;


    }


}
