using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionController : MonoBehaviour
{
   // public AudioSource explosionSound;

    private Text score;
    public int count;
    public GameObject player;
    [SerializeField]
    private string colliderTag;
    public GameObject explosion;
    float explosionLifeTime = 0.25f;

    private void Start()
    {
        player = GameObject.Find("player");
    }
    

    void OnTriggerEnter2D(Collider2D collider)
    {
        float x, y;

        if (collider.gameObject.tag == colliderTag)
        {
            x = collider.gameObject.transform.position.x;
            y = collider.gameObject.transform.position.y;

            count++;
            player.GetComponent<PlayerAvatar>().Count += count;
            Destroy(this.gameObject);
            collider.gameObject.GetComponent<BulletController>().Die();

            Destroy(Instantiate(explosion, new Vector2(x, y), Quaternion.identity), explosionLifeTime);


        }
    }
}
     


       

