using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpPointAnimation : MonoBehaviour
{
    private readonly int WarpPointTriggerHash = Animator.StringToHash("next");

    private Animator anim = null;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //視点切り替えアニメーション
            anim.SetTrigger("WarpPointTriggerHash");

        }
    }
}
