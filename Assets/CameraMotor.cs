using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    public Transform player;
    public float boundX = 0.15f;
    public float boundY = 0.05f;

    private void LateUpdate()
    {
        Vector2 delta = Vector2.zero;

        // this is to check if we're inside the bounds on the x axis
        float deltaX = player.position.x - transform.position.x;
        if (deltaX > boundX ||deltaX < -boundX) // limits the movement of the camera to follow the player after a certain point
            if (deltaX > 0) // if the camera is on the left of the player
            delta.x = deltaX - boundX;
        else             // if the camera is on the right of the player
            delta.x = deltaX + boundX;

        // this is to check if we're inside the bounds on the y axis
        float deltaY = player.position.y - transform.position.y;
        if (deltaY > boundY || deltaY < -boundY) // limits the movement of the camera to follow the player after a certain point
            if (deltaY > 0) // if the camera is below the player
            delta.y = deltaY - boundY;
        else             // if the camera is on top of the player
            delta.y = deltaY + boundY;


        transform.position += new Vector3(delta.x, delta.y, 0);
    }
}