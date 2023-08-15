using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AbilitiesInfo : MonoBehaviour
{
     public Sprite abilityIcon;

     public AbilitySet1[] button;

     private int _button;

    void Start (){
        
    }

    public void ButtonAsiggned( AbilitySet1 buttonObject){
        
        button[_button] = buttonObject;
    }

    public void ScatterShot(){
        Debug.Log(_button);
        button[_button].GetComponent<Image>().sprite = abilityIcon;
        button[_button].Info(abilityIcon);
    }
}
