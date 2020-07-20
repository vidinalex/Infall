using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private Collision2D C2d;
    public float delay = 0.1f;
    public GameObject PlayerSkin;
    public MainEventSystem MES;
    public GameObject HitPrefab;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            C2d = collision;
            Invoke("explode", delay);
            MES.score++;
            MES.UpdateScore();
            Instantiate(HitPrefab, new Vector3(PlayerSkin.transform.position.x,PlayerSkin.transform.position.y),Quaternion.identity);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            if(PlayerSkin)PlayerSkin.GetComponent<Explodable>().explode();
            MES.Die();
        }
    }

    void explode()
    {
        C2d.gameObject.GetComponent<Explodable>().explode();
    }
}
