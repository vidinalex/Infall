using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XFreezeFollow : MonoBehaviour
{
    public float offset = 10f;
    public float delay = 1f;
    public GameObject target;

    void FixedUpdate()
    {
        if(target)transform.position = new Vector2(transform.position.x, target.transform.position.y - offset);
        //transform.position = Vector3.Lerp(transform.position, new Vector2(transform.position.x, target.transform.position.y - offset), Time.deltaTime * delay);
    }
}
