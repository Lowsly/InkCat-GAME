using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test1 : MonoBehaviour
{
   [SerializeField]  Power power;
   [SerializeField]  UISkills UIskills;
   [SerializeField]  AbilitiesInfo abilitiesInfo;
   public  AbilitySet1 button;

    private int _button;
    public void ButtonAsiggned(int number, AbilitySet1 buttonObject){
        _button = number;
        button = buttonObject;
    }
    void Start()
    {
        UIskills.setPlayerskills(power.getAbility());
    
    }

   
}
