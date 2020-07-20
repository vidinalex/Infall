using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colliderfollow : MonoBehaviour
{
    Rigidbody2D rb;
    public float delay;
    public GameObject target;
    public GameObject PSkin;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PSkin)rb.MovePosition(Vector3.Lerp(transform.position, target.transform.position, delay));
    }
}
