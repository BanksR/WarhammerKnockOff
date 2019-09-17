using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities
{

    public static int RollADice(int sides)
    {
       return Mathf.CeilToInt(Random.Range(0f, 1f) * sides);
    }

    public static bool RollToHit(Weapon attacker, Actor defender)
    {
        
        if (RollADice(6) >= attacker.weaponSkill)
        {
            return true;
        }

        return false;

        
        
    }


    public static bool RollToWound(Weapon attacker, Actor defender)
    {

        
            if (RollADice(6) >= attacker.weaponStrength)
            {
                // Wound, now attempt save
                if (RollADice(6) <= defender.unitSavingThrow)
                {
                    // Remove wound from defender
                    defender.TakeDamage(attacker.weaponDamage);
                    return true;
                    
                }

            }
            
       
        return false;
        

        
    }
}
