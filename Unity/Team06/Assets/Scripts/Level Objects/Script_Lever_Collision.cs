using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Script_Lever_Collision : MonoBehaviour
{
    public float Delay = 2.0f; //Amount of time to wait before exiting. Default to 2.5.
    public GameObject Door = null;
    public GameObject Door2 = null;
    GameObject audioPlayer = null;
    private bool active = true;

    public Sprite ButtonDown = null;
    public Sprite ButtonUp = null;
    public Tilemap antLine = null;
    public bool startingRed = true;
    //change to specific color if needed
    Color red = Color.red;
    Color green = Color.green;
    // Start is called before the first frame update
    void Start()
    {
        if (startingRed)
        {
            antLine.color = red;
        }
        else
        {
            antLine.color = green;
        }
        
        audioPlayer = GameObject.FindWithTag("AudioPlayer");
    }


    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")||collision.gameObject.CompareTag("Projectile"))
        {
            if (active)
            {
                audioPlayer.GetComponent<Script_Audio_Levels>().playButton();
                StartCoroutine(EndGameTimer());
                Door.GetComponent<Script_Door_Movement>().changePosition();
                Door2.GetComponent<Script_Door_Movement>().changePosition();
                if (antLine.color == red)
                {
                    antLine.color = green;
                }
                else
                {
                    antLine.color = red;
                }

            }
        }
        
        

    }
    IEnumerator EndGameTimer()
    {
        GetComponent<SpriteRenderer>().sprite=ButtonDown;
        active = false;
        yield return new WaitForSeconds(Delay);

        GetComponent<SpriteRenderer>().sprite = ButtonUp;
        active = true;

    }
}
