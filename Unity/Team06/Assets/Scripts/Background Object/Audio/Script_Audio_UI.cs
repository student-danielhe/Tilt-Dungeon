using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Script_Audio_UI : MonoBehaviour
{
    public AudioSource button = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playButton()
    {
        button=GetComponent<AudioSource>();
        button.Play(); 
    }
}
