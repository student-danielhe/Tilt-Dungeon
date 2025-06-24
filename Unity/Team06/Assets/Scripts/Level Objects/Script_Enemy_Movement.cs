using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Enemy_Movement : MonoBehaviour
{
    public float deltaX = 0;
    public float deltaY = 0;
    public float thrust = 2000f;
    bool ready = true;
    Vector2 start;
    Vector2 end;
    Vector2 target;
    Vector2 movement;
    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        start = rb2d.position;
        end = new Vector2(start.x + deltaX, start.y + deltaY);
        target = end;
        rb2d.velocity= ((end - start).normalized * thrust);

    }
    private void FixedUpdate()
    {
        if (ready)
        {
            StartCoroutine(setReady(1));
            if ((rb2d.position -start).magnitude<0.1)
            {
                target = end;
            }
            if ((rb2d.position- end).magnitude<0.1)
            {
                target = start;

            }
        }
        
        rb2d.velocity = ((target - rb2d.position).normalized * thrust * 2);
    }
    IEnumerator setReady(float delay)
    {
        ready = false;
        yield return new WaitForSeconds(delay);
        ready = true;
    }
}
