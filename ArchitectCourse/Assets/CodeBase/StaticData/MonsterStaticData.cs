using CodeBase.StaticData;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterData", menuName = "StaticData/Monster")]
public class MonsterStaticData : ScriptableObject
{
    public MonsterTypeId MonsterType;

    public int MaxLoot;
    public int MinLoot;

    [Range(1,100)]
    public float Hp;
 
    [Range(1f,30)]
    public float Damage;
    
    [Range(0.5f, 1)]
    public float Cleavage;
 
    [Range(0.5f, 1)]
    public float EffectiveDistance;

    [Range(1, 10)]
    public float MoveSpeed;

    public GameObject Prefab;
}
