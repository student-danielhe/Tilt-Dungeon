using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Tutorial : MonoBehaviour
{
    public string rollParameterName = "roll";
    private Animator animator = null;
    public GameObject hands = null;
    bool roll = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(setRoll());
        StartCoroutine(Die());
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        if (roll)
        {
            pos.x += 0.14f;

        }
        transform.position = pos;
    }
    IEnumerator setRoll()
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetBool(rollParameterName, true);
        roll = true;
    }
    IEnumerator Die()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
        Destroy(hands);
    }
}
