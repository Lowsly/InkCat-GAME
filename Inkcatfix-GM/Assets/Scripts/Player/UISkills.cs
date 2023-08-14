using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISkills : MonoBehaviour
{
   private AbilitySelection abilitySelection;

   public void setPlayerskills(AbilitySelection abilitySelection){
        this.abilitySelection = abilitySelection;
   }

   public void Clic()
   {
        abilitySelection.UnlockSkill(AbilitySelection.SkillType.MultipleShoot);
   }
}   
