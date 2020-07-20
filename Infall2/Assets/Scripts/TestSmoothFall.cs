using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSmoothFall : MonoBehaviour
{

    Rigidbody2D rb;
    public Transform target;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        //rb.velocity = new Vector2(0f, -5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position,new Vector3(0,target.transform.position.y,-15f), ref velocity, smoothTime);
    }
}
