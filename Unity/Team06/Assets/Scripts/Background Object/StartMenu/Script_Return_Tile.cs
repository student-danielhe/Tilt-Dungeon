using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_Return_Tile : MonoBehaviour
{
    public GameObject audioPlayer = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCLick()
    {
        audioPlayer.GetComponent<Script_Audio_UI>().playButton();
        SceneManager.LoadScene("Title");
    }
}
