using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIrot : MonoBehaviour
{
   [SerializeField] GameObject handle;
    public static UIrot instance;
    bool rotStart = false;
	float speed =  0.3f;
	float rotAngle = 530f;
	float variation;
	float rot;

	

    void Start()
    {
        variation = rotAngle / speed;
    }

    void Update()
    {
        if (rotStart == true)
        {
            handle.transform.Rotate(0, variation * Time.deltaTime, 0 );
            rot += variation * Time.deltaTime;
            if (rot >= rotAngle)
            {
                rotStart = false;
                handle.transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }

    public void roling()
    {
        //‰ñ“]Šp“x‚ğ‰Šú‰»‚·‚éB
        rot = 0f;
        handle.transform.localRotation = Quaternion.Euler(0, 0, 0);
        rotStart = true;
    }
}