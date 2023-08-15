using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AbilitySet1 : MonoBehaviour
{
    public int _buttonNumber;
    [SerializeField] GameObject ability;

    [SerializeField] AbilitiesInfo abilitiesInfo;
    
    public Image sprite;
    private Sprite abilityImage;
    void Awake(){
       
       
    }
    public void Onclic(){
        abilitiesInfo.ButtonAsiggned(this);
    }

    public void Info(Sprite Abilityimage){
        sprite.sprite = Abilityimage;
    }
}
