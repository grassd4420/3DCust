using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�R�[�X���痎�������̏���

public class Outxr : MonoBehaviour
{
    public Vector3 pos;
 
   
    void OnTriggerEnter(Collider other)
    {
        //�G�ꂽ��w�肵�����W�Ƀe���|�[�g
        other.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z);
    }
}
