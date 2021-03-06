using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VulcanMoveForward : MonoBehaviour
{
    public float topSpeed = 3f;
    public float movementSpeed = 0f;
    public float distance;
    public float stopAtMax = 5;
    public float stopAtMin = 3;
    float stopAt; 
    public float acceleration = 0.1f;
    Transform player;
    GameObject gameObj;

    
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        gameObj = GameObject.Find("ship_normal");
        stopAt = Random.Range(stopAtMin, stopAtMax);
    }

    void Update()
    {
        //Try to find the ship
        if(gameObj == null)
            gameObj = GameObject.Find("ship_normal");


        distance = Vector3.Distance(gameObj.transform.position, transform.position);
        if (distance > stopAt && gameObject.GetComponent<VulcanMovement>().locked == false)
        {
            if (movementSpeed > topSpeed)
            {
                movementSpeed = topSpeed;
            }
            else if (movementSpeed < topSpeed)
            {
                movementSpeed += acceleration;
            }     
            Vector3 shipPos = transform.position;
            Vector3 shipVelocity = new Vector3(0, movementSpeed * Time.deltaTime, 0);
            shipPos += transform.rotation * shipVelocity;
            transform.position = shipPos;

        }
        else
        {
            Vector3 shipPos = transform.position;
            if (movementSpeed > 0)
                movementSpeed -= acceleration;
            else if (movementSpeed < 0)
                movementSpeed = 0f;

            Vector3 shipVelocity = new Vector3(0, movementSpeed * Time.deltaTime, 0);
            shipPos += transform.rotation * shipVelocity;
            transform.position = shipPos;
        }
    }

}
