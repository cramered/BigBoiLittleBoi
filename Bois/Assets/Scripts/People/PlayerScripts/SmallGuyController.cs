using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

//littleBoi Controller
public class SmallGuyController : Character
{
    private Rigidbody2D rb2D;

    [SerializeField]
    private Transform[] groundPoints;

    [SerializeField]
    private float groundRadius;

    [SerializeField]
    private LayerMask whatIsGround;

    private bool isGrounded;

    private bool jump;

    [SerializeField]
    private bool airControl;

    [SerializeField]
    private float jumpForce;

    public UIManager charUIManager;

    public override void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
   
        lives = 1;

        base.Start();
    }

    private void Update()
    {
        HandleInput();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal_2");

        isGrounded = IsGrounded();

        HandleMovement(horizontal);
      
        Flip(horizontal);

        ResetValues();
    }

    private void HandleMovement(float horizontal)
    {
        if (isGrounded || airControl)
        {
            rb2D.velocity = new Vector2(horizontal * movementSpeed, rb2D.velocity.y);
        }

        if (isGrounded && jump)
        {
            isGrounded = false;
            rb2D.AddForce(new Vector2(0, jumpForce));
        }

        MyAnimator.SetFloat("speed", Mathf.Abs(horizontal));

    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            jump = true;
        }
    }

    private void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            ChangeDirection();
        }
    }

    private void ResetValues()
    {
        jump = false;
    }

    private bool IsGrounded()
    {
        if (rb2D.velocity.y <= 0.00001)
        {
            foreach (Transform point in groundPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);
                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }


    IEnumerator RestartTheGameAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public override IEnumerator Hit()
    {
        lives -= 1;
        charUIManager.SetLifes(lives);

        if (lives <= 0)
        {
            StartCoroutine(RestartTheGameAfterSeconds(2.5f));
            SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();
            for (int i = 0; i < sprites.Length; i++)
            {
                Destroy(sprites[i]);
            }
            Destroy(GetComponent<SpriteRenderer>());
        }
        yield return null;
    }


    public override bool IsDead
    {
        get
        {
            return lives <= 0;
        }
    }
}

