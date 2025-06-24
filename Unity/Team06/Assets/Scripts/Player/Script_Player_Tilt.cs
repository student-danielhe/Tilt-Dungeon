using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Script_Player_Tilt : MonoBehaviour
{
    //will be used by player movement
    public float tiltX = 0.0f;
    public float tiltY = 0.0f;
    float XSensitivity = 30.0f;
    float YSensitivity = 30.0f;
    private Rigidbody2D Rigidbody2D = null;

   // public TextMeshProUGUI tiltText = null;
    // Start is called before the first frame update
    private void Awake()
    {
        
       
            Rigidbody2D = GetComponent<Rigidbody2D>();
            // use gyro to sense device tilt
            //if (!Input.gyro.enabled)
            //{
            //    Input.gyro.enabled = true;
            //}

            tiltX = GameManager.instance.tiltX;
            tiltY = GameManager.instance.tiltY;
            Calibarate();
        
        

    }

    // Update is called once per frame
    void Update()
    {
        //if (!Input.gyro.enabled)
        //{
        //    Input.gyro.enabled = true;
        //}
        //Vector3 rotation = Input.gyro.rotationRateUnbiased;
        Vector2 acceleration = Input.acceleration;
        //tiltText.text = "" + acceleration.x + ", " + acceleration.y;
        tiltY = -(acceleration.y-GameManager.instance.caliberatedY);//rotation.x / 30;
        tiltX = (acceleration.x-GameManager.instance.caliberatedX);//rotation.y / 30;
        GameManager.instance.tiltXDeg = Mathf.Round(tiltX * Mathf.Rad2Deg);
        GameManager.instance.tiltYDeg = -Mathf.Round(tiltY * Mathf.Rad2Deg);
        GameManager.instance.tiltXUnadjusted=acceleration.x;
        GameManager.instance.tiltYUnadjusted=-acceleration.y;

        GameManager.instance.tiltX = tiltX;
        GameManager.instance.tiltY = tiltY;
    }
    float tiltClamp(float i,float cap)
    {
        if (i < -cap)
        {
            return -cap;
        }
        if (i > cap) 
        {
            return cap;
        }
        return i;
    }
   public void Calibarate()
    {
        Input.gyro.enabled = false;
        Vector2 acceleration = Input.acceleration;
        GameManager.instance.caliberatedX= acceleration.x;
        GameManager.instance.caliberatedY= acceleration.y;
    }

}
