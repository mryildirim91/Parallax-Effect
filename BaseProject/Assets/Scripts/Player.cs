using StarterKit.Base;
using UnityEngine;

public class Player : BaseObject
{
    [SerializeField]
    private float _speed, _jumpForce;

    private Animator _anim;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rb2D;

    private bool _playerJumped = false;

    public override void BaseObjectAwake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _anim = GetComponentInChildren<Animator>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public override void BaseObjectFixedUpdate()
    {
        PlayerMovement();
        Jump();
    }

    private void PlayerMovement()
    {
        float hrzMovement = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;
        Vector3 direction = Vector3.right * hrzMovement;

        transform.Translate(direction);
     
        PlayWalkAnimation(hrzMovement);
        FacePlayerToRightDirection(hrzMovement);
    }

    private void PlayWalkAnimation(float hrzMovement)
    {
        if (hrzMovement != 0)
        {
            _anim.SetBool("Walk", true);
        }

        else
        {
            _anim.SetBool("Walk", false);
        }
    }

    private void FacePlayerToRightDirection(float hrzMovement)
    {
        if (hrzMovement < 0)
        {
            _spriteRenderer.flipX = true;
        }

        else if (hrzMovement > 0)
        {
            _spriteRenderer.flipX = false;
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && !_playerJumped)
        {
            _playerJumped = true;

           _rb2D.AddForce(Vector2.up * _jumpForce * Time.deltaTime, ForceMode2D.Impulse);

            _anim.SetBool("Jump", true);
        }          
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            _playerJumped = false;
            _anim.SetBool("Jump", false);
        }
    }
}
