using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody2D _rigid;
    private float _jumpForce = 5.0f;           
    private bool _resetJump = false;
    private LayerMask _groundLayer;    
    private float _speed = 2.5f;

    private PlayerAnimation _playerAnim;
    private SpriteRenderer _playerSprite;
    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _playerAnim = GetComponent<PlayerAnimation>();
        _playerSprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();           
    }


    void Movement()
    {
        float move = Input.GetAxisRaw("Horizontal");

        Flip(move);
        
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() == true)
        {
            _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpForce);            
            StartCoroutine(ResetJumpNeededRoutine());
        }

        _rigid.velocity = new Vector2(move * _speed, _rigid.velocity.y);

        _playerAnim.Move(move);
    }


    bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1f, 1 << 8);

        if (hitInfo.collider != null)
        {
            if (_resetJump == false)
                return true;
        }

        return false;
    }


    void Flip(float move)
    {
        if (move > 0)
        {
            _playerSprite.flipX = false;
        }
        else if (move < 0)
        {
            _playerSprite.flipX = true;
        }
    }

    IEnumerator ResetJumpNeededRoutine()
    {
        _resetJump = true;
        yield return new WaitForSeconds(0.1f);
        _resetJump = false;
    }
}
