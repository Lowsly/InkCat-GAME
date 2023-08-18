using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AbilitiesInfo1 : MonoBehaviour
{
     public Sprite abilityIcon;

     //public AbilitySet1[] button;

     private GameObject button1;

     private int _button;

    void Start (){
        
    }

    public void ButtonAsiggned( GameObject buttonObject){
        
        button1 = buttonObject;
    }

    public void ScatterShot2(){
        Debug.Log(_button);
        AbilitySet1 abilitySet1 = button1.GetComponent<AbilitySet1>(); 
        //button1.GetComponent<Image>().sprite = abilityIcon;
        abilitySet1.Info(abilityIcon);
    }
    public void ScatterShot1(){
        Debug.Log(_button);
        AbilitySet1 abilitySet1 = button1.GetComponent<AbilitySet1>(); 
        //button1.GetComponent<Image>().sprite = abilityIcon;
        abilitySet1.Info(abilityIcon);
    }
}
