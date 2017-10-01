using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAvatar: BaseAvatar {
    private Text score;
    private int count;
    public GameObject text;
    public Slider lifeBarSlider;
    public Slider healthBarSlider;
    public GameObject gameOver;
    public BulletFactory.BulletType bulletType;
    public AudioSource music;
    public AudioSource loseSoundeffect;
    public BulletFactory.BulletType BulletType
    {
        get
        {
            return this.bulletType;
        }
        set
        {
            this.bulletType = value;
        }
    }
    public int Count
    {
        get
        {
            return this.count;
        }
        set
        {
            this.count = value;
        }
    }
    void Start () {

        bulletType = BulletFactory.BulletType.PlayerBullet;
        score = text.GetComponent<Text>();
        StartCoroutine(EnergyBoost());
    }

    void Update()
    {
        if (GetComponent<PlayerAvatar>().lifeBarSlider.value == 0)
        {
            Destroy(this.gameObject);
            music.Pause();
            loseSoundeffect.Play();
            Time.timeScale = 0;
            Instantiate(gameOver, new Vector2(0, 0), transform.rotation);
        }
        score.text = "" + count;
    }

    public IEnumerator EnergyBoost()
    {
        bool flag = true;
        while (flag)
        {
            healthBarSlider.value += .1f;
            yield return new WaitForSeconds(3);
        }
    }
}
