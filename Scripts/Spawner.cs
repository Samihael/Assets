using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    public GameObject enemyPrefab;
    private CupcakesFactory cupcakeFactory;


    void Start()
    {
        cupcakeFactory = GameObject.Find("GameManager").GetComponent<CupcakesFactory>();

        StartCoroutine(EnemySpawner());
        StartCoroutine(CupcakeSpawner());
    }


    public IEnumerator EnemySpawner()
    {
    
        bool flag = true;
        while (flag)
        {
            float y = Random.Range(-4, 3.5f);
            Vector2 position = new Vector2(12, y);
            Instantiate(enemyPrefab, position, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(0.3f, 2));
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
 