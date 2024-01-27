using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    float timeBtwShots;

    public Transform player;
    

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position)> stoppingDistance)
        {
            transform.position = this.transform.position;
        }
        else if(Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position,player.position, -speed * Time.deltaTime);
        }
    }



}
