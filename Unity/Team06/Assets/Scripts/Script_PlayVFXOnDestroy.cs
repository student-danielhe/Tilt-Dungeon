using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_PlayVFXOnDestroy : MonoBehaviour
{
    public GameObject VFX = null;
    public bool matchRoation = true;
    private void OnDestroy()
    {
        GameObject effect=Instantiate(VFX);
        
        effect.transform.position = this.transform.position;
        if (matchRoation)
        {
            effect.transform.rotation=transform.rotation;
        }
    }
}
