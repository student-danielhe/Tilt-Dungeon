using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Camera_Movement : MonoBehaviour
{
    /*
    public float thrust = 0.5f;
    Vector3 start;
    Vector3 target;
    Vector3 movement;
    public bool active=false;
    */
    public GameObject player = null;
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    void FixedUpdate()
    {
        /*
        if (active) {
            
            if ((transform.position - target).magnitude < movement.magnitude)
            {
                transform.position = target;
            }
            else
            {
                transform.position += movement;
            }
            
            if (transform.position == target)
            {
               movement= Vector3.zero;
               active = false;
            }
        }
        */
        Vector3 vector3 = player.transform.position;
        vector3.z -= 10;
        transform.position=vector3;
    }
    /*
    public void changePosition(float deltaX, float deltaY)
    {
        if (!active) 
        {
            start=transform.position;
            target = new Vector3(start.x + deltaX, start.y + deltaY, 0);
            active = true;
            movement = target - transform.position;
            movement.Normalize();
            movement *= thrust;
            
        }
    }
    */
}
