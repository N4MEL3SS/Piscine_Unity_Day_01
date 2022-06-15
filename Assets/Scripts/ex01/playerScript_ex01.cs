using UnityEngine;

public class playerScript_ex01 : MonoBehaviour
{
    public bool isMove;
    public float playerSpeed = 2.0f;
    public float move;
    
    public float playerJumpForce = 400.0f;
    public Transform groundCheckLeft;
    public Transform groundCheckRight;
    public LayerMask isGround;
    public bool grounded = true;
    
    public bool checkedBoxAligned = false;
    public bool endGame = false;
    
    private Rigidbody2D rb;

    public void setMove(bool move)
    {
        isMove = move;
    }
    
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (endGame)
            EndGameMove();
        else if (isMove)
        {
            RagdollOn();
            PlayerMove();
            PlayerJump();
        }
        else
            RagdollOff();
    }
    
    private void PlayerMove()
    {
        move = Input.GetAxis("Horizontal");
        
        if (move is > 0 or < 0)
            rb.velocity = new Vector2(move * playerSpeed, rb.velocity.y);
    }

    private void PlayerJump()
    {
        var jump = Input.GetKeyDown("space");

        grounded = Physics2D.Linecast(groundCheckLeft.position, groundCheckRight.position,
            isGround);
        if (jump && grounded && rb.velocity.y < 0.2)
            rb.AddForce(Vector3.up * playerJumpForce);
    }

    private void RagdollOn()
    {
        rb.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
    }
    
    private void RagdollOff()
    {
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
    }

    private void EndGameMove()
    {
        move = 0;
        rb.velocity = new Vector2(move * playerSpeed, rb.velocity.y);
        isMove = false;
    }
    
}
