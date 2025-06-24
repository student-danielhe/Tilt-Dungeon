using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Pressure_Plate : MonoBehaviour
{
    public float Delay = 2.0f; //Amount of time to wait before exiting. Default to 2.5.
    public GameObject Trap = null;
    //public GameObject audioPlayer = null;
    private bool active = true;
    public GameObject audioPlayer = null;
    public Sprite plateDown = null;
    public Sprite plateUp = null;
    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = GameObject.FindWithTag("AudioPlayer");
    }
    private void Update()
    {
        if (!active)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = plateDown;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = plateUp;
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (active)
            {
                audioPlayer.GetComponent<Script_Audio_Levels>().playPressurePlate();
                //audioPlayer.GetComponent<Script_Audio_Levels>().playButton();
                StartCoroutine(EndGameTimer());
                Trap.GetComponent<Script_Spawn_Arrow>().Activate();

            }
        }



    }
    IEnumerator EndGameTimer()
    {
        active = false;
        yield return new WaitForSeconds(Delay);
        active = true;

    }
}
