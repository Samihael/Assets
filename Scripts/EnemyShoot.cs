using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {

    public GameObject fireBall;
    private float InstantiationTimer = 1.5f;
    private BulletFactory factory;

    void Start() {
        factory = GameObject.Find("GameManager").GetComponent<BulletFactory>();

    }

    void Shoot()
    {
        InstantiationTimer -= Time.deltaTime;

        if (InstantiationTimer <= 0)
        {
            factory.GetBullet(this.gameObject, BulletFactory.BulletType.EnemyBullet);
            InstantiationTimer = Random.Range(0.5f,2.5f);
        }    
    }
     
	void Update () {
        Shoot();
    }
}
