using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public int enemyLives = 3;
    public int enemyAttack = 1;
    private Collider2D enemyCollider;
    private GameObject player;
    public bool attacked = false;
    public Dialogue dial;
    private void Awake()
    {
        enemyCollider = GetComponent<Collider2D>();
        player = GameObject.FindWithTag("HitBox");
    }

    public void LifeCheck()
    {
        if (enemyLives <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (player != null)
        {
            if (player.GetComponent<PlayerCombat>().hit)
            {
                player.GetComponent<PlayerCombat>().hit = false;
                enemyLives--;
                LifeCheck();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Dialogue.lineSay = true;
            Debug.Log("Compare");
            attacked = true;
            player.GetComponent<PlayerCombat>().attackedPlayer(enemyAttack);
        }
    }
}