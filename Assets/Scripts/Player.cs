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
        _anim = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rb2D = GetComponent<Rigidbody2D>();
    }

    public override void BaseObjectFixedUpdate()
    {
        Jump();
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        float hrzMovement = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;
        Vector2 pos = new Vector2(transform.position.x + hrzMovement, transform.position.y);

        _rb2D.MovePosition(pos);
     
        PlayRunAnimation(hrzMovement);
        FacePlayerToRightDirection(hrzMovement);
    }

    private void PlayRunAnimation(float hrzMovement)
    {
        if (hrzMovement != 0)
        {
            _anim.SetBool("Run", true);
        }

        else
        {
            _anim.SetBool("Run", false);
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
