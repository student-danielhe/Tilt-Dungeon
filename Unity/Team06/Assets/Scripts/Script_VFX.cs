using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_VFX : MonoBehaviour
{
    public float delay;
    public GameObject Spawner = null;
    void Start()
    {
        StartCoroutine(destroySelf());
    }
    IEnumerator destroySelf()
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
