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
        public Image[] abilitySlots;
        private int _button;

    
        public void ButtonAsiggned( GameObject buttonObject, int buttonNumber)
        {
            button1 = buttonObject;
            _button = buttonNumber;
        }
        void Start()
        {
            /*UIskills.setPlayerskills(power.getAbility());*/
        }

        public void IsUniqueAbility(int Abinum, Sprite icon, float cooldown, int cost) 
        {
            int bb = abilitybutton[_button]._abilityNumber;
            int db = abilitybutton[_button].cost;
            float cb = abilitybutton[_button].cooldown;
            Sprite temp = abilitybutton[_button].image;
            abilitybutton[_button].Ability(Abinum, icon, cooldown, cost);
            abilitySlots[_button].sprite = icon;
            power.ButtonAsiggned1(_button, Abinum, cooldown, cost);
            for (int i = 0; i < abilitybutton.Length; i++) {
                if (abilitybutton[_button]._abilityNumber == abilitybutton[i]._abilityNumber ) {
                        abilitybutton[i].Ability(bb, temp, cb, db);
                        power.ButtonAsiggned1(i, bb, cb, db);
                        abilitybutton[_button].Ability(Abinum, icon, cooldown, cost);
                        power.ButtonAsiggned1(_button, Abinum, cooldown, cost);
                        abilitySlots[i].sprite = temp;
                        abilitySlots[_button].sprite = icon;
                }            
            }   
            return;     

    }  
}
