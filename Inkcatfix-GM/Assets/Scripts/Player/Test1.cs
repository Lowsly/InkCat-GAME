using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;
public class Test1 : MonoBehaviour
{
    
    

    [SerializeField]  Power power;
    [SerializeField]  UISkills UIskills;
    //[SerializeField]  AbilitiesInfo abilitiesInfo;
        public GameObject button1;
        public AbilitySet1[] abilitybutton;
        private int _button;

    
        public void ButtonAsiggned( GameObject buttonObject, int buttonNumber){
            
            button1 = buttonObject;
            _button = buttonNumber;
        }
        void Start()
        {
            UIskills.setPlayerskills(power.getAbility());
        
        }

        public void IsUniqueAbility(int Abinum, Sprite icon, float cooldown) {
        int bb = abilitybutton[_button]._abilityNumber;
        Sprite temp = abilitybutton[_button].image;
        abilitybutton[_button].Ability(Abinum, icon, cooldown);
       
        for (int i = 0; i < abilitybutton.Length; i++) {
            if (abilitybutton[_button]._abilityNumber == abilitybutton[i]._abilityNumber ) {
                int ab = abilitybutton[i]._abilityNumber;
                abilitybutton[i].Ability(bb, temp, abilitybutton[_button].cooldown);
                abilitybutton[_button].Ability(ab, icon, cooldown);
                Debug.Log(_button + "  " + i);

            }            
        }   
        return;     

    }  
}
