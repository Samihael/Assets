using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour {

    [SerializeField]
    public GameObject enemyPrefab;
    public List<GameObject> Enemies;

    public static EnemyFactory Instance
    {
        get;
        private set;
    }

    private void Awake()
    {
        Debug.Assert(EnemyFactory.Instance == null); //verifier que le singleton n'as pas déja été enregistré
        EnemyFactory.Instance = this;
    }

    public void AddToList(GameObject enemy)
    {
       Enemies.Add(enemy);
    }

    public EnemyFactory GetEnemy()
    {
        float y = Random.Range(-4, 3.5f);
        Vector2 position = new Vector2(10, y);
        if (Enemies.Count == 0)
            Instantiate(enemyPrefab, position, transform.rotation);
                
        else
           {
            GameObject enemy = Enemies[0];
            Enemies.RemoveAt(0);
            enemy.transform.position = position;
            enemy.SetActive(true);
            }

        return this;
	}
    
}
