using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Areapoimt : MonoBehaviour
{
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
            //���_�؂�ւ��A�j���[�V����
            anim.SetTrigger("next");

        }
    }
}
