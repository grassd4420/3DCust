using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//“]‚ª‚Á‚Ä—ˆ‚éáŠQ•¨‚Ì“–‚½‚è”»’è‚Ìˆ—

public class CircleObjectColliderSwitcher : MonoBehaviour
{
    private DimentionSwitcher switcher;

    // Start is called before the first frame update
    void Start()
    {
        switcher = FindObjectOfType<DimentionSwitcher>();
    }

    //3d‹óŠÔ“à‚Å‚ÌCollider‚ğŠ“¾
    private void Get3dCollider()
    {
        GetComponent<CapsuleCollider>().enabled = false;
        GetComponent<MeshCollider>().enabled = true;
    }

    //‚Qd‹óŠÔ“à‚Å‚ÌCollider‚ğŠ“¾
    private void Get2dCollider()
    {
        GetComponent<CapsuleCollider>().enabled = true;
        GetComponent<MeshCollider>().enabled = false;
        CapsuleCollider collider = GetComponent<CapsuleCollider>();
        collider.height = 60;
    }
    

    // Update is called once per frame
    void Update()
    {
        //‹óŠÔ‚É‰‚¶‚ÄØ‚è‘Ö‚¦

        //3‚„
        if(switcher.vi )
        {
            Get3dCollider();
        }

        //‚Q‚„
        if (switcher.vi == false)
        {
            Get2dCollider();
        }
    }
}
