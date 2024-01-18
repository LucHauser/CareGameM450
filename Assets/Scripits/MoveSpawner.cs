using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpawner : MonoBehaviour
{
    private Rigidbody rb;
    public float moveRange = 1;
    public Vector2 speedRange;
    private float speed;
    public float targetPoint;
    public bool isTargetRight;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Randomize();
    }


    void Update()
    {
        if (isTargetRight && transform.position.x >= targetPoint || !isTargetRight && transform.position.x <= targetPoint) 
        {
            Randomize();
        }

        rb.velocity = new Vector3(speed, 0, 0);
    }

    void Randomize() 
    {
        speed = Random.Range(speedRange.x, speedRange.y);
        targetPoint = Random.Range(-moveRange, moveRange);

        if (transform.position.x <= targetPoint) 
        {
            isTargetRight = true;
        }
        else {
            isTargetRight = false;
            speed = -speed;
        }
    }
}
