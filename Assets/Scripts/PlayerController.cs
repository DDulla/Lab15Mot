using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public PlayerData playerData;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public int maxJumps = 2;
    private int jumpsLeft;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    public Color currentColor;

    private PlayerInputActions inputActions;
    private Timer timer;

    void Awake()
    {
        inputActions = new PlayerInputActions();
        inputActions.Gameplay.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        inputActions.Gameplay.Jump.performed += ctx => Jump();
    }

    void OnEnable()
    {
        inputActions.Gameplay.Enable();
    }

    void OnDisable()
    {
        inputActions.Gameplay.Disable();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpsLeft = maxJumps;
        timer = FindObjectOfType<Timer>();
    }

    void Update()
    {
        Move();

        if (playerData.health <= 0)
        {
            EndGame();
        }
    }

    void Move()
    {
        rb.velocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);
    }

    void Jump()
    {
        if (jumpsLeft > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpsLeft--;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpsLeft = maxJumps;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            SpriteRenderer enemyRenderer = collision.gameObject.GetComponent<SpriteRenderer>();
            if (enemyRenderer != null)
            {
                if (enemyRenderer.color == currentColor)
                {
                    Destroy(collision.gameObject);
                }
                else
                {
                    playerData.health--;
                    Destroy(collision.gameObject);

                    if (playerData.health <= 0)
                    {
                        EndGame();
                    }
                }
            }
        }
    }

    public void EndGame()
    {
        float timePlayed = timer.GetTimeElapsed();
        PlayerPrefs.SetFloat("Time", timePlayed);
        playerData.health = 10;
        SceneManager.LoadScene("ResultScreen");
    }

    public bool IsAlive()
    {
        return playerData.health > 0;
    }
}
