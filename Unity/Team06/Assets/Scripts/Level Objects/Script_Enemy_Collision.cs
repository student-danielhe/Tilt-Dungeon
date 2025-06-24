using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Enemy_Collision : MonoBehaviour
{
    public float knockback=-200;
    public bool destructible = true;
    public bool contactDamage = true;
    public bool isMonster = false;
    public bool isSkelly = false;
    GameObject AudioPlayer;
    public GameObject ShatterPrefab;

    public void Awake()
    {
        AudioPlayer = GameObject.FindWithTag("AudioPlayer");
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile")&&destructible)
        {
            Destroy(gameObject);
        }
    }
    public void OnDestroy()
    {
        if (isMonster)
        {
            if (isSkelly){
                AudioPlayer.GetComponent<Script_Audio_Levels>().playSkelly();
            }
            else
            {
                AudioPlayer.GetComponent<Script_Audio_Levels>().playMonster();
            }
            
        }
        else
        {
            GameObject particle= Instantiate(ShatterPrefab);
            particle.transform.position = transform.position;
            particle.transform.rotation = transform.rotation;
        }
    }
}


