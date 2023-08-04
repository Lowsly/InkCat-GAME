using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScatterBullet : MonoBehaviour
{
public GameObject splashEndPrefab, smallBulletPrefab;
    private Rigidbody2D _rigidbody;
  	private bool _isTouching;
    public LayerMask groundLayer;
	public float groundCheckRadius;
	public float speed = 2f;
	public Vector2 direction;
	private Vector3 rot;
	public float livingTime = 3f, damage;
	private SpriteRenderer _renderer;
	private float _startingTime, angleStep, currentAngle;
	private int _bullets = 3;


	void Awake()
	{
		_renderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
	}

	void Start()
    {
		Invoke ("DestroyBullet",0.5f);	
		
    }

    void Update()
    {
		rot = new Vector3(0,0,transform.rotation.eulerAngles.z);
		Vector2 movement = direction.normalized * speed * Time.deltaTime;
		transform.Translate(movement);
		angleStep = 90f/2 / (_bullets - 1); 
		currentAngle = -45/2;
		
		_isTouching = Physics2D.OverlapCircle(transform.position, groundCheckRadius, groundLayer);
		if (_isTouching == true){
			DestroyBullet();
		}
		
    }
	void OnTriggerEnter2D(Collider2D collision)
    {
           HealthEnemy health = collision.GetComponent<HealthEnemy>();
			 if (health == null)
    		{
       			 return;
   			 }
			else{
				health.TakeDamage(damage);
            	DestroyBullet();
			}
    }
	void DestroyBullet(){
		
		GameObject splash = Instantiate (splashEndPrefab, transform.position, Quaternion.identity);
		splash.transform.localScale *= 1.3f;
		for (int i = 0; i < _bullets; i++)
			{
				var firedBullet = Instantiate(smallBulletPrefab,transform.position, Quaternion.Euler(new Vector3(0,0,transform.rotation.eulerAngles.z+currentAngle)));
				firedBullet.transform.localScale *= 1.7f;
				currentAngle += angleStep;
			}
		Destroy(this.gameObject);
	}
	void SummonExtra(){
		
		Instantiate (smallBulletPrefab, new Vector3(0,0.01f,0) + transform.position, Quaternion.identity);
		Instantiate (smallBulletPrefab, new Vector3(0,-0.01f,0) + transform.position, Quaternion.identity);
		
	}
}