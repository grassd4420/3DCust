using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakObject : MonoBehaviour
{
    private const string BreakObjectTag = "bk";

    private void OnTriggerEnter(Collider col)
    {
        // �Ƃ������O�̃^�O�ƐڐG�����ꍇ
        if (col.CompareTag(BreakObjectTag))
        {
            // j��
            Destroy(gameObject);
        }
    }
}
