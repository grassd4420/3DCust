using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//�X�e�[�W�Z���N�g�V�[���̏���

public class StageSelect : MonoBehaviour
{
    public GameObject GameManager;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        //DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerStay(Collider other)
    {
        //�Q�����Ƀ��[�v���͈͓̔��Ƀv���C���[�����݂���ꍇ
        if (GameManager.GetComponent<Switcher1>().vi == false && other.gameObject.tag == "Player" && this.gameObject.tag == "Stage1")
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                //StartCoroutine(WaitForLoadScene());
                //SceneManager.LoadScene("intro1");
                FadeManager.Instance.LoadScene("intro1",0.3f);
                Debug.Log("ok");
            }
        }

        //�Q�����Ƀ��[�v���͈͓̔��Ƀv���C���[�����݂���ꍇ
        if (GameManager.GetComponent<Switcher1>().vi == false && other.gameObject.tag == "Player" && this.gameObject.tag == "Stage2")
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                //StartCoroutine(WaitForLoadScene());
               // SceneManager.LoadScene("intro2");
                FadeManager.Instance.LoadScene("intro2", 0.3f);
                Debug.Log("ok");
            }
        }

        //�Q�����Ƀ��[�v���͈͓̔��Ƀv���C���[�����݂���ꍇ
        if (GameManager.GetComponent<Switcher1>().vi == false && other.gameObject.tag == "Player" && this.gameObject.tag == "Thank")
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                //StartCoroutine(WaitForLoadScene());
                //SceneManager.LoadScene("Thankyou"); 
                FadeManager.Instance.LoadScene("Thankyou", 0.3f);
                Debug.Log("ok");
            }
        }

    }


    
   
}
