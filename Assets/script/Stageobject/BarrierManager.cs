using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��Ԑ؂�ւ��ŏ��鑫�ꂪ�ς�鏈��

public class BarrierManager : MonoBehaviour
{
    public GameObject GameManager;
    GameObject[] barri_Objects;//�Q����
    GameObject[] barg_Objects;//�Q����
    public bool playerIN;

    // Start is called before the first frame update
    void Start()
    {

        //Barri tag�̃I�u�W�F�N�g���i�[
        barri_Objects = GameObject.FindGameObjectsWithTag("Barri");

        for (int i = 0; i < barri_Objects.Length; i++)
        {
            //�R���C�_�[������
            Debug.Log(barri_Objects[i]);
        }

        //BarGround tag�̃I�u�W�F�N�g���i�[
        barg_Objects = GameObject.FindGameObjectsWithTag("BarGround");

        for (int i = 0; i < barg_Objects.Length; i++)
        {
            //�R���C�_�[������
            Debug.Log(barg_Objects[i]);
        }
        GameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {

        //2D��
        if (GameManager.GetComponent<Switcher1>().vi == false)
        {
            //Barri tag�̃I�u�W�F�N�g�����ԂɌĂяo��
            for (int i = 0; i < barri_Objects.Length; i++)
            {
                //�R���C�_�[���I��
                if (playerIN == false)
                {
                    barri_Objects[i].GetComponent<BoxCollider>().enabled = true;
                }
                
            }

            //BarGround tag�̃I�u�W�F�N�g�����ԂɌĂяo��
            for (int i = 0; i < barg_Objects.Length; i++)
            {
                //�R���C�_�[���I��
                if (playerIN == false)
                {
                    barg_Objects[i].GetComponent<BoxCollider>().enabled = true;
                }
                
            }

        }

        //�RD��
        if (GameManager.GetComponent<Switcher1>().vi == true)
        {

            //Barri tag�̃I�u�W�F�N�g�����ԂɌĂяo��
            for (int i = 0; i < barri_Objects.Length; i++)
            {
                //�R���C�_�[������
                barri_Objects[i].GetComponent<BoxCollider>().enabled = false;
            }

            //BarGround tag�̃I�u�W�F�N�g�����ԂɌĂяo��
            for (int i = 0; i < barg_Objects.Length; i++)
            {
                //�R���C�_�[������
                barg_Objects[i].GetComponent<BoxCollider>().enabled = false;
            }

        }
    }
    private void OnTriggerStay(Collider col)
    {

        if (col.gameObject.tag == "Player")
        {
            playerIN = true;
        }
        else playerIN = false;
    }
}
