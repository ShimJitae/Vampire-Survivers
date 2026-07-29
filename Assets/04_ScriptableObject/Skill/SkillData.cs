using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillData", menuName = "Scriptable Objects/SkillData")]
public class SkillData : ScriptableObject
{
    public string SkillID;
    public int DamageValue;
    public List<int> ValuesByLevel;
    public GameObject SkillObj;
}
