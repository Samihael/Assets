using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    [SerializeField]
    private float maxspeed;
    [SerializeField]
    private float minspeed;

    [SerializeField]
    private Vector2 bulletDirection = new Vector2(1,0);
    [SerializeField]
    private BulletFactory.BulletType type;
    private BulletFactory factory;
    [SerializeField]
    private BulletFactory.BulletType Type;
    private BulletFactory.BulletType bulletType;

    private GameObject player;


    void Start()
    {
        factory = GameObject.Find("GameManager").GetComponent<BulletFactory>();
        player = GameObject.FindGameObjectWithTag("player");
        if (type == BulletFactory.BulletType.EnemyBullet)
            bulletType = type;
        else
            bulletType = player.GetComponent<PlayerAvatar>().BulletType;
        
    
            if (bulletType== BulletFactory.BulletType.PlayerBullet)
                bulletDirection = new Vector2(1, 0);
            else if (bulletType == BulletFactory.BulletType.PlayerDiagonalBullet)
                bulletDirection = new Vector2(1, 1);
            
        
    }
    public void Die()
    {
        factory.AddToList(this.gameObject,bulletType);
        this.gameObject.SetActive(false);
    }

    void OnBecameInvisible()
    {
        factory.AddToList(this.gameObject, bulletType);
        this.gameObject.SetActive(false);
    }

    void Update()
    {
        if (bulletType == BulletFactory.BulletType.PlayerSpiralBullet)
        {
            bulletDirection = new Vector2(1, Mathf.Sin(Time.deltaTime * 10000000f));

        }
        transform.Translate(bulletDirection * Random.Range(minspeed,maxspeed) * Time.deltaTime);
   


    }

}
