using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Monster", menuName = "Card/Monster Card")]
public class MonsterScriptableObject : CardScriptableObject
{
    public string monsterType;
    public int monsterLevel, monsterAttack, monsterDefense;
}
