using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Test1 : MonoBehaviour
{
   [SerializeField]  Power power;
   [SerializeField]  UISkills UIskills;
   [SerializeField]  AbilitiesInfo abilitiesInfo;
    public GameObject button1;
    public AbilitySet1[] abilitybutton;
    private int _button;

    private bool possible;
    public void ButtonAsiggned( GameObject buttonObject){
        
        button1 = buttonObject;
    }
    void Start()
    {
        UIskills.setPlayerskills(power.getAbility());
    
    }

    public bool IsUniqueAbility(int Abinum) {
    for (int i = 0; i < abilitybutton.Length; i++) {
        if (Abinum == abilitybutton[i]._abilityNumber) {
            return false; 
        }
    }
    
    return true; 
    }  
}
