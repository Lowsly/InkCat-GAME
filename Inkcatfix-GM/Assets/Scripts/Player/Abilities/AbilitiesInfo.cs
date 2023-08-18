using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AbilitiesInfo : MonoBehaviour
{
     public Sprite abilityIcon;

     private GameObject button1;

     [SerializeField] Test1 test1;


     [SerializeField] int _numAbility;

    public void AssignAbility(){

        button1 = test1.button1;
        AbilitySet1 abilitySet1 = button1.GetComponent<AbilitySet1>();
        if(test1.IsUniqueAbility(_numAbility)){
            abilitySet1.Ability(this, _numAbility);
            abilitySet1.Info(abilityIcon);
        } 
    }
}
