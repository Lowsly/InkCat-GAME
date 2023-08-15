using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySelection 
{
    public enum SkillType
    {
        MultipleShoot,
        ScatterShot,
        SpecialShoot,
    } 
    
    private List<SkillType> unlockedSkillTypeList;

    public AbilitySelection() 
    {   
        unlockedSkillTypeList = new List<SkillType>();
    }

    public void UnlockSkill(SkillType skillType)
    {   
        if(!isSkillUnlocked(skillType))
            unlockedSkillTypeList.Add(skillType);
    }

    public bool isSkillUnlocked(SkillType skillType)
    {
        return unlockedSkillTypeList.Contains(skillType);
    }
}
