using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpecialPlayerAbility", menuName = "Abilities/SpecialPlayerAbility")]
public class PlayerAbility : ScriptableObject
{
    //van nehany beallitasom, amiket nem akarok egy adott objektumhoz kotni
    //illetve repository-t hasznalok, de nem szeretnem, hogy ergy prefab dirty legyen (modosuljon)
    //ezert letrehozok egy scriptableobjectet

    //pelda: passziv special ability, ami karaktertol fugg
    [Header("the speed value 1 means the normal speed")]
    public float movementSpeed = 1;
    public float health = 100;
    public float scaleOnXAndYAxis = 1;
    public string name = string.Empty;
}
