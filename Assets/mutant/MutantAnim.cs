using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantAnim : MonoBehaviour
{

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        //アニメーター取得
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)
            ||  Input.GetKey(KeyCode.A)
            ||  Input.GetKey(KeyCode.S)
            ||  Input.GetKey(KeyCode.D))
        {
            //歩くアニメーションフラグON
            anim.SetBool("IsWalk", true);
        }
        else
        {
            //歩くアニメーションフラグOFF
            anim.SetBool("IsWalk", false);
        }

        //左か左のシフトを押すと
        if(Input.GetKey(KeyCode.RightShift)
            || Input.GetKey(KeyCode.LeftShift))
        {
            //走るアニメーションフラグON
            anim.SetBool("IsRun", true);
        }
        else
        {
            //走るアニメーションフラグOFF
            anim.SetBool("IsRun", false);
        }

    }
}
