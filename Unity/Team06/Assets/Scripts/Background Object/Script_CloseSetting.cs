using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_CloseSetting : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject settingMenu = null;
    public GameObject PauseMenu = null;
    public void OnClick()
    {
        settingMenu.SetActive(false);
        PauseMenu.SetActive(true);
    }
}
