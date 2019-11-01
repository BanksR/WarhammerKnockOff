using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


// Current Phase handled by the Turn Manager
public enum Phase { PlayerMovement, EnemyMovement, Fight };
public class Utilities
{
    
    public delegate void OnPhaseChange();

    public static OnPhaseChange _onPhaseChange;
    
    public static Phase currentPhase { get; set; }

    
    
    


    public static int RollADice(int sides)
    {
       return Mathf.CeilToInt(Random.Range(0f, 1f) * sides);
    }

    public static bool RollToHit(Actor attacker, Actor defender)
    {
        
        if (RollADice(6) >= attacker.Unit_Weapon_Skill)
        {
            return true;
        }

        return false;

        
        
    }


    public static bool RollToWound(Actor attacker, Actor defender)
    {

        
            if (RollADice(6) >= attacker.Unit_Weapon_Skill)
            {
                // Wound, now attempt save
                if (RollADice(6) <= defender.Unit_SavingThrow)
                {
                    // Remove wound from defender
                    defender.TakeDamage(attacker.Weapon_Damage);
                    return true;
                    
                }

            }
            
       
        return false;
        

        
    }

    public static void ChangePhases(Phase changeTo)
    {
        currentPhase = changeTo;
        if (_onPhaseChange != null)
        {
            _onPhaseChange();
        }

        Debug.Log("Changing To: " + changeTo.ToString());
    }
}
