using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    private EnemyFactory enemyFactory;
    private CupcakesFactory cupcakeFactory;

    public GameObject cupcake;


    void Start()
    {
        enemyFactory = GameObject.Find("GameManager").GetComponent<EnemyFactory>();
        cupcakeFactory = GameObject.Find("GameManager").GetComponent<CupcakesFactory>();

        StartCoroutine(EnemySpawner());
        StartCoroutine(CupcakeSpawner());
    }


    public IEnumerator EnemySpawner()
    {
        bool flag = true;
        while (flag)
        {
            enemyFactory.GetEnemy();
            yield return new WaitForSeconds(Random.Range(0.45f,1.5f));
        }
    }

    public IEnumerator CupcakeSpawner()
    {
        bool flag = true;
    
        while (flag)
        {

            cupcakeFactory.GetCupcake();
            yield return new WaitForSeconds(Random.Range(4, 8));
        }
    }

  


}