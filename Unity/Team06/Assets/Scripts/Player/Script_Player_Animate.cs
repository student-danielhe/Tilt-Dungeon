using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Sets the correct animator flags based on the current player state.
public class Script_Player_Animate : MonoBehaviour
{
    public string RollingSpdParameterName = "RollingSpd";
    public string IsDiedParameterName = "IsDied";
    private Animator animator = null;
    private Rigidbody2D Rigidbody2D = null;

    private void Start()
    {
        Rigidbody2D=GetComponent<Rigidbody2D>();    
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float rolling=GetComponent<Script_Player_Movement>().RollingThreshold;
        bool fastRolling = GetComponent<Script_Player_Movement>().boosterControlLost;
        float spd= GetComponent<Rigidbody2D>().velocity.magnitude;

        animator.SetInteger(RollingSpdParameterName, 0);
        if (spd >= rolling)
        {
            animator.SetInteger(RollingSpdParameterName, 1);
        }
        if (fastRolling)
        {
            animator.SetInteger(RollingSpdParameterName, 2);

        }
        
        animator.SetBool(IsDiedParameterName, GetComponent<Script_Player_Die>().died);
    }
}
