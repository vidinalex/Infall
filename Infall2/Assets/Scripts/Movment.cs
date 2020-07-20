using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
    [Header("Debug")]
    public bool isPressedLeft = false;
    public bool isPressedRight = false;
    [Header("Settings")]
    public float moveSpeed = 10f;
    public float gravity = 5f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        //rb.velocity = new Vector2(0.0f, -gravity);
    }

    void Update()
    {
        if (isPressedLeft)
        {
            //transform.position += Vector3.right * -moveSpeed * Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x - moveSpeed, transform.position.y), 0.5f * Time.deltaTime);
        }
        else if (isPressedRight)
        {
            //transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + moveSpeed, transform.position.y), 0.5f * Time.deltaTime);
        }
        
    }

    private void FixedUpdate()
    {
        fall();
    }

    void fall()
    {
        
        //transform.position += Vector3.down * gravity * Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x,transform.position.y - gravity), 0.5f * Time.deltaTime);
    }

    public void Left(bool state)
    {
        if (state) isPressedLeft = true;
        else isPressedLeft = false;
    }

    public void Right(bool state)
    {
        if (state) isPressedRight = true;
        else isPressedRight = false;
    }
}
