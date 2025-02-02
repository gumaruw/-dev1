using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpForce = 50f;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    private bool Ground;
    private bool started;
    private bool Jump;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        Ground = true;
    }

    private void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            if(started && Ground) {
                _animator.SetTrigger("Jump");
                Ground = false;
                Jump = true;
            }
        }
        else
        {
            _animator.SetBool("GameStarted", true);
            started = true;
        }
        
            _animator.SetBool("Ground", Ground);
        
    }

    private void FixedUpdate()
    {
        if(started)
        {
            _rigidbody2D.velocity = new Vector2(speed, _rigidbody2D.velocity.y);
        }

        if(Jump)
        {
            _rigidbody2D.AddForce(new Vector2(0f, jumpForce));
            Jump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("ground")){
            Ground = true;
        }
    }
}
