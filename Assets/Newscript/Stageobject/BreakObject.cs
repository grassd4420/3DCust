using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakObject : MonoBehaviour
{
    private const string BreakObjectTag = "bk";

    private void OnTriggerEnter(Collider col)
    {
        // ‚Æ‚¢‚¤–¼‘O‚Ìƒ^ƒO‚ÆÚG‚µ‚½ê‡
        if (col.CompareTag(BreakObjectTag))
        {
            // j‰ó‚·
            Destroy(gameObject);
        }
    }
}
