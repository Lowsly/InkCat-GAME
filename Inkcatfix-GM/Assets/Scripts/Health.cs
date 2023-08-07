using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Health : MonoBehaviour
{
    public int health, numHearts;

    public GameObject player;

    public Image hearts, Ink;

    public Sprite Ink5Uses,Ink4Uses, Ink3Uses, Ink2Uses, Ink1Uses,InkBroken0, InkBroken1, InkBroken2,OneHeart, fullBar, mediumBar, emptyBar;

    private Animator _animator;

    public Color dmgColor, originalColor;
    
    private bool _noJar, _isImmune, _lowHealth, _uniqueJarBreak;

    private int _maxInk = 5,_inkUses = 5;

    private SpriteRenderer _renderer;

    private float colorTime, colorTime2, colorTime3; 

    
     void Start(){
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        
        if(_inkUses < 0)
        {
            _inkUses = 0;
        }

        switch (health)
        {
            case 0:
                hearts.sprite = emptyBar;
            break;
            case 1:
                hearts.sprite = OneHeart;
            break;
            case 2:
                hearts.sprite = mediumBar;
            break;
            case 3:
                hearts.sprite = fullBar;
            break;
        }
        if (_noJar == false){
            if(_inkUses==1){
                 _uniqueJarBreak = true;
            }
            if(_inkUses!=1){
                _uniqueJarBreak = false;
            }
            if(_inkUses < 1){
                Ink.sprite = InkBroken0;
                
                _noJar = true;
                
            }
            if(_inkUses == 1){
                Ink.sprite = Ink1Uses;
            }
            if(_inkUses == 2){
                Ink.sprite = Ink2Uses;
            }
            if(_inkUses == 3){
                Ink.sprite = Ink3Uses;
            }
            if(_inkUses == 4){
                Ink.sprite = Ink4Uses;
            }
            if(_inkUses == 5){
                Ink.sprite = Ink5Uses;
            }
        }
        if (_noJar == true) {
            
            _maxInk = 2;
            if (_inkUses > 2){
                _inkUses = 2;
            }
            if(_inkUses == 2){
                Ink.sprite = InkBroken2;
            }
             if(_inkUses == 1){
                Ink.sprite = InkBroken1;
            }
            if(_inkUses == 0){
                Ink.sprite = InkBroken0;
            }
        }
    }
    public void Hit()
    {   
        
        if (_isImmune == false){
            StartCoroutine(Immune());
           
            StartCoroutine(Damaged());
            health = health - 1;
            if(health>0){
                StartCoroutine(HeartColor());
            }
             
            
            if (health == 0){
                _lowHealth = true;
                StartCoroutine(LowHealth());
            }
            if (health <= -1){
                Debug.Log("Sht");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            } 
        }
    }
    public void Heal()
    {
        if (_inkUses > 0){
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            if (horizontalInput == 0 && _uniqueJarBreak == false){
                _animator.SetTrigger("Heal");
            }
            if (horizontalInput == 0 && _uniqueJarBreak == true){
                    _animator.SetTrigger("HealBreak");
                    _uniqueJarBreak = false;
                }
            if (horizontalInput != 0 && _uniqueJarBreak == false){
                _animator.SetTrigger("HealWalk");
            }
             if (horizontalInput != 0 && _uniqueJarBreak == true){
                _animator.SetTrigger("HealWalkBreak");
                _uniqueJarBreak = false;
            }
           
        }
    }

    public void Healed()
    {
        _lowHealth = false;
        health = health + 1;
        _inkUses = _inkUses -1;   
        if (health > 3){
            health = 3;
        }
    }
    public void InkUsed(){
        if (_inkUses < _maxInk){
            _inkUses = _inkUses + 1;
        }
        if (_inkUses > _maxInk) {
            _inkUses = _maxInk;
        }
    }

    IEnumerator HeartColor()
    {
            hearts.color = Color.red;
       yield return new WaitForSecondsRealtime(1f);
            hearts.color = Color.white;
    }

    IEnumerator Damaged()
    {
        for (int i = 0; i < 6; i++)
            {
             _renderer.color = new Color (0, 0, 0, 0f);
             yield return new WaitForSecondsRealtime(.1f);
             _renderer.color = Color.white;
             yield return new WaitForSecondsRealtime(.1f);
            }
        
    }

    IEnumerator Immune() 
    {
        Player player = GetComponent<Player>();
        _isImmune = true;
        player.IsStunned(_isImmune);
        yield return new WaitForSecondsRealtime(1f);
        _isImmune = false;
        player.IsStunned(_isImmune);
    }
    IEnumerator LowHealth() 
    {
        while (_lowHealth == true){
                hearts.color = Color.red;
            yield return new WaitForSecondsRealtime(0.45f);
                hearts.color = Color.white;
            yield return new WaitForSecondsRealtime(0.45f);
        }
        yield return null;
    }
}
