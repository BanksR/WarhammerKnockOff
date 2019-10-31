using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{

    
    public Actor playerUnit, enemyUnit;
    
    public bool playerTurn = true;
    Phase currentPhase;


    
    private void Update()
    {
        if (Input.anyKeyDown && Utilities.currentPhase == Phase.Fight)
        {
            if (playerTurn)
            {
                ResolveAttack(playerUnit, enemyUnit);

            }
            else if (!playerTurn)
            {
                ResolveAttack(enemyUnit, playerUnit);
            }

        }
    }

    public void ResolveAttack(Actor attacker, Actor defender)
    {
        
        int numberOfHits = 0;
        int numberOfWounds = 0;
        int numberOfMisses = 0;

        for (int i = 0; i < attacker.Unit_Size * attacker.Weapon_Attack_Num; i++)
        {
            
            if (Utilities.RollToHit(attacker, defender))
            {
                Debug.Log(attacker.Unit_Name + "hits!");
                numberOfHits++;
                

            }
            else
            {
                Debug.Log(attacker.Unit_Name + " misses");

            }
        }

        //Debug.Log(attacker.unitName + " has " + numberOfHits + " hits. " + defender.unitName + " has a " + defender.unitSavingThrow + " save.");
        for (int i = 0; i < numberOfHits; i++)
        {

            if (Utilities.RollToWound(attacker, defender))
            {
                Debug.Log("WOUND!!!");
                numberOfWounds++;
                attacker.GetComponent<ActorMovmement>()._anims.SetTrigger("Attack");

            }
            else
            {
                numberOfMisses++;
                Debug.Log("WIFF!!");
            
            }
        }


        if (numberOfWounds > 0)
        {
            ParticleManager.instance.HitParticle(numberOfWounds, defender.particleSpawnPos.transform.position);
        }
        if (numberOfMisses > 0)
        {
            ParticleManager.instance.MissParticle(numberOfMisses, defender.particleSpawnPos.transform.position);
        }
        
        
        playerTurn = !playerTurn;

    }

    
}
