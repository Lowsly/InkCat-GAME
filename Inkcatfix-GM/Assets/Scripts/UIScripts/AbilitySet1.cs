using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AbilitySet1 : MonoBehaviour
{
    [SerializeField] GameObject ability;

    [SerializeField] AbilitiesInfo[] abilitiesInfo;
    
    public Image sprite;
    private Sprite abilityImage;

    public Test1 test1;

    public int _abilityNumber;
    void Awake(){
       ability = this.gameObject;

       
    }
    public void Onclic(){
        test1.ButtonAsiggned(ability);
    }

    public void Info(Sprite Abilityimage){
        sprite.sprite = Abilityimage;
    }

    public void Ability(AbilitiesInfo abilitiesInfo2, int Abnumber){
        this.abilitiesInfo[Abnumber] = abilitiesInfo2;
        _abilityNumber = Abnumber;

    }
}
