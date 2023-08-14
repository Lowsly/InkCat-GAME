using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	//Bullets
	public GameObject defaultBullet, splashPrefab, shooter, smallBulletPrefab, scatterPrefab;
	private GameObject bulletPrefab;
	private Transform _firePoint;

	//Basic
	public float longIdleTime = 5f;
	public float speed = 2.5f;
	public float jumpForce = 2.5f;

	//Ground

	public Transform groundCheck, rightSide, leftSide;
	public LayerMask groundLayer, enemyLayer;
	public float groundCheckRadius, sideCheckSize, sideSize;

	// References
	private Rigidbody2D _rigidbody;

	private Health health;
	private Animator _animator;

	// Long Idle
	private float _longIdleTimer;

	// Movement
	private Vector2 _movement;
	private bool _facingRight = true;
	private bool _isGrounded;

	// Attack

	private bool _isAttacking;
	private float _cdShoot = 1f, _shootDelay = 0.5f,_cdHeal = 1f,_HealDelay = 0.9f;
	private bool _attackRight = true;
	private bool _attackUp;
	private bool _attackHorizontal;

	public int _bullets=1;
	private float horizontalInput, verticalInput, _angles, _halfangle, angleStep, currentAngle;
	//heal 
	private bool  _rightSided, _leftSided, _side, _specialShoot;

	public static bool _stunned;

	//facing
	float dirX, dirXx;

	Vector3 localScale;



	private Vector2 mousePos;
	void Awake()
	{
		bulletPrefab = defaultBullet;
		_rigidbody = GetComponent<Rigidbody2D>();
		_animator = GetComponent<Animator>();
		_firePoint = transform.Find("FirePoint");
		_stunned = false;
		
	}

	void Start()
    {
		health = GetComponent<Health>();
       
	   localScale = transform.localScale;	  
	
    }

    public void Update()
    {	
		 angleStep = 90f / (_bullets - 1); 
		if(_bullets >1){
			currentAngle = -45;
		}
		if(_bullets == 1){
			currentAngle = 0;
		}
		if(_bullets == 2){
			currentAngle = -45/14;
			angleStep = 90f/14 / (_bullets - 1); 
		}
		horizontalInput = Input.GetAxisRaw("Horizontal");
		verticalInput = Input.GetAxisRaw("Vertical");
		if (_stunned == false && Time.timeScale!= 0 && Health._Death == false)
		{
			dirX = Input.GetAxis ("Horizontal");
			_movement = new Vector2(horizontalInput, 0f);
			_isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
			_rightSided = Physics2D.OverlapBox(rightSide.position, new Vector2(sideCheckSize/sideSize,sideCheckSize), sideCheckSize/2, enemyLayer);
			_leftSided = Physics2D.OverlapBox(leftSide.position, new Vector2(sideCheckSize/sideSize,sideCheckSize), sideCheckSize/2, enemyLayer);
			if(_rightSided == true){
				_side = true;
				_rightSided = false;
			}
			if(_leftSided == true){
				_side = false;
				_leftSided = false;
			}
			if (Input.GetButtonDown("Jump") && _isGrounded == true && _isAttacking == false) {
				_rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
			}
		}
	}
	void OnDrawGizmosSelected(){
		Gizmos.color = new Color(1, 1, 0, 0.75F);
		Gizmos.DrawWireCube(rightSide.position,new Vector2 (sideCheckSize/sideSize,sideCheckSize));
		Gizmos.DrawWireCube(leftSide.position,new Vector2 (sideCheckSize/sideSize,sideCheckSize));

	}
	void FixedUpdate()
	{		
		if(_stunned == false && Time.timeScale!= 0  && Health._Death == false){
			float horizontalVelocity = _movement.normalized.x * speed;
			_rigidbody.velocity = new Vector2(horizontalVelocity, _rigidbody.velocity.y);
			if (Input.GetButton("Fire1") && Time.time > _cdShoot && Input.GetButton("Fire2") == false ) 
			{
				_cdShoot = _shootDelay + Time.time;
				if (_isGrounded == true && horizontalInput == 0 && verticalInput == 0)
				{
					_attackRight =! _attackRight;
					if (_attackRight == true )
					{
						_animator.SetTrigger("ShootRight");
					}
					if (_attackRight == false )
					{
						_animator.SetTrigger("ShootLeft");
					}
				}
				if (_isGrounded == true && (horizontalInput == 1 || horizontalInput == -1) &&  verticalInput == 0 )
				{
					_animator.SetTrigger("ShootWalk");
				}
				if (_isGrounded == true && horizontalInput == 0 && verticalInput == 1)
				{
					_animator.SetTrigger("ShootUp");
				}
				if (_isGrounded == true &&  (horizontalInput == 1 || horizontalInput == -1) && verticalInput == 1)
				{
					_animator.SetTrigger("ShootDiagon");
				
				}
				if (_isGrounded == false && (horizontalInput == 1 || horizontalInput == -1 || horizontalInput == 0)) 
				{
					if(_rigidbody.velocity.y>0.1 && _rigidbody.velocity.y<3.6){
						_animator.SetTrigger("ShootJumpUp");
					}
					if(_rigidbody.velocity.y<0){
						_animator.SetTrigger("ShootJumpDown");
					}
				}
			
			}
			if (_isGrounded == true && Input.GetButton("Fire1") == false && Input.GetButton("Fire2") == true && Time.time > _cdHeal)  
			{
				_cdHeal = _HealDelay + Time.time;			
				health.Heal();

			}
			if (Input.GetButtonDown("Fire3") == true || Input.GetButtonUp("Fire3") == true)
			{
				health.InkUsed();
			}
		}
	}

	void LateUpdate()
	{
		Flip();
		_animator.SetBool("Isidle", _movement == Vector2.zero);
		_animator.SetBool("IsGrounded", _isGrounded);
		_animator.SetFloat("VerticalVelocity", _rigidbody.velocity.y);
		_animator.SetFloat("SpeedShoot", _cdShoot);

		// Animator
		if (_animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack")) 
		{
			_isAttacking = true;
		} 
		else 
		{
			_isAttacking = false;
		}
		// Long Idle
		if (_movement == Vector2.zero) 
		{
			_longIdleTimer += Time.deltaTime;

			if (_longIdleTimer >= longIdleTime) 
			{
				_animator.SetTrigger("Longidle");
			}
		} 
		else 
		{
			_longIdleTimer = 0f;
		}
	}

	public void IsStunned(bool _isImmune){
		if (_isImmune == true)
		{

			StartCoroutine(Stunned());
		}
	}

	public IEnumerator Stunned() 
    {
		if (_stunned == false)
		{
			if (_side == false)
			{
				dirXx = -1;
				Debug.Log("izquierda");
			}
			else 
			{
				Debug.Log("derecha");
				dirXx = 1;
			}
			if (_facingRight == true)
			{
				dirX = 1;
			}
			else 
			{
				dirX =-1;
			}
			_animator.SetTrigger("Stunned");
			
			if(Health.health>-1){
				_rigidbody.velocity = new Vector2((-1*dirX*dirXx)/1.45f, _rigidbody.velocity.y);
			}
			
			_stunned = true;
		}
		yield return new WaitForSeconds(0.5f);
		_stunned = false;
    }

	public void Death()
	{
		_rigidbody.velocity = new Vector2(0,0);
		_rigidbody.gravityScale = 0;

	}
	private void Flip()
	{	
		if (dirX > 0)
			_facingRight = true;
		else
			if (dirX < 0)
				_facingRight = false;
		if (((_facingRight) && (localScale.x < 0)) || ((!_facingRight) && (localScale.x > 0)))
			localScale.x *= -1;
		transform.localScale = localScale;
	}
	public void ShootHor(){
		if(localScale.x >0 )
		{	
			for (int i = 0; i < _bullets; i++)
			{
				var firedBullet = Instantiate(bulletPrefab, _firePoint.position, Quaternion.Euler(0, 0, currentAngle));
				currentAngle += angleStep;
			}
			var splash = Instantiate (splashPrefab, new Vector3 (0f,0.015f,0f) + _firePoint.position, Quaternion.Euler(0,0, 0));
				if(_specialShoot == true){
					var firedBulletSmall = Instantiate (smallBulletPrefab, _firePoint.position, Quaternion.Euler(0,0, 8));
					var firedBulletSmall2 = Instantiate (smallBulletPrefab, _firePoint.position, Quaternion.Euler(0,0, -8));
				}
			
		}
		if(localScale.x < 0 )
		{
			for (int i = 0; i < _bullets; i++)
			{
				var firedBullet = Instantiate(bulletPrefab, _firePoint.position, Quaternion.Euler(0, 0, currentAngle+180));
				currentAngle += angleStep;
			}
				var splash = Instantiate (splashPrefab,new Vector3 (0f,0.015f,0f) + _firePoint.position, Quaternion.Euler(0,0, 180));
				if(_specialShoot == true){
					var firedBulletSmall = Instantiate (smallBulletPrefab, _firePoint.position, Quaternion.Euler(0,0, 172));
					var firedBulletSmall2 = Instantiate (smallBulletPrefab,  _firePoint.position, Quaternion.Euler(0,0, 188));
				}
		}
		
	}
	public void ShootUp()
	{
		for (int i = 0; i < _bullets; i++)
			{
				var firedBullet = Instantiate(bulletPrefab,new Vector3 (localScale.x * -0.345f,0.412f,0f) +  _firePoint.position, Quaternion.Euler(0, 0, currentAngle+90));
				currentAngle += angleStep;
			}
		var splash = Instantiate (splashPrefab, new Vector3 (localScale.x * -0.345f,0.412f,0f) + _firePoint.position, Quaternion.Euler(0,0, 90));
		if(_specialShoot == true){
					var firedBulletSmall = Instantiate (smallBulletPrefab, new Vector3 (localScale.x * -0.345f,0.412f,0f) + _firePoint.position, Quaternion.Euler(0,0, 98));
					var firedBulletSmall2 = Instantiate (smallBulletPrefab, new Vector3 (localScale.x * -0.345f,0.412f,0f) +  _firePoint.position, Quaternion.Euler(0,0, 82));
				}
	}
	public void ShootWalk()
	{
		if(localScale.x >0)
		{
			for (int i = 0; i < _bullets; i++)
			{
				var firedBullet = Instantiate(bulletPrefab, _firePoint.position, Quaternion.Euler(0, 0, currentAngle));
				currentAngle += angleStep;
			}
			var splash = Instantiate (splashPrefab,new Vector3 (0.1f,0.015f,0f) + _firePoint.position, Quaternion.Euler(0,0, 0));
			if(_specialShoot == true){
					var firedBulletSmall = Instantiate (smallBulletPrefab, _firePoint.position, Quaternion.Euler(0,0, 8));
					var firedBulletSmall2 = Instantiate (smallBulletPrefab, _firePoint.position, Quaternion.Euler(0,0, -8));
				}
			
		}
		if(localScale.x < 0)
		{
			for (int i = 0; i < _bullets; i++)
			{
				var firedBullet = Instantiate(bulletPrefab, _firePoint.position, Quaternion.Euler(0, 0, currentAngle+180));
				currentAngle += angleStep;
			}
			var splash = Instantiate (splashPrefab,new Vector3 (-0.1f,0.015f,0f) + _firePoint.position, Quaternion.Euler(0,0, 180));
			if(_specialShoot == true){
					var firedBulletSmall = Instantiate (smallBulletPrefab, _firePoint.position, Quaternion.Euler(0,0, 172));
					var firedBulletSmall2 = Instantiate (smallBulletPrefab,  _firePoint.position, Quaternion.Euler(0,0, 188));
				}
		}
	}
	public void ShootDiagon()
	{
		if(localScale.x >0)
		{
			for (int i = 0; i < _bullets; i++)
			{
				var firedBullet = Instantiate(bulletPrefab,new Vector3 (0.05f,0.264f,0f) + _firePoint.position, Quaternion.Euler(0, 0, currentAngle+40));
				currentAngle += angleStep;
			}
			var splash = Instantiate (splashPrefab, new Vector3 (0.05f,0.264f,0f) + _firePoint.position, Quaternion.Euler(0,0, 40));
			if(_specialShoot == true){
					var firedBulletSmall = Instantiate (smallBulletPrefab, new Vector3 (0.05f,0.264f,0f) + _firePoint.position, Quaternion.Euler(0,0, 48));
					var firedBulletSmall2 = Instantiate (smallBulletPrefab, new Vector3 (0.05f,0.264f,0f) +  _firePoint.position, Quaternion.Euler(0,0, 32));
			}
			
		}
		if(localScale.x <0)
		{
			for (int i = 0; i < _bullets; i++)
			{
				var firedBullet = Instantiate(bulletPrefab,new Vector3 (-0.05f,0.264f,0f) + _firePoint.position, Quaternion.Euler(0, 0, currentAngle+140));
				currentAngle += angleStep;
			}
			var splash = Instantiate (splashPrefab, new Vector3 (-0.05f,0.264f,0f) + _firePoint.position, Quaternion.Euler(0,0, 140));
			if(_specialShoot == true){
					var firedBulletSmall = Instantiate (smallBulletPrefab, new Vector3 (-0.05f,0.264f,0f) + _firePoint.position, Quaternion.Euler(0,0, 148));
					var firedBulletSmall2 = Instantiate (smallBulletPrefab, new Vector3 (-0.05f,0.264f,0f) +  _firePoint.position, Quaternion.Euler(0,0, 132));
			}
		}
	}

	public void ActivateSpecialShoot(){
		StartCoroutine(SpecialShoot());
	}
	public IEnumerator SpecialShoot(){
		_specialShoot = true;
		yield return new WaitForSeconds(10);
		_specialShoot = false;

	}
	public void ActivateMultipleShoots(int _numbullets){
		_bullets = _numbullets;
		StartCoroutine(MultipleShoot());
	}
	public IEnumerator MultipleShoot(){
		yield return new WaitForSeconds(10);
		_bullets = 1;

	}

	public void ActivateScatterShot(){
		bulletPrefab = scatterPrefab;
		StartCoroutine(ScatterShot());
	}
	public IEnumerator ScatterShot(){
		yield return new WaitForSeconds(10);
		bulletPrefab = defaultBullet;

	}
	
}

