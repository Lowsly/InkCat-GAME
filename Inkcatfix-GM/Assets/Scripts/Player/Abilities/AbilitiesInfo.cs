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

     public float cooldown;

     [SerializeField] int _numAbility;

    public void AssignAbility(){

        button1 = test1.button1;
        AbilitySet1 abilitySet1 = button1.GetComponent<AbilitySet1>();
        test1.IsUniqueAbility(_numAbility, abilityIcon, cooldown);
        
        
        
    }
}
