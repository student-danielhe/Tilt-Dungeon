using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Player_Tap : MonoBehaviour
{
    /*
    Rigidbody2D rigidbody2;
    public float thrust = 2000.0f;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (GameManager.instance.tapControl)
        //{
        if (Input.touchCount > 0)
        {
            if (!GetComponent<Script_Player_Movement>().boosterControlLost)
            {
                Vector3 pos = transform.position;
                float mudSlow = 1.0f;
                if (GetComponent<Script_Player_Collision>().touchingMud)
                {
                    mudSlow = 0.2f;
                }
                Vector3 mouseposition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                Vector2 dir = pos - mouseposition;
                rigidbody2.AddForce(dir * thrust * mudSlow);


            }

        }

        if (rigidbody2.velocity.magnitude > GetComponent<Script_Player_Movement>().MaxSpeed)
        {
            rigidbody2.velocity.Normalize();
            rigidbody2.velocity *= GetComponent<Script_Player_Movement>().MaxSpeed;

        }
    }
        
        
    //}
    */
}
