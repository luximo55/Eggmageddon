using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float speed;
    public float checkRadius;
    public float attackRadius;

    public bool shouldRotate;

    public LayerMask whatIsPlayer;

    private Transform target;
    private Rigidbody2D rb;
    //private Animator anim;
    private Vector2 movement;
    public Vector3 dir;
    

    private bool isInChaseRange;
    private bool isInAttackRange;

    private bool facingRight = true;
    private float xDirection;

    private void Start()
    {
       
        
        rb = GetComponent<Rigidbody2D>();
        // anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        //anim.SetBool("isRunning", isInChaseRange);

        isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsPlayer);
        isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, whatIsPlayer); // Use attackRadius here

        dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        dir.Normalize();
        movement = dir;
        if (shouldRotate)
        {
            //anim.SetFloat("X", dir.x);
            //anim.SetFloat("Y", dir.y); 
        }


        xDirection = Input.GetAxis("Horizontal");

        Debug.Log(xDirection);

        if (xDirection > 0 && facingRight == false)
        {
            Flip();
        }
        else if (xDirection < 0 && facingRight == true)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        if (isInChaseRange && !isInAttackRange)
        {
            MoveCharacter(movement);
        }
        if (isInAttackRange)
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void MoveCharacter(Vector2 dir)
    {
        rb.MovePosition((Vector2)transform.position + (dir * speed * Time.deltaTime));
    }

    void Flip()
    {
        StartCoroutine(waitforswitch());
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    IEnumerator waitforswitch()
    {
        yield return new WaitForSeconds(0.5f);
    }
}