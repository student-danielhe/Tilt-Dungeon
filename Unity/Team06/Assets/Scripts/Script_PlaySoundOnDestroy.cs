using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_PlaySoundOnDestroy : MonoBehaviour
{
    public AudioSource sound = null;
    private void OnDestroy()
    {
        sound.Play();
    }
}
