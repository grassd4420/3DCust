using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearStage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider col)
    {
        // Ç∆Ç¢Ç§ñºëOÇÃÉ^ÉOÇ∆ê⁄êGÇµÇΩèÍçá
        if (col.gameObject.tag == "Player")
        {
            FadeManager.Instance.LoadScene("StageClear", 0.3f);

            //SceneManager.LoadScene("StageClear");
        }
    }
}
