using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��Ԑ؂�ւ��ŏ��鑫�ꂪ�ς�鏈��

public class BarrierManager : MonoBehaviour
{
    [SerializeField] private DimentionSwitcher gameManager;

    private const string PlayerTag = "Player";
    
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
        
    }

    //�R���C�_�[������
    private void VanishBarrierObject()
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

    //�R���C�_�[���I��
    private void AppearBarrierObject()
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

    // Update is called once per frame
    void Update()
    {
        //2D��
        if (!gameManager.vi)
        {
            AppearBarrierObject();
        }

        //�RD��
        if (gameManager.vi)
        {
            VanishBarrierObject();
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
