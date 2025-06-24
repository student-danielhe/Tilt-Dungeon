using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
/*Apply force to the Rigidbody 2D according to the horizontal
axis input (A and D keys) and clamp the velocity.*/
public class Script_Player_Movement : MonoBehaviour
{

    public float DefaultMaxSpeed = 3.0f;
    public float RollingThreshold = 1.5f;
    public float friction = 0.3f;
    public float MaxSpeed = 3.0f; //Maximum horizontal velocity. Default to 12.
    public float boosterMaxSpeed = 12.0f;
    public float CrushSpeed=7.0f;
    public float booserForceMovetTime = 0.5f;
    public bool boosterControlLost = false;
    public float Thrust = 2000.0f;  //Acceleration for the added movement force. Default to 600.
    public float mudSpeed = 2f;
    private Rigidbody2D Rigidbody2D=null;
    bool still = true;
    Vector3 lastPosition;
    public GameObject pausePrefab = null;
    public bool stopped=false;
    public float resetThreshold = 30;
    // Update is called once per frame
    private void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        lastPosition=transform.position;

        
    }
    void Update()
    {
        if (Rigidbody2D.velocity != Vector2.zero)
        {
            float direction = Vector2.SignedAngle(Vector2.down, Rigidbody2D.velocity.normalized);
            transform.eulerAngles = new Vector3(0, 0, direction);
        }
        
        if (MaxSpeed > DefaultMaxSpeed)
        {
            MaxSpeed -= (boosterMaxSpeed-DefaultMaxSpeed)/(120);
        }
        if (!stopped)
        {
            if ((Mathf.Abs(GameManager.instance.tiltXUnadjusted*Mathf.Rad2Deg) > resetThreshold || Mathf.Abs(GameManager.instance.tiltYUnadjusted*Mathf.Rad2Deg) > resetThreshold)&&Time.timeScale!=.0f)
            {
                Instantiate(pausePrefab);
                stopped = true;

            }

        }
        else
        {

        }
        
        
    }
    private void FixedUpdate()
    {
       if(!GetComponent<Script_Player_Die>().died)
           Move();
        else
        {
            Rigidbody2D.velocity = Vector2.zero;
        }
    }
   

    private float Clamp(float spd,float max)
    {
        if (spd > max)
        {
            spd = max;
        }else if(spd<-max)
        {
            spd = -max;
        }
        return spd;
    }
    void Move()
    {
        float tiltX = GetComponent<Script_Player_Tilt>().tiltX * Mathf.Deg2Rad;
        float tiltY = GetComponent<Script_Player_Tilt>().tiltY * Mathf.Deg2Rad;
        if (tiltX > 20) { tiltX = 30; }
        if (tiltY > 20) { tiltY = 30; };
        if (tiltX < -20) { tiltX = -30; }
        if (tiltY < -20) { tiltY = -30; }
        if (boosterControlLost)
        {
            tiltX = 0;
            tiltY = 0;    
        }
        
        Vector2 accel = Time.deltaTime * Thrust * new Vector2(Mathf.Sin(tiltX), -Mathf.Sin(tiltY)) * 100;
        if (GetComponent<Script_Player_Collision>().touchingMud)
        {
            accel *= 0.5f;
        }
        Rigidbody2D.AddForce(accel);
        Vector2 velocity = Rigidbody2D.velocity;
        
        if (velocity.magnitude > MaxSpeed)
        {
            velocity = velocity.normalized * MaxSpeed;
        }
        velocity=ApplyFriction(velocity);
        if (GetComponent<Script_Player_Collision>().touchingMud)
        {
            if (velocity.magnitude > mudSpeed)
            {
                velocity *= 0.2f;
            }


        }

        Rigidbody2D.velocity = velocity;
        lastPosition=transform.position;
    }


    Vector2 ApplyFriction(Vector2 velocity)
    {

        Vector2 tilt = new Vector2(GameManager.instance.tiltXDeg, GameManager.instance.tiltYDeg);
        if(Input.touchCount==0)//if (tilt.magnitude < 30)
        {
            
            if (velocity.magnitude < 5*friction&&tilt.magnitude<8)
            {
                if (!still)
                {
                    //GetComponent<Script_Player_Tilt>().Calibarate();
                    still = true;
                }
                //transform.position = lastPosition;
                return Vector2.zero;
            }
            return velocity.normalized*(velocity.magnitude-friction*(1-(tilt.magnitude/5)));
        }
        return velocity;
    }

    public void BoosterCollision( float degree)
    {
        if (!(boosterControlLost))
        {
            StartCoroutine(restoreBoosterControl(booserForceMovetTime));
            MaxSpeed = boosterMaxSpeed;
            float spd = MaxSpeed;
            float x = Mathf.Cos(degree*Mathf.Deg2Rad) * spd;
            float y = Mathf.Sin(degree*Mathf.Deg2Rad) * spd;
            Vector2 accel = new Vector2(x, y);
            Rigidbody2D.velocity = accel;
        }
        
    }

    IEnumerator restoreBoosterControl(float delay)
    {
        boosterControlLost = true;
        yield return new WaitForSeconds(delay);
        boosterControlLost = false;
    }


}
