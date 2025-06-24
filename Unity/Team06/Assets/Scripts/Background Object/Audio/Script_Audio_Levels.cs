using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Script_Audio_Levels : MonoBehaviour
{
    //public bool mute = false;
    public AudioSource BGM = null;
    public AudioSource hurt = null;
    public AudioSource wallBreak = null;
    public AudioSource monster = null;
    public AudioSource button = null;
    public AudioSource victory = null;
    public AudioSource key = null;
    public AudioSource bounce = null;
    public AudioSource defeat = null;
    public AudioSource booster = null;
    public AudioSource mud = null;
    public AudioSource ArrowLauch = null;
    public AudioSource ArrowHit = null;
    public AudioSource pressurePlate = null;
    public AudioSource portal = null;
    public AudioSource unlock = null;
    public AudioSource potion = null;
    public AudioSource Skelly = null;
    // Start is called before the first frame update
    void Start()
    {
        BGM.loop = true;
    }

    // Update is called once per frame

    public void playUnlock()
    {
        unlock.Play();
    }
    public void playHurt()
    {
            hurt.Play();
    }
    public void playWallBreak()
    {

            wallBreak.Play();

    }
    public void playKey()
    {

            key.Play();

    }
    public void playMonster()
    {

            monster.Play();
        
    }

    public void playVictory()
    {

            victory.Play();
        
    }
    public void playButton()
    {

            button.Play();
        
    }
    public void playBounce()
    {

            bounce.Play();
        
    }
    public void playDefeat()
    {

            defeat.Play();
        
    }
    public void playBooster()
    {

            booster.Play();

    }
    public void playMud()
    {

        mud.Play();

    }
    public void playArrowLauch()
    {
        ArrowLauch.Play();
    }
    public void playArrowHit()
    {
        ArrowHit.Play();
    } 
    public void playPressurePlate()
    {
        pressurePlate.Play();
    }
    public void playPortal()
    {
        portal.Play(); 
    }
    public void playSkelly()
    {
        Skelly.Play();
    }
    public void playPotion()
    {
        potion.Play();
    }
}
