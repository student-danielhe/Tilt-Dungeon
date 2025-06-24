using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_VFX_Self_Destroy : MonoBehaviour
{
    float lifetime=1.0f;
    bool fade = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(die());
        if (fade)
        {
            Color c = GetComponent<SpriteRenderer>().color;
            c.a -= 255 / (lifetime * Time.deltaTime);
            GetComponent<SpriteRenderer>().color = c;
        }
    }
    IEnumerator die()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }
}
