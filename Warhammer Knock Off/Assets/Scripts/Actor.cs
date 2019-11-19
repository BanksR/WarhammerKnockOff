using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Actor : MonoBehaviour
{

    public ActorStats actorStats;
    public WeaponStats weaponStats;
    public Transform particleSpawnPos;



    // Base Actor properties
    public string Unit_Name { get; set; }
    public int Unit_Size { get; set; }
    public int Unit_MovementDist { get; set; }
    public int Unit_Weapon_Skill { get; set; }
    public int Unit_Toughness { get; set; }
    public int Unit_SavingThrow { get; set; }
    public int Unit_HP { get; set; }

    // Base Weapon properties
    public string Weapon_Name { get; set; }
    public int Weapon_Range { get; set; }
    public int Weapon_Strength { get; set; }
    public int Weapon_Attack_Num { get; set; }
    public int Weapon_Damage { get; set; }

    public bool isAlive = true;

    private void Awake()
    {
        Utilities.ChangePhases(Phase.PlayerMovement);
        // Map Scriptable Object data onto fields...
        // Base Actor Stats
        Unit_Name = actorStats.unitName;
        Unit_Size = actorStats.unitSize;
        Unit_MovementDist = actorStats.unitMovementDistance;
        Unit_Weapon_Skill = actorStats.weaponSkill;
        Unit_Toughness = actorStats.unitToughness;
        Unit_SavingThrow = actorStats.unitSavingThrow;
        Unit_HP = actorStats.unitHP;
        // Base Weapon Stats
        Weapon_Name = weaponStats.weaponName;
        Weapon_Range = weaponStats.weaponRange;
        Weapon_Strength = weaponStats.weaponStrength;
        Weapon_Attack_Num = weaponStats.weaponShootAmount;
        Weapon_Damage = weaponStats.weaponDamage;
    }

    public virtual void TakeDamage(int damage)
    {
        if (Unit_HP - damage > 0)
        {
            Unit_HP -= damage;
        }
        else
        {
            Unit_HP = 0;
            KillActor();
        }
    }

    private void KillActor()
    {
        isAlive = false;
        gameObject.SetActive(false);
        Debug.Log(Unit_Name + " is Dead!");
        Utilities.ChangePhases(Phase.PlayerMovement);
    }
}
