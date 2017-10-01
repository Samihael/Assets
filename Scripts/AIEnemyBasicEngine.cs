using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemyBasicEngine : MonoBehaviour
{
    private EnemyFactory factory;

    private void Start()
    {
        factory = GameObject.Find("GameManager").GetComponent<EnemyFactory>();
        GetComponent<Engines>().Speed = new Vector2(-Random.Range(0.2f, 2), 0);
    }

    void OnBecameInvisible()
    {
        Die();
    }
    public void Die()
    {
        factory.AddToList(this.gameObject);
        this.gameObject.SetActive(false);
    }
 

}
