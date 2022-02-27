using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//“]‚ª‚Á‚Ä—ˆ‚éáŠQ•¨‚Ì“–‚½‚è”»’è‚Ìˆ—

public class CsColl : MonoBehaviour
{
    public GameObject GameManager;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        
    }

    // Update is called once per frame
    void Update()
    {
        //3‚„
        if(GameManager.GetComponent<Switcher1>().vi == true)
        {
            GetComponent<CapsuleCollider>().enabled = false;
            GetComponent<MeshCollider>().enabled = true;
            
        }


        //‚Q‚„
        if (GameManager.GetComponent<Switcher1>().vi == false)
        {
            GetComponent<CapsuleCollider>().enabled = true;
            GetComponent<MeshCollider>().enabled = false;
            CapsuleCollider collider = GetComponent<CapsuleCollider>();
            collider.height = 45;
        }
    }
}
