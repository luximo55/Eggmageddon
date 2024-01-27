using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public int playerLives = 5;
    public int playerAttack = 1;
    private Collider2D playerCollider;
    public bool hit = false;
    public bool enemyDetect = false;
    public bool knockBack;
    public bool attackInterval = true;
    private GameObject enemy;
    public GameManager gameManager;
    [SerializeField] private GameObject player;
    [SerializeField] private float timer = 0.1f;
    [SerializeField] private Fixer kB;

    public Dialogue Dialogue;

    private void Awake()
    {
        playerCollider = GetComponent<Collider2D>();
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && attackInterval)
        {
            enemyDetect = true;
            attackInterval = false;
            kB.knockBack = true;
            StartCoroutine(Attacking());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (enemyDetect)
            {
                hit = true;
                knockBack = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        enemyDetect = false;
        kB.knockBack = false;
    }

    public void attackedPlayer(int attackPower)
    {
        enemy = GameObject.FindWithTag("Enemy");
        if (enemy != null)
        {
            if (enemy.GetComponent<EnemyCombat>().attacked)
            {
                playerLives -= attackPower;
                Dialogue.dialogueTriggered = true;
                
                
                Debug.Log($"Lives {playerLives}");
                enemy.GetComponent<EnemyCombat>().attacked = false;
            }
            if (playerLives <= 0)
            {
                Debug.Log("Player Died");
                gameManager.GameOver();
                player.SetActive(false);
            }
        }
    }

    private IEnumerator Attacking()
    {
        yield return new WaitForSeconds(timer);

        attackInterval = true;
        enemyDetect = false;
    }

    
}
