using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class AbilitySet1 : MonoBehaviour
{
    [SerializeField] GameObject ability;

    public AbilitiesInfo[] abilitiesInfo;
    
    public Image sprite;

    public Sprite image;

    public Test1 test1;

    public int _abilityNumber, buttonNumber;

    public float cooldown;

    void Awake()
    {
       ability = this.gameObject;
    }
    public void Onclic(){
        test1.ButtonAsiggned(ability,buttonNumber);
    }

    public void Ability(int Abnumber, Sprite icon, float cooldown)
    {
        _abilityNumber = Abnumber;
        image = icon;
        this.cooldown = cooldown;
        sprite.sprite = image;
        
    }
}
