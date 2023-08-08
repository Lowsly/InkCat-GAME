using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Power : MonoBehaviour
{
    public Image powerBar, CD1;

    public Sprite[] powerBarSprite;

    public GameObject _Player;

    Player player;

    private int _maxPower=11, _currentPower, _numbullets = 2;

    public float speed, currentValue = 100; 
    
    void Awake()
    {
        player = _Player.GetComponent<Player>();
    }

    
    void Update()
    {

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
        if (Input.GetKeyDown(KeyCode.Alpha1) && _currentPower>2){
            _currentPower= _currentPower-3; 
            player.ActivateSpecialShoot();
            
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && _currentPower>3){
            _currentPower= _currentPower-4; 
            player.ActivateMultipleShoots(_numbullets);
            
        }
         if (Input.GetKeyDown(KeyCode.Alpha3) && _currentPower>4){
            _currentPower= _currentPower-5; 
            player.ActivateScatterShot();
            
        }
    }
    void SpecialShootTrimode(){

    }
}
