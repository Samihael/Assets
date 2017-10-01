using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemyBasicEngine : MonoBehaviour
{

    private void Start()
    {
        GetComponent<Engines>().Speed = new Vector2(-Random.Range(0.5f, 2), 0);
    }


    void OnBecameInvisible()
    {
        Destroy(gameObject);

    }
   

}
