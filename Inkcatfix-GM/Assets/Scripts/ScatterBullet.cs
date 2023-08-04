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
	public float livingTime = 3f;
	private Transform _angle;
	private float angle;
	private SpriteRenderer _renderer;
	private float _startingTime;


	void Awake()
	{
		_renderer = GetComponent<SpriteRenderer>();
		_angle = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody2D>();
	}

	void Start()
    {
		Health health = GetComponent<Health>();
		_startingTime = Time.time;
		Invoke ("DestroyBullet",0.5f);
		
		
    }

    void Update()
    {
		rot = new Vector3(0,0,transform.rotation.eulerAngles.z);
		Vector2 movement = direction.normalized * speed * Time.deltaTime;
		transform.Translate(movement);
		
		_isTouching = Physics2D.OverlapCircle(transform.position, groundCheckRadius, groundLayer);
		if (_isTouching == true){
			DestroyBullet();
		}
		
    }
	void OnTriggerEnter2D(Collider2D collision)
    {
            Health health = collision.GetComponent<Health>();
            if (health != null)
			{
				health.Hit();
			}
            DestroyBullet();
    }
	void DestroyBullet(){
		
		GameObject splash = Instantiate (splashEndPrefab, transform.position, Quaternion.identity);
		splash.transform.localScale *= 1.3f;
		GameObject bullet1 = Instantiate (smallBulletPrefab,transform.position,Quaternion.Euler(new Vector3(0,0,transform.rotation.eulerAngles.z+10)));
		GameObject bullet2 = Instantiate (smallBulletPrefab,transform.position, Quaternion.Euler(new Vector3(0,0,transform.rotation.eulerAngles.z-10)));
		GameObject bullet3 = Instantiate (smallBulletPrefab,transform.position, Quaternion.Euler(new Vector3(0,0,transform.rotation.eulerAngles.z)));
		bullet1.transform.localScale *= 1.5f;
		bullet2.transform.localScale *= 1.5f;
		bullet3.transform.localScale *= 1.5f;
		Destroy(this.gameObject);
	}
	void SummonExtra(){
		
		Instantiate (smallBulletPrefab, new Vector3(0,0.01f,0) + transform.position, Quaternion.identity);
		Instantiate (smallBulletPrefab, new Vector3(0,-0.01f,0) + transform.position, Quaternion.identity);
		
	}
}