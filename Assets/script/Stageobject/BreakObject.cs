using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakObject : MonoBehaviour
{
    // Start is called before the first frame update
  
    private void OnTriggerEnter(Collider col)
    {
        // ‚Æ‚¢‚¤–¼‘O‚Ìƒ^ƒO‚ÆÚG‚µ‚½ê‡
        if (col.gameObject.tag == "bk")
        {
            // j‰ó‚·
            Destroy(gameObject);
        }
    }
}
