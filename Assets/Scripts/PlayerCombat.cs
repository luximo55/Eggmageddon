using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCombat : MonoBehaviour
{
    public int playerLives = 10;
    public int playerAttack = 2;
    private Collider2D playerCollider;
    public bool hit = false;
    public bool enemyDetect = false;
    public bool knockBack;
    public bool attackInterval = true;
    private GameObject enemy;
    public GameManager gameManager;
    public PlayerAnimator playerAnimator;
    public Text PlayerLivesText;
    [SerializeField] private GameObject player;
    [SerializeField] private float timer = 0.1f;
    [SerializeField] private Fixer kB;

    public Dialogue Dialogue;

    private void Awake()
    {
        playerCollider = GetComponent<Collider2D>();
        player = GameObject.FindWithTag("Player");
        PlayerLivesText.text = playerLives.ToString();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && attackInterval)
        {
            playerAnimator.Hitting();
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

    public void attackedPlayer(GameObject gO)
    {
        //enemy = GameObject.FindWithTag("Enemy");
            EnemyCombat ec = gO.GetComponent<EnemyCombat>(); 
            Debug.Log(ec.attacked);
            if (ec.attacked)
            {
                playerLives -= ec.enemyAttack;
                // Dialogue.dialogueTriggered = true;
                
                PlayerLivesText.text = playerLives.ToString();
                Debug.Log($"Lives {playerLives}");
                ec.attacked = false;
            }
            if (playerLives <= 0)
            {
                Debug.Log("Player Died");
                
                StartCoroutine(AfterDeath());
            }
    }

    private IEnumerator Attacking()
    {

        yield return new WaitForSeconds(timer);

        attackInterval = true;
        enemyDetect = false;
    }

    private IEnumerator AfterDeath()
    {
        playerAnimator.Death();
        yield return new WaitForSeconds(2);
        gameManager.GameOver();
    }


}
