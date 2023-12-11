using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MovePower = 10f;
    public float JumpPower = 20f;

    private Rigidbody2D _rb;
    private Animator _anim;
    private Vector3 _movement;
    private int _direction = 1;
    private bool _isJumping;
    private InputAdapter _input;
    private bool _paused;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _input = new InputAdapter();
    }

    private void Update()
    {
        if(_paused)
            return;
        
        Jump();
        Run();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _anim.SetBool("isJump", false);
    }

    void Run()
    {
        Vector3 moveVelocity = Vector3.zero;
        _anim.SetBool("isRun", false);
        
        if(_input.HorizontalInput < 0)
        {
            _direction = -1;
            moveVelocity = Vector3.left;

            transform.localScale = new Vector3(_direction, 1, 1);
            if(!_anim.GetBool("isJump"))
                _anim.SetBool("isRun", true);
        }

        if(_input.HorizontalInput > 0)
        {
            _direction = 1;
            moveVelocity = Vector3.right;

            transform.localScale = new Vector3(_direction, 1, 1);
            if(!_anim.GetBool("isJump"))
                _anim.SetBool("isRun", true);
        }

        transform.position += moveVelocity * MovePower * Time.deltaTime;
    }

    void Jump()
    {
        if((_input.IsJumpPressed || _input.VerticalInput > 0)
           && !_anim.GetBool("isJump"))
        {
            _isJumping = true;
            _anim.SetBool("isJump", true);
        }

        if(!_isJumping)
        {
            return;
        }

        _rb.velocity = Vector2.zero;

        Vector2 jumpVelocity = new Vector2(0, JumpPower);
        _rb.AddForce(jumpVelocity, ForceMode2D.Impulse);

        _isJumping = false;
    }

    public void Pause()
    {
        _paused = true;
    }

    public void Resume()
    {
        _paused = false;
    }
}