using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_GotoTiltle : MonoBehaviour
{
    public float sec = 7.0f;
    public string name = "Title";

    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(gotoTitle());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator gotoTitle()
    {
        yield return new WaitForSeconds(sec);
        SceneManager.LoadScene(name);
    }
}
