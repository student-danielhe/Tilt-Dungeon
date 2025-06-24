using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Portal_Collision : MonoBehaviour
{
    public float Delay = 2.0f;
    public GameObject targetPortal = null;
    public bool active = true;
    GameObject AudioPlayer;
    bool enableSound = false;
    // Start is called before the first frame update
    void Start()
    {
        AudioPlayer = GameObject.FindWithTag("AudioPlayer");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (active)
        {
            if (enableSound)
            {
                AudioPlayer.GetComponent<Script_Audio_Levels>().playPortal();
            }
            
            Deactivate();
            targetPortal.GetComponent<Script_Portal_Collision>().Deactivate();
            collision.transform.position = targetPortal.transform.position;

        }


    }
    public void Deactivate()
    {
        StartCoroutine(DeactivateTimer());
    }

    IEnumerator DeactivateTimer()
    {
        active = false;
        yield return new WaitForSeconds(Delay);
        active = true;

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
