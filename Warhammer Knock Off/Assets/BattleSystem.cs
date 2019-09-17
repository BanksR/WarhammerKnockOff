using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{

    
    public Weapon playerUnit, enemyUnit;
    public bool playerTurn = true;


    
    private void Update()
    {
        if (Input.anyKeyDown)
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

    public void ResolveAttack(Weapon attacker, Actor defender)
    {
        
        int numberOfHits = 0;
        int numberOfWounds = 0;
        int numberOfMisses = 0;

        for (int i = 0; i < attacker.unitSize * attacker.weaponShootAmount; i++)
        {
            
            if (Utilities.RollToHit(attacker, defender))
            {
                Debug.Log(attacker.unitName + " hits!");
                numberOfHits++;

            }
            else
            {
                Debug.Log(attacker.unitName + " misses");

            }
        }

        //Debug.Log(attacker.unitName + " has " + numberOfHits + " hits. " + defender.unitName + " has a " + defender.unitSavingThrow + " save.");
        for (int i = 0; i < numberOfHits; i++)
        {

            if (Utilities.RollToWound(attacker as Weapon, defender))
            {
                Debug.Log("WOUND!!!");
                numberOfWounds++;
                
            }
            else
            {
                numberOfMisses++;
                Debug.Log("WIFF!!");
            
            }
        }


        if (numberOfWounds > 0)
        {
            ParticleManager.instance.HitParticle(numberOfWounds);
        }
        if (numberOfMisses > 0)
        {
            ParticleManager.instance.MissParticle(numberOfMisses);
        }
        
        
        playerTurn = !playerTurn;

    }

    
}
