using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
public class Script_Player_Collision : MonoBehaviour
{
    /*Tag Explanation
     * Enemy: Normal enemy, damage player if player slow, get crushed if player fast
     * Breakable: Break on contact if player fast
     * Key: Give player key on contact
     * Lock: Break on contact if player have key, then key--
     * ...
     */
    public float bounceSEDelay = 0.4f;
    bool bounceAudioReady = true;
    public int keys = 0;
    public int HP = 3;
    public int MaxHP = 3;
    public TextMeshProUGUI KeyUI = null;
    public TextMeshProUGUI HPUI = null;
    //public float crushSpeed = 5.0f;
    public bool Iframe = false;
    private float IframeLength = 1.0f;
    private Rigidbody2D Rigidbody2D = null;
    public bool touchingMud=false;
    GameObject audioPlayer = null;
    public GameObject bloodPrefab = null;
    public GameObject HPPlusPrefab = null;
    public Vector3 checkpoint;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        audioPlayer = GameObject.FindWithTag("AudioPlayer");
        checkpoint.x=float.MaxValue;
        checkpoint.y=float.MaxValue;
        checkpoint.z=float.MaxValue;
    }
    private void Update()
    {
        KeyUI.text = "X " + keys;
        HPUI.text = "X " + Mathf.Max(HP,0);
        if (Iframe) {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }

        
    }
    //Object Collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Lock"))
        {
            if (keys > 0)
            {
                audioPlayer.GetComponent<Script_Audio_Levels>().playUnlock();
                keys--;
                Destroy(collision.gameObject);
                checkpoint=transform.position;
            }
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {

            if (GetComponent<Script_Player_Movement>().MaxSpeed >= GetComponent<Script_Player_Movement>().CrushSpeed && collision.gameObject.GetComponent<Script_Enemy_Collision>().destructible)
            {
                if (collision.gameObject.GetComponent<Script_Enemy_Collision>().isMonster)
                {
                    //audioPlayer.GetComponent<Script_Audio_Levels>().playMonster();
                }
                else
                {
                    audioPlayer.GetComponent<Script_Audio_Levels>().playWallBreak();
                }
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.GetComponent<Script_Enemy_Collision>().contactDamage)
            {
                takeDamage(collision.gameObject.GetComponent<Script_Enemy_Collision>().knockback);
            }

        }
        if (collision.gameObject.CompareTag("Projectile"))
        {
            takeDamage(0);
        }
        GetComponent<Script_Player_Movement>().MaxSpeed = GetComponent<Script_Player_Movement>().DefaultMaxSpeed;
        GetComponent<Script_Player_Movement>().boosterControlLost = false;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (bounceAudioReady)
            {
                StartCoroutine(setBounceAudioReady(bounceSEDelay));
                audioPlayer.GetComponent<Script_Audio_Levels>().playBounce();
            }
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lock"))
        {
            if (keys > 0)
            {
                audioPlayer.GetComponent<Script_Audio_Levels>().playUnlock();
                keys--;
                Destroy(collision.gameObject);
                checkpoint = transform.position;
            }
        }
        if (collision.gameObject.CompareTag("Key"))
        {
            audioPlayer.GetComponent<Script_Audio_Levels>().playKey();
            keys++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("HP_Potion"))
        {
            audioPlayer.GetComponent<Script_Audio_Levels>().playPotion();
            GameObject effect = Instantiate(HPPlusPrefab);
            effect.transform.position = this.transform.position;
            HP++;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Mud_Pit"))
        {
            if (!touchingMud)
            {
                audioPlayer.GetComponent<Script_Audio_Levels>().playMud();
                touchingMud = true;
            }
            
        }
        if (collision.gameObject.CompareTag("Boost_Pad"))
        {
            audioPlayer.GetComponent<Script_Audio_Levels>().playBooster();
            GetComponent<Script_Player_Movement>().BoosterCollision(collision.transform.eulerAngles.z);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {

            if (GetComponent<Rigidbody2D>().velocity.magnitude >= GetComponent<Script_Player_Movement>().CrushSpeed && collision.gameObject.GetComponent<Script_Enemy_Collision>().destructible)
            {
                if (collision.gameObject.GetComponent<Script_Enemy_Collision>().isMonster)
                {
                    //audioPlayer.GetComponent<Script_Audio_Levels>().playMonster();
                }
                else
                {
                    audioPlayer.GetComponent<Script_Audio_Levels>().playWallBreak();
                }
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.GetComponent<Script_Enemy_Collision>().contactDamage)
            {
                takeDamage(collision.gameObject.GetComponent<Script_Enemy_Collision>().knockback);
            }

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Mud_Pit"))
        {
            touchingMud = false;
        }
    }
    public void takeDamage(float knockback)
    {
        if (!Iframe)
        {
            GameObject blood= Instantiate(bloodPrefab);
            blood.transform.position = this.transform.position;
            audioPlayer.GetComponent<Script_Audio_Levels>().playHurt();
            HP--;
            if (HP > 0)
            {
                Rigidbody2D.AddForce(Rigidbody2D.velocity.normalized * knockback);
                Iframe = true;
                StartCoroutine(Iframe_Countdown());
            }
            
        }
        
    }
    IEnumerator Iframe_Countdown()
    {
        
        yield return new WaitForSeconds(IframeLength);
        Iframe = false;
    }
    IEnumerator setBounceAudioReady(float delay)
    {
        bounceAudioReady = false;
        yield return new WaitForSeconds(delay);
        bounceAudioReady = true;
    }
}
