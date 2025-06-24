using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Script_Audio_Listener : MonoBehaviour
{
    public Slider slider = null;
    // Start is called before the first frame update
    void Awake()
    {
        slider.value=GameManager.instance.vol;
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.IsActive())
        {
            GameManager.instance.vol = slider.value;
            ChangeVol(slider.value);
        }
       
    }
    public void ChangeVol(float newValue)
    {
        float newVol = AudioListener.volume;
        newVol = newValue;
        AudioListener.volume = newVol;
    }
}
