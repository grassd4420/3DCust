using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakObject : MonoBehaviour
{
    // Start is called before the first frame update
  
    private void OnTriggerEnter(Collider col)
    {
        // �Ƃ������O�̃^�O�ƐڐG�����ꍇ
        if (col.gameObject.tag == "bk")
        {
            // j��
            Destroy(gameObject);
        }
    }
}
