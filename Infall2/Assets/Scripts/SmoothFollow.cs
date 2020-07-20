using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    public float delay;
    public float delay2;
    GameObject target;

    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;


    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.position = new Vector3(transform.position.x, target.transform.position.y);
        //transform.position = Vector3.Lerp(transform.position, new Vector3(target.transform.position.x,transform.position.y), Time.deltaTime * delay);
        //transform.position = Vector3.SmoothDamp(transform.position, target.transform.position, ref velocity, smoothTime);
        transform.position = Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime * delay);
    }
}
