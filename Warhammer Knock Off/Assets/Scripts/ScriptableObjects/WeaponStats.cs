using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Weapon")]
public class WeaponStats : ScriptableObject
{

    public Sprite weaponSprite;
    [Space]
    public string weaponName;

    [Space]
    public int weaponRange;
    public int weaponStrength;
    public int weaponShootAmount;
    public int weaponDamage;
}
