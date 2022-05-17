using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIrot : MonoBehaviour
{
    [SerializeField] GameObject handle;
    
    public static UIrot instance;
    bool rotStart = false;

    const float Speed = 0.3f;
    const float RotAngle = 530f;
    private float variation;
    float rot;

    void Start()
    {
        variation = RotAngle / Speed;
    }

    void Update()
    {
        if (!rotStart) return;

        handle.transform.Rotate(0, variation * Time.deltaTime, 0);
        rot += variation * Time.deltaTime;
        if (rot >= RotAngle)
        {
            rotStart = false;
            handle.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public void Roling()
    {
        //‰ñ“]Šp“x‚ğ‰Šú‰»‚·‚éB
        rot = 0f;
        handle.transform.localRotation = Quaternion.Euler(0, 0, 0);
        rotStart = true;
    }
}