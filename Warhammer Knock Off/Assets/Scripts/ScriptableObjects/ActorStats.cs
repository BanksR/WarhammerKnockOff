using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="Actor")]
public class ActorStats : ScriptableObject
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

    
}
