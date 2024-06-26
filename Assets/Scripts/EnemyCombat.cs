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
    private PlayerCombat pC;
    private void Awake()
    {
        enemyCollider = GetComponent<Collider2D>();
        player = GameObject.FindWithTag("HitBox");
        pC= player.GetComponent<PlayerCombat>();

    }
    private void Start()
    {
        pC.enabled = true;
    }

    public void LifeCheck()
    {
        if (enemyLives <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (player != null)
        {
            if (player.GetComponent<PlayerCombat>().hit)
            {
                enemyLives--;
                LifeCheck();
                player.GetComponent<PlayerCombat>().hit = false;
            }
            if(other.CompareTag("Player"))
            {
                Dialogue.lineSay = true;
                Debug.Log("Compare");
                attacked = true;
                player.GetComponent<PlayerCombat>().attackedPlayer(gameObject);
            }
        }
    }
}