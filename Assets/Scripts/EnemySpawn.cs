using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject enemyType;
    [SerializeField] private float spaceValue;
    [SerializeField] private float spaceY;
    [SerializeField] private float spaceX;
    [SerializeField] private int numberOfEnemies;
    [SerializeField] private bool isFlipped = false;
    void Update()
    {
        if (numberOfEnemies>0)
        {
            Instantiate(enemyType, new Vector3(spaceX,spaceY,0) + transform.position,Quaternion.identity);
            if (isFlipped == false)
            {
                spaceX += spaceValue;
            }
            else if (isFlipped == true)
            {
                spaceY += spaceValue;
            }
            numberOfEnemies--;
        }
    }
}
