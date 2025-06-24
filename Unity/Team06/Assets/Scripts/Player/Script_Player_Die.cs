using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_Player_Die : MonoBehaviour
{
    public float EndGameDelay = 2.5f; //Amount of time to wait before exiting. Default to 2.5.
    public GameObject GameOverText = null;
    GameObject audioPlayer = null;
    public bool died = false;
    public GameObject PinkyGhost = null;
    // Start is called before the first frame update
    void Start()
    {
        GameOverText.SetActive(false);
        audioPlayer = GameObject.FindWithTag("AudioPlayer");

    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Script_Player_Collision>().HP <= 0)
        {
            StartCoroutine(EndGameTimer());
            if (!died)
            {
                GameObject ghost = Instantiate(PinkyGhost);
                ghost.transform.position = gameObject.transform.position;
                ghost.transform.localScale = gameObject.transform.localScale;
                audioPlayer.GetComponent<Script_Audio_Levels>().playDefeat();
                died = true;
            }
        }
    }
    IEnumerator EndGameTimer()
    {
       
        Color c = GetComponent<SpriteRenderer>().color;
        c.a = 0;
        GetComponent<SpriteRenderer>().color = c;
        GameOverText.SetActive(true);
        yield return new WaitForSeconds(EndGameDelay);
        if (GetComponent<Script_Player_Collision>().checkpoint.x != float.MaxValue)
        {
            c.a = 255;
            GetComponent<SpriteRenderer>().color = c;
            transform.position = GetComponent<Script_Player_Collision>().checkpoint;
            GetComponent<Script_Player_Collision>().HP = 3;
            died = false;
            GameOverText.SetActive(false);
            GetComponent<Script_Player_Tilt>().Calibarate();

        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            c.a = 255;
            GetComponent<SpriteRenderer>().color = c;
        }
        
    }
}

