using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class EnemyAI : MonoBehaviour
    {
        [SerializeField] int maxHp;
        [SerializeField] float moveSpeed;
        [SerializeField] Transform checkPoint;
        [SerializeField] float distance;
        [SerializeField] LayerMask groundLayer;
        [SerializeField] LayerMask playerLayer;
        [SerializeField] Transform player;
        [SerializeField] Transform AtkPoint;
        [SerializeField] float attackRange = 10f;
        [SerializeField] float atk = 1f;
        [SerializeField] float retrieveRange = 2.5f;
        [SerializeField] int attackDamage = 5;

        private Animator animator;
        private int currentHp;
        private bool facingRight = true;
        private bool inRange;
        

       void Start() {
            animator = GetComponent<Animator>(); 
            currentHp = maxHp;
       }
        void Update() {
            if (Vector2.Distance(transform.position, player.position) <= attackRange)
            {
                inRange = true;
            }
            else inRange = false;

            if(inRange)
            {
                if(player.position.x < transform.position.x && facingRight == true) {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    facingRight = false;
                } else if(player.position.x > transform.position.x && facingRight == false) {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    facingRight = true;
                }

                if (Vector2.Distance(transform.position, player.position) > retrieveRange)
                {
                    animator.SetBool("Atk", false);
                    transform.position = Vector2.MoveTowards(transform.position, player.position, Time.deltaTime * moveSpeed);
                } else {
                    animator.SetBool("Atk", true);

                    Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(AtkPoint.position, atk, playerLayer);

                    foreach(Collider2D player in hitPlayers)
                    {
                        player.GetComponent<PlayerController>().TakeDamage(attackDamage);
                    }
                }
            } else 
            {
                transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);

                RaycastHit2D hit = Physics2D.Raycast(checkPoint.position, Vector2.down, distance, groundLayer);
                if(hit == false && facingRight) {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    facingRight = false;
                } else if(hit == false && facingRight == false){
                    transform.eulerAngles = new Vector3(0, 0 ,0);
                    facingRight = true;
        }
            }
        
       }

       public void TakeDamage(int damage) {
            currentHp -= damage;
            animator.SetTrigger("Hit");
            if (currentHp <= 0) {
                Die();
            }
       }

       public void Die()
       {
            animator.SetBool("isDead", true);        
            Destroy(gameObject);  
       }

    private void OnDrawGizmosSelected()
    {
        if (checkPoint == null) return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(checkPoint.position, Vector2.down * distance);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);

        if(AtkPoint == null) return;
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(AtkPoint.position, atk);
    }
}