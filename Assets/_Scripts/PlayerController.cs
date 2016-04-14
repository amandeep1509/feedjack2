using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//public variables
	public float speed = 0.1F;
	public float jump = 100F;
	public Transform groundCheck;
    public GameObject bulletLeft;
    public GameObject bulletRight;
    public float fireRate;
    public Transform bulletSpot;

    //private instance variables
    private float nextFire;
    private float move;
	private bool doubleJump;
	private bool grounded;
	private bool facingRight;
	private Animator _animator;
	private Transform _transform;
	private Rigidbody2D _rigidbody2D;
	private AudioSource jumpSound;
    private bool canSlide;
    private bool canfire;
    private Vector2 current_Pos;
    // Use this for initialization
    void Start () {
		this._transform = gameObject.GetComponent<Transform> ();
		this._animator = gameObject.GetComponent<Animator> ();
		this._rigidbody2D = gameObject.GetComponent<Rigidbody2D> ();
		this.jumpSound = gameObject.GetComponent<AudioSource> ();
        if (GetLevel() > 1)
        {
            canSlide = true;
            canfire = true;
        }
        else
        {
            canSlide = false;
            canfire = false;
        }
		this.doubleJump = true;
		this.move = 0; 
		this.facingRight = true;
		this.grounded = true;
        fireRate = 1F;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Platform")); 

		move = Input.GetAxis("Horizontal");

		if (move > 0) {
			facingRight = true;
			Flip ();
		} 

		if(move < 0) {
			facingRight = false;
			Flip ();
		}

		if (move != 0) {

			SetAnimation (1);

            PlayerMovement ();
            if (canSlide && Input.GetKeyDown(KeyCode.DownArrow) && grounded)
            {
                StartCoroutine(SlideFunction());
            }
        } else {
			SetAnimation (0);
		}
        Debug.Log(canSlide);


        if (canfire && Input.GetButton("Fire1") && Time.time > nextFire )
        {
            nextFire = Time.time + fireRate;


            if (facingRight)
                Instantiate(bulletRight, bulletSpot.position, Quaternion.identity);
            else
                Instantiate(bulletLeft, bulletSpot.position, Quaternion.identity);

        }



        if (Input.GetKeyDown(KeyCode.Space)) {
			if (grounded) {
				SetAnimation (2);
				jumpSound.Play ();
				_rigidbody2D.velocity = new Vector2 (_rigidbody2D.velocity.x, jump * 10);
				doubleJump = true;
			} else {
				if (doubleJump) {
					SetAnimation (2);
					jumpSound.Play ();
					doubleJump = false;
					_rigidbody2D.AddForce (new Vector2 (_rigidbody2D.velocity.x, jump * 100), ForceMode2D.Impulse);
				}
			}
		}

	}

    IEnumerator SlideFunction()
    {
        SetAnimation(4);
        yield return new WaitForSeconds(3000);
    }

    private int GetLevel()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
    public void SetAnimation(int anim){
		_animator.SetInteger ("animState", anim);
	}

	private void Flip(){
		if (!facingRight)
			this._transform.localScale = new Vector3 (-0.1f, 0.1f);
		else
			this._transform.localScale = new Vector3 (0.1f, 0.1f);
	}

	private void PlayerMovement(){
		_transform.position = new Vector3 (Mathf.Clamp (
			_transform.position.x, -400, 7340), 
			_transform.position.y, 
			_transform.position.z);

		Vector2 _currentPos = _transform.position;
		_currentPos.x += (move * speed);
		_transform.position = _currentPos;
	}


}