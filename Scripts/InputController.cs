using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputController : MonoBehaviour {

    public GameObject fireBall;
    private BulletFactory factory;
    private BulletFactory.BulletType actualBulletType;
    private float time= 0;

    void Start () {
        factory = GameObject.Find("GameManager").GetComponent<BulletFactory>();
    }

    // Update is called once per frame
    void Update()
    {
        actualBulletType = GetComponent<PlayerAvatar>().BulletType;
        this.GetComponent<Engines>().Speed = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));

        if(Input.GetKey("space"))
        {
            time -= Time.deltaTime;
            if (time <= 0)
                if (GetComponent<PlayerAvatar>().healthBarSlider.value > 0)
                {
                    Vector2 position = transform.position;
                    factory.GetBullet(this.gameObject, GetComponent<PlayerAvatar>().BulletType);
                    GetComponent<PlayerAvatar>().healthBarSlider.value -= .03f;
                    time = 0.2f;
            }
        }

        if (Input.GetKeyDown("tab"))
        {
            if (actualBulletType == BulletFactory.BulletType.PlayerBullet)
                GetComponent<PlayerAvatar>().BulletType = BulletFactory.BulletType.PlayerDiagonalBullet;
            else if (actualBulletType == BulletFactory.BulletType.PlayerDiagonalBullet)
                GetComponent<PlayerAvatar>().BulletType = BulletFactory.BulletType.PlayerSpiralBullet;
            else 
                GetComponent<PlayerAvatar>().BulletType = BulletFactory.BulletType.PlayerBullet;
            


        }
    }

}

