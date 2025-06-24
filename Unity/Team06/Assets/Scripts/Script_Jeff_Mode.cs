using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
public class Script_Jeff_Mode : MonoBehaviour
{
    public GameObject JeffMode=null;
    // Start is called before the first frame update
    void Start()
    {
        JeffMode.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        GameManager.instance.level2Unlocked = true;
        GameManager.instance.level3Unlocked = true;
        GameManager.instance.level4Unlocked = true;
        GameManager.instance.level5Unlocked = true;
        GameManager.instance.level6Unlocked = true;
        JeffMode.SetActive(true);
    }
}
