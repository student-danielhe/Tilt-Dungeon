using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Spawn_Arrow : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject projectilePrefab = null;
    public bool autoFire = false;
    public float fireDelay = 2.0f;
    private bool ready = true;
    public float initialAngle=0;
    public int amountBullet = 1;
    public float spreadAngle = 1.0f;

    public void Update()
    {
        if (autoFire)
        {
            Activate();
        }
    }

    public void Fire(float angle)
    {
        GameObject projectile = Instantiate(projectilePrefab);
        projectile.transform.position = transform.position;
        projectile.transform.eulerAngles =new Vector3(0,0,angle);

    }
    IEnumerator setReady(float delay)
    {
        ready = false;
        yield return new WaitForSeconds(delay);
        ready = true;

    }
    public void Activate()
    {
        if (ready)
        {
            StartCoroutine(setReady(fireDelay));
            float currentAngle = initialAngle;
            float increment = 0;
            if (amountBullet > 1)
            {
                increment = spreadAngle / (amountBullet - 1);
            }
            for (int i = 0; i < amountBullet; i++)
            {
                Fire(currentAngle);
                currentAngle += increment;
            }
        }
    }

}
