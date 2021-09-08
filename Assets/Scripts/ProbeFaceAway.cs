using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProbeFaceAway : MonoBehaviour
{
    float rotationSpeed = 100f;
    Transform player;
    public bool activeScript = false;




    // Update is called once per frame
    void Update()
    {
        if (activeScript)
        {
            //if the player object was just destroyed or not there
            if (player == null)
            {
                //Try to find the ship
                GameObject gameObj = GameObject.Find("ship_normal");
                //If found the ship
                if (gameObj != null)
                    player = gameObj.transform;//get position
            }

            //If failed to find, exit and try again
            if (player == null)
                return;


            Vector3 objDirection = player.position - transform.position;
            objDirection.Normalize();

            float angle = Mathf.Atan2(-1 * objDirection.y, -1 * objDirection.x) * Mathf.Rad2Deg - 90;
            Quaternion exactRotation = Quaternion.Euler(0, 0, angle);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, exactRotation, rotationSpeed * Time.deltaTime);
        }


    }
}
