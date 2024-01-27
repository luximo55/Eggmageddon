using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Moving()
    {
        anim.SetTrigger("IsMoving");
    }
    
    public void Hitting()
    {
        Debug.Log("HittingAnim");
        anim.SetTrigger("IsHit");
    }
}
