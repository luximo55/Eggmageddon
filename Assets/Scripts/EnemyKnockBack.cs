using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnockBack : MonoBehaviour
{
    [SerializeField] private Fixer kB;
    PlayerController controller;
    Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (kB.knockBack == true)
        {
            if (other.CompareTag("HitBox"))
            {
                rb.constraints = RigidbodyConstraints2D.FreezePositionY;
                Debug.Log("Boom");
                Vector2 difference = transform.position - other.transform.position;
                transform.position = new Vector2(transform.position.x - difference.x, transform.position.y + difference.y);
            }

        }
        rb.constraints = RigidbodyConstraints2D.None;
    }

}