using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Power : MonoBehaviour
{
    public Image powerBar;

    public Image[] CDGraph, useGraph, abilities;

    public Sprite[] powerBarSprite;

    public GameObject _Player;

    private Player player;

    private AbilitySelection _abilitySelection;

    private AbilitySet1 _abilitySet;

    private int _maxPower=11, _currentPower, _numbullets = 2, _button1, _button2, _button3, _button4;

    public int[] _button, _requieredPower;

    public float[] _cooldown, _AbilityDelay,currentValue;

    private int _buttonNum; 

    public bool[] _Ability;

    
    
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
            if (Input.GetKeyDown(KeyCode.Alpha1) && _currentPower>_requieredPower[0] && _Ability[0] == false &&_button[0]>0){
                _Ability[0] = true;
                _currentPower-=_requieredPower[0]; 
                StartCoroutine(Graph2(0));
                switch (_button[0]){
                    case 1:
                        StartCoroutine(player.ScatterShot(0));
                    break;
                    case 2:
                        StartCoroutine(player.MultipleShoot(_numbullets, 0));
                    break;
                    case 3:
                        StartCoroutine(player.SpecialShoot(0));
                    break;
            
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha2) && _currentPower>_requieredPower[1] && _Ability[1] == false &&_button[1]>0){
                _Ability[1] = true;
                _currentPower-=_requieredPower[1]; 
                StartCoroutine(Graph2(1));
                switch (_button[1]){
                    case 1:
                        StartCoroutine(player.ScatterShot(1));
                    break;
                    case 2:
                        StartCoroutine(player.MultipleShoot(_numbullets, 1));
                    break;
                    case 3:
                        StartCoroutine(player.SpecialShoot(1));
                    break;
            
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha3) && _currentPower>_requieredPower[2] && _Ability[2] == false &&_button[2]>0){
                _Ability[2] = true;
                _currentPower-=_requieredPower[2]; 
                StartCoroutine(Graph2(2));
                switch (_button[2]){
                    case 1:
                        StartCoroutine(player.ScatterShot(2));
                    break;
                    case 2:
                        StartCoroutine(player.MultipleShoot(_numbullets, 2));
                    break;
                    case 3:
                        StartCoroutine(player.SpecialShoot(2));
                    break;
            
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha4) && _currentPower>_requieredPower[3] && _Ability[3] == false &&_button[3]>0){
                _Ability[3] = true;
                _currentPower-=_requieredPower[3]; 
                StartCoroutine(Graph2(3));
                switch (_button[3]){
                    case 1:
                        StartCoroutine(player.ScatterShot(3));
                    break;
                    case 2:
                        StartCoroutine(player.MultipleShoot(_numbullets, 3));
                    break;
                    case 3:
                        StartCoroutine(player.SpecialShoot(3));
                    break;
            
                }
            }
            //&& _abilitySelection.isSkillUnlocked(AbilitySelection.SkillType.ScatterShot)
        }
    }

    public void ButtonAsiggned1(int button, int ability, float cool, int cost){
        _button[button] = ability;
        _cooldown[button] = cool;
        _requieredPower[button] = cost;
        _buttonNum = button;
    }

    public IEnumerator Graph1(int num){   
        _Ability[num] = true;
        CDGraph[num].fillAmount = 1;
        float _currentCooldownTimer = _cooldown[num]; 
        abilities[num].color = new  Color(0.796f, 0.796f, 0.796f);
        while (_currentCooldownTimer > 0)
        {
            float fillValue = _currentCooldownTimer / _cooldown[num]; 
            CDGraph[num].fillAmount = fillValue;
            
            _currentCooldownTimer -= Time.deltaTime; 
            yield return null; 
        }
        _Ability[num] = false;
        abilities[num].color = Color.white;
        CDGraph[num].fillAmount = 0;
    }
        public IEnumerator Graph2(int num){
      
        useGraph[num].fillAmount = 1;
        float _currentCooldownTimer = 10; 

        while (_currentCooldownTimer > 0)
        {
            float fillValue = _currentCooldownTimer /10; 
            useGraph[num].fillAmount = fillValue;
            
            _currentCooldownTimer -= Time.deltaTime; 
            yield return null; 
        }
        useGraph[num].fillAmount = 0;
    }
}
