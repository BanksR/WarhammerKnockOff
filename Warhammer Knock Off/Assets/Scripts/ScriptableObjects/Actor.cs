using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="Actor")]
public class Actor : ScriptableObject
{
    public Sprite unitSprite;
    public string unitName;
    public int unitSize;
    [Space]
    public int unitMovementDistance;
    [Space]
    public int weaponSkill;
    public int unitToughness;
    public int unitSavingThrow;
    [Space]
    public int unitHP;

    private bool isAlive = true;

    public void TakeDamage(int damage)
    {
        if (unitHP - damage > 0)
        {
            unitHP -= damage;
        }
        else
        {
            unitHP = 999;
            isAlive = false;
        }
        
    }
}
