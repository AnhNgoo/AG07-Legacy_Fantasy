using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speedMove = 5f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] int attackDamage = 20;
    [SerializeField] Transform AtkPoint;
    [SerializeField] float attackRange = 0.5f;
    [SerializeField] LayerMask GroundLayer;
    [SerializeField] LayerMask EnemyLayer;
    [SerializeField] Transform GroundCheck;
    [SerializeField] int maxHp = 100;
    
   
    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded;
    private int currentHp;
     

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake() {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleJump();
        HandleAtk();
        UpdateAnimation();
    }

    public void HandleMovement()
    {

        if(Input.GetKeyDown(KeyCode.J)) return;
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * speedMove, rb.linearVelocity.y);

        if(moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        } else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    public void HandleJump()
    {

        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, GroundLayer); 

        if(Input.GetButtonDown("Jump")  && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
             AudioManager.instance.PlaySFX(AudioManager.instance.JumpSFX);
        }
    }

    public void HandleAtk()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            animator.SetTrigger("Atk");;

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AtkPoint.position, attackRange, EnemyLayer);

            foreach(Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<EnemyAI>().TakeDamage(attackDamage);
            }
        }
    }

    public void UpdateAnimation()
    {
        bool isRunning = Mathf.Abs(rb.linearVelocity.x) > 0.1f;
        bool isJump = !isGrounded;
        animator.SetBool("Running", isRunning);
        animator.SetBool("Jumping", isJump);
    }

    public void TakeDamage(int damage) {
            currentHp -= damage;
            if (currentHp <= 0) {
                Die();
            }
       }

       public void Die()
       {
            animator.SetBool("isDead", true);
            Time.timeScale = 0;
            AudioManager.instance.StopBMGMusic();
       }

    public void OnDrawGizmosSelected() {
        if(AtkPoint == null) return;
        Gizmos.DrawWireSphere(AtkPoint.position, attackRange);
    }
}
