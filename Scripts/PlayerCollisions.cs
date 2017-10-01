using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerCollisions : MonoBehaviour {

    public AudioSource hurtsound;
    public AudioSource yeahsound;

    [SerializeField]
    private string enemyTag;

    [SerializeField]
    private string shotTag;

    [SerializeField]
    private string cupcakeTag;

    public GameObject explosion;
    float explosionLifeTime = 0.25f;

    void OnTriggerEnter2D(Collider2D collider)
    {
        float x, y;
        x = collider.gameObject.transform.position.x;
        y = collider.gameObject.transform.position.y;

        if ( collider.gameObject.tag == shotTag)
        {
            hurtsound.Play();
            collider.gameObject.GetComponent<BulletController>().Die();
            GetComponent<PlayerAvatar>().lifeBarSlider.value -= .060f;
            Destroy(Instantiate(explosion, new Vector2(x, y), Quaternion.identity), explosionLifeTime);

        }
        else if(collider.gameObject.tag == enemyTag)
        {
            hurtsound.Play();
            collider.gameObject.GetComponent<AIEnemyBasicEngine>().Die();
            GetComponent<PlayerAvatar>().lifeBarSlider.value -= .080f;
            Destroy(Instantiate(explosion, new Vector2(x, y), Quaternion.identity), explosionLifeTime);

        }
        else if(collider.gameObject.tag==cupcakeTag)
        {
            yeahsound.Play();
            GetComponent<PlayerAvatar>().lifeBarSlider.value += .060f;
            collider.gameObject.GetComponent<CupcakeLifeManager>().Die();

        }
    }

    void Update()
    {
        StayOnScreen();
    }

    void StayOnScreen()
    {
        if (transform.position.x <= -9)
            transform.position = new Vector2(-9, transform.position.y);

        else if (transform.position.x >= 9)
            transform.position = new Vector2(9, transform.position.y);


        if (transform.position.y <= -4)
            transform.position = new Vector2(transform.position.x, -4);

        else if (transform.position.y >= 4)
            transform.position = new Vector2(transform.position.x, 4);
    }
}


