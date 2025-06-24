using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Door_Movement : MonoBehaviour
{
    public float deltaX = 0;
    public float deltaY = 0;
    public float thrust = 0.5f;
    Vector3 start;
    Vector3 end;
    Vector3 target;
    Vector3 movement;
    public bool active=false;
    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
        end = new Vector3(start.x+deltaX, start.y+deltaY, 0);
 
    }

    // Update is called once per frame
    void Update()
    {
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
    }
    public void changePosition()
    {
        if (!active) 
        {
            if (transform.position == start) {
                target = end;
                active = true;
                movement = target - transform.position;
                movement.Normalize();
                movement *= thrust;
            }
            if (transform.position == end)
            {
                target = start;
                active = true;
                movement = target - transform.position;
                movement.Normalize();
                movement *= thrust;
            }
        }
    }
}
