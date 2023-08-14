using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySelection 
{
    public enum SkillType
    {
        MultipleShoot,
    } 
    
    private List<SkillType> unlockedSkillTypeList;

    public AbilitySelection() 
    {
        unlockedSkillTypeList = new List<SkillType>();
    }

    public void UnlockSkill(SkillType skillType)
    {
        unlockedSkillTypeList.Add(skillType);
    }

    public bool isSkillUnlocked(SkillType skillType)
    {
        return unlockedSkillTypeList.Contains(skillType);
    }
}
