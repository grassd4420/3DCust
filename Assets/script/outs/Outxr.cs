using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//コースから落ちた時の処理

public class Outxr : MonoBehaviour
{
    public Vector3 pos;
 
   
    void OnTriggerEnter(Collider other)
    {
        //触れたら指定した座標にテレポート
        other.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z);
    }
}
