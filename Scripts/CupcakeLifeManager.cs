using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupcakeLifeManager : MonoBehaviour {
    private CupcakesFactory factory;
    private float cupcakeLifeTime = 3f;

    // Use this for initialization
    void Start () {
        factory = GameObject.Find("GameManager").GetComponent<CupcakesFactory>();
    }

    void Update() {
        cupcakeLifeTime -= Time.deltaTime;
        if (cupcakeLifeTime <= 0)
        {
            Die();
            cupcakeLifeTime = 3f;
        }
            
    }

    public void Die()
    {
        factory.AddToList(this.gameObject);
        this.gameObject.SetActive(false);
    }
}
