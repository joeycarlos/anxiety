using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float movementSpeed;
    public float jumpForce;
    private Rigidbody2D rb;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    
    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

    public float maxDashTime = 1.0f;
    public float dashSpeed = 1.0f;
    private float currentDashTime;
    private Vector2 moveDirection;
    private float dashGracePeriod;
    private List<GameObject> collectibleIndicatorList = new List<GameObject>();
    private List<float> collectibleFollowDistance = new List<float>();


    private int dashCharges;
    public int maxDashCharges;

    private GameObject cIndicator;
    public GameObject collectibleIndicator;

    private SpriteRenderer sr;

    private GameObject boss;

    public Animator playerAnimator;


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        currentDashTime = maxDashTime;
        dashGracePeriod = 0.0f;
        sr = GetComponent<SpriteRenderer>();
        dashCharges = 0;
        boss = GameObject.Find("BossEntity");
        
    }

    void Update()
    {

        PlayerJump();
        PlayerDash();
        MovePlayer();
        

    }

    void PlayerJump()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        playerAnimator.SetBool("isJumping", !isGrounded);

        if (isGrounded == true && Input.GetKeyDown(KeyCode.UpArrow))
        {
            isJumping = true;
            
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetKey(KeyCode.UpArrow) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }


        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            isJumping = false;
        }
    }

    void PlayerDash()
    {
        if (Input.GetKeyDown(KeyCode.Space) && dashCharges > 0)
        {
            dashCharges --;
            currentDashTime = 0.0f;
            dashGracePeriod = 0.0f;
            // dashCooldownTimer = dashCooldown;
            Physics2D.IgnoreLayerCollision(10, 8);
            Physics2D.IgnoreLayerCollision(10, 11);
            Destroy(collectibleIndicatorList[dashCharges]);
            collectibleIndicatorList.RemoveAt(dashCharges);

            boss.GetComponent<BossController>().IncrementBossSpeed();

            

            sr.color = Color.cyan;

            if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow))
            {
                moveDirection = new Vector2(-1.0f, 2.0f);
                moveDirection = moveDirection.normalized;
            }
            else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
            {
                moveDirection = new Vector2(1.0f, 2.0f);
                moveDirection = moveDirection.normalized;
            }

            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                moveDirection = Vector2.left;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                moveDirection = Vector2.right;
            }
            else
            {
                moveDirection = Vector2.up;
            }
            moveDirection *= dashSpeed;
        }

        if (currentDashTime < maxDashTime)
        {
            currentDashTime += Time.deltaTime;
            rb.velocity = moveDirection;


        }
        else if (dashGracePeriod < 0.05f)
        {
            rb.velocity = Vector2.zero;
            dashGracePeriod += Time.deltaTime;
            sr.color = Color.white;
            Physics2D.IgnoreLayerCollision(10, 8, false);
            Physics2D.IgnoreLayerCollision(10, 11, false);
        }

        // dashCooldownTimer -= Time.deltaTime;
        // dashCooldownTimer = Mathf.Clamp(dashCooldownTimer, -1.0f, dashCooldown);
    }

    void MovePlayer()
    {
        float moveValue = Input.GetAxisRaw("Horizontal") * movementSpeed * Time.deltaTime;
        Vector3 moveVector = new Vector3(moveValue, 0, 0);
        transform.Translate(moveVector);
        
        if (moveValue < 0)
        {
            sr.flipX = true;
        } else if (moveValue > 0)
        {
            sr.flipX = false;
        }

        playerAnimator.SetFloat("Speed", Mathf.Abs(moveValue));

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            FindObjectOfType<GameManager>().EndGame();
        }
        else if (collision.tag == "Collectible" && dashCharges < maxDashCharges)
        {
            dashCharges++;
            dashCharges = Mathf.Clamp(dashCharges, 0, maxDashCharges);
            cIndicator = Instantiate(collectibleIndicator, transform.position, Quaternion.identity);
            collectibleIndicatorList.Add(cIndicator);
            collectibleIndicatorList[dashCharges - 1].GetComponent<CollectibleIndicatorController>().setIndicatorFollowDistance(dashCharges);
            //cIndicator = Instantiate(collectibleIndicator, transform.position, Quaternion.identity);
            // collectibleIndicatorList.Add(cIndicator);
        }
        else if (collision.tag == "Trap")
        {
            FindObjectOfType<GameManager>().AcornTrap();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            FindObjectOfType<GameManager>().EndGame();
        }
        else if (collision.collider.tag == "WinTrigger")
        {
            FindObjectOfType<GameManager>().ProceedGame();
        }
        
    }

    public int GetDashCharges()
    {
        return dashCharges;
    }

    public int GetMaxDashCharges()
    {
        return maxDashCharges;
    }
}