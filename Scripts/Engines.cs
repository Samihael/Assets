using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engines : MonoBehaviour
{
    private Vector2 speed;

    public Vector2 Speed
    {
        get
        {
            return this.speed;
        }
        set
        {
            this.speed = value;
        }
    }


    void Update()
    {
        transform.Translate(speed * this.GetComponent<BaseAvatar>().MaxSpeed * Time.deltaTime);


    }
}