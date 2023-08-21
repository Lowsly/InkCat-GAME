using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Power : MonoBehaviour
{
    public Image powerBar, CD1;

    public Image[] CDGraph;

    public Sprite[] powerBarSprite, abilityIcons;

    public GameObject _Player;

    private Player player;

    private AbilitySelection _abilitySelection;

    private AbilitySet1 _abilitySet;

    private int _maxPower=11, _currentPower, _numbullets = 2, _button1, _button2, _button3, _button4;

    public int[] _button, _requieredPower;

    public float[] _cooldown, _AbilityDelay,currentValue; 

    
    
    void Awake()
    {
        //_abilitySelection = new AbilitySelection();
        player = _Player.GetComponent<Player>();
    }

    /*public AbilitySelection getAbility(){
        return _abilitySelection;
    }*/
    void Update()
    {
        if(Time.timeScale!=0 && Health._Death == false){
            
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
            if (Input.GetKeyDown(KeyCode.Alpha1) && _currentPower>_requieredPower[0] && Time.time >_AbilityDelay[0]){
                _currentPower-=_requieredPower[0]; 
                _AbilityDelay[0] = _cooldown[0] + Time.time;
                if(_button[0]>0)
                {
                    StartCoroutine(Graph1());
                }
                
                switch (_button[0]){
                    case 1:
                        player.ActivateScatterShot();
                    break;
                    case 2:
                        player.ActivateMultipleShoots(_numbullets);
                    break;
                    case 3:
                        player.ActivateSpecialShoot();
                    break;
            
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha2) && _currentPower>_requieredPower[1]){
                 _currentPower-=_requieredPower[1]; 
                switch (_button[1]){
                    case 1:
                        player.ActivateScatterShot();
                    break;
                    case 2:
                        player.ActivateMultipleShoots(_numbullets);
                    break;
                    case 3:
                        player.ActivateSpecialShoot();
                    break;
                }  
            }
            if (Input.GetKeyDown(KeyCode.Alpha3) && _currentPower>_requieredPower[2]){
                _currentPower-=_requieredPower[2]; 
                switch (_button[2]){
                    case 1:
                        player.ActivateScatterShot();
                    break;
                    case 2:
                        player.ActivateMultipleShoots(_numbullets);
                    break;
                    case 3:
                        player.ActivateSpecialShoot();
                    break;
                }
            }
             if (Input.GetKeyDown(KeyCode.Alpha4) && _currentPower>_requieredPower[3]){
                _currentPower-=_requieredPower[3]; 
                switch (_button[3]){
                    case 1:
                        player.ActivateScatterShot();
                    break;
                    case 2:
                        player.ActivateMultipleShoots(_numbullets);
                    break;
                    case 3:
                        player.ActivateSpecialShoot();
                    break;
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha9) && _currentPower>4 ){
                _currentPower-=5; 
                player.ActivateScatterShot();
                
            }
            //&& _abilitySelection.isSkillUnlocked(AbilitySelection.SkillType.ScatterShot)
        }
    }

    public void ButtonAsiggned1(int button, int ability, float cool, int cost){
        _button[button] = ability;
        _cooldown[button] = cool;
        _requieredPower[button] = cost;
    }
    public IEnumerator Graph1(){
      
        CDGraph[0].fillAmount = 1;
        float _currentCooldownTimer = _cooldown[0]; 

        while (_currentCooldownTimer > 0)
        {
            float fillValue = _currentCooldownTimer / _cooldown[0]; 
            CDGraph[0].fillAmount = fillValue;
            
            _currentCooldownTimer -= Time.deltaTime; 
            yield return null; 
        }

        CDGraph[0].fillAmount = 0;
    }

}
