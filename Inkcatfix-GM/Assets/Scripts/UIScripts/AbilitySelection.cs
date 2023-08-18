using System.Collections.Generic;
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
public class SelectedAbilities 
{
    public enum SkillName
    {
        MultipleShoot,
        ScatterShot,
        SpecialShoot,
    } 
    
    private List<SkillName> skillnameList;

    public SelectedAbilities() 
    {   
        skillnameList = new List<SkillName>();
    }

    public void UnlockSkill(SkillName skillname)
    {   
        if(!isSkillPresent(skillname))
            skillnameList.Add(skillname);
    }

    public bool isSkillPresent(SkillName skillname)
    {
        return skillnameList.Contains(skillname);
    }
}
