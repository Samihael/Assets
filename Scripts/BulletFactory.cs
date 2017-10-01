using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : MonoBehaviour {

    [SerializeField]
    public GameObject playerBulletPrefab;
    [SerializeField]
    public GameObject playerSpiralBulletPrefab;
    [SerializeField]
    public GameObject playerDiagonalBulletPrefab;
    [SerializeField]
    public GameObject enemyBulletPrefab;

    public List<GameObject> Bullets;
    public List<GameObject> DiagonalBullets;
    public List<GameObject> SpiralBullets;
    public List<GameObject> EnnemyBullets;
    private Vector2 bulletDirection;


    public static BulletFactory Instance
    {
        get;
        private set;
    }

    private void Awake()
    {
        Debug.Assert(BulletFactory.Instance == null); //verifier que le singleton n'as pas déja été enregistré
        BulletFactory.Instance = this;
    }

	
    public void AddToList (GameObject Bullet, BulletType Type)
    {
        switch(Type)
        {
            case BulletType.PlayerBullet:
                Bullets.Add(Bullet);
                break;
            case BulletType.PlayerDiagonalBullet:
                DiagonalBullets.Add(Bullet);
                break;
            case BulletType.PlayerSpiralBullet:
                SpiralBullets.Add(Bullet);
                break;
            case BulletType.EnemyBullet:
                EnnemyBullets.Add(Bullet);
                break;
        }
    }

    public BulletFactory GetBullet(GameObject shooter, BulletType type)
    {
        Vector2 position = shooter.transform.position;
        Vector2 playerOffset = new Vector2(2, 0);
        switch (type)
        {
            case BulletType.PlayerBullet:
                if (Bullets.Count == 0)
                { GameObject.Instantiate(this.playerBulletPrefab, position+playerOffset, transform.rotation); }
                else
                {
                    GameObject bullet = Bullets[0];
                    Bullets.RemoveAt(0);
                    bullet.transform.position = position + playerOffset;
                    bullet.SetActive(true);
                }
                break;

            case BulletType.PlayerDiagonalBullet:
                if (DiagonalBullets.Count == 0)
                { GameObject.Instantiate(this.playerBulletPrefab, position+playerOffset, transform.rotation); }
                else
                {
                    GameObject bullet = DiagonalBullets[0];
                    DiagonalBullets.RemoveAt(0);
                    bullet.transform.position = position + playerOffset;
                    bullet.SetActive(true);
                }
                break;

            case BulletType.PlayerSpiralBullet:
                if (SpiralBullets.Count == 0)
                { GameObject.Instantiate(this.playerBulletPrefab, position + playerOffset, transform.rotation); }
                else
                {
                    GameObject bullet = SpiralBullets[0];
                    SpiralBullets.RemoveAt(0);
                    bullet.transform.position = position + playerOffset;
                    bullet.SetActive(true);
                }
                break;

            case BulletType.EnemyBullet:
                if (EnnemyBullets.Count == 0)
                { GameObject.Instantiate(this.enemyBulletPrefab,position , transform.rotation); }
                else
                {
                    GameObject bullet = EnnemyBullets[0];
                    EnnemyBullets.RemoveAt(0);
                    bullet.transform.position = position;
                    bullet.SetActive(true);
                }
                break;

        }

            return this;
    }


    public enum BulletType
    {
        PlayerBullet,
        PlayerDiagonalBullet,
        PlayerSpiralBullet,
        EnemyBullet,

   }
   }
        

    

