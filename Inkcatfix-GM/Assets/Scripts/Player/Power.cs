using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Power : MonoBehaviour
{
    public Image powerBar, CD1;

    public Sprite[] powerBarSprite, abilityIcons;

    public GameObject _Player;

    private Player player;

    private AbilitySelection _abilitySelection;

    private AbilitySet1 _abilitySet;

    private int _maxPower=11, _currentPower, _numbullets = 2, _button;

    private int[] _requieredPower;

    public float speed, currentValue = 100; 

    
    
    void Awake()
    {
        _abilitySelection = new AbilitySelection();
        player = _Player.GetComponent<Player>();
    }

    public AbilitySelection getAbility(){
        return _abilitySelection;
    }
    void Update()
    {
        if(Time.timeScale!=0 && Health._Death == false){
            currentValue-= speed * Time.deltaTime;
            CD1.fillAmount = currentValue / 100;
            for(int i=0; i<_currentPower+1;i++){
                powerBar.sprite = powerBarSprite[i];
            }
            if (Input.GetButtonDown("Fire3"))
                {
                    _currentPower++; 
                    if(_currentPower+1>_maxPower){
                        _currentPower = _maxPower;
                    }
                }
            if (Input.GetButtonDown("Fire2"))
                {
                    if(_currentPower>0){
                        _currentPower--; 
                    }
                    
                    
                }
                if(_currentPower<0){
                        _currentPower = 0;
                    }
            if (Input.GetKeyDown(KeyCode.Alpha1) && _currentPower>2 && _abilitySelection.isSkillUnlocked(AbilitySelection.SkillType.SpecialShoot)){
                _currentPower-=3; 
                player.ActivateSpecialShoot();
                
            }
            if (Input.GetKeyDown(KeyCode.Alpha2) && _currentPower>3 && _abilitySelection.isSkillUnlocked(AbilitySelection.SkillType.MultipleShoot)){
                _currentPower-=4; 
                player.ActivateMultipleShoots(_numbullets);
                
            }
            if (Input.GetKeyDown(KeyCode.Alpha3) && _currentPower>4 && _abilitySelection.isSkillUnlocked(AbilitySelection.SkillType.ScatterShot)){
                _currentPower-=5; 
                player.ActivateScatterShot();
                
            }
        }
    }

    public void ButtonAsiggned(int number){
        _button = number;
    }

    public void SpecialShoot(){
        _requieredPower[_button] = 3;
        
    }
   

}
