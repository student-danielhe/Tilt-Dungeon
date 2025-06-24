using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Script_Arrow : MonoBehaviour
{
    public float speed = 12.0f;
    private Rigidbody2D rb2d = null;
    GameObject audioPlayer = null;
    bool enableSound = false;
    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = GameObject.FindWithTag("AudioPlayer");
        rb2d = GetComponent<Rigidbody2D>();
        SpriteRenderer r= GetComponent<SpriteRenderer>();
        if (r.isVisible)
        {
            enableSound = true;
            audioPlayer.GetComponentInParent<Script_Audio_Levels>().playArrowLauch();
        }
        
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        rb2d.velocity = transform.right * speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (enableSound)
        {
            audioPlayer.GetComponentInParent<Script_Audio_Levels>().playArrowHit();
        }

        Destroy(gameObject);

    }
    private void OnBecameVisible()
    {
        enableSound = true;
    }
    private void OnBecameInvisible()
    {
        enableSound = false; 
    }
}
