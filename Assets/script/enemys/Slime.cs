using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�X���C���̏���

public class Slime : MonoBehaviour
{
    public GameObject GameManager;
    public int SlHP = 6;�@//�X���C���̂g�o
    public GameObject damageEf;�@//�_���[�W�G�t�F�N�g
    private BoxCollider[] boxcol;�@//�{�b�N�X�R���C�_�[�p�̔z��
    
    
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {

        //�R�c��
        if (GameManager.GetComponent<Switcher1>().vi == true)
        {
            //�ڐG�p�ƃg���K�[�p�̃{�b�N�X�R���C�_�[���擾�@�z��Ɋi�[
            boxcol = GetComponents<BoxCollider>();
            for (int i = 0; i < boxcol.Length; i++)
            {


                boxcol[0].size = new Vector3(21f, 12f, 1f);
                boxcol[0].center = new Vector3(0, 0, 0);
                //boxcol[0].GetComponent<BoxCollider>().enabled = false;
                //boxcol[1].size = new Vector3(12.79f, 2.2f, 0.5f);
                //boxcol[1].center = new Vector3(0.19f, 5.96f, 0f);


                //3����Ԃł͐G����Ȃ��̂Ńg���K�[�̓����蔻�������
                boxcol[1].enabled = false;
            }

           

        }


        //�Q�c��
        if (GameManager.GetComponent<Switcher1>().vi == false)
        {

            //�ڐG�p�ƃg���K�[�p�̃{�b�N�X�R���C�_�[���擾�@�z��Ɋi�[
            boxcol = GetComponents<BoxCollider>();
            for (int i = 0; i < boxcol.Length; i++)
            {
                boxcol[0].size = new Vector3(18f, 12f, 30f);
                boxcol[0].center = new Vector3(0, 0, 0);
                boxcol[1].enabled = true;
                boxcol[1].size = new Vector3(12.79f, 2.2f, 30f);
                boxcol[1].center = new Vector3(0.19f, 5.96f, 0f);
            }

        }
    }
    private void OnTriggerEnter(Collider col)
    {


        if (col.gameObject.tag == "Player")
        {
            // ���݂����1�_���[�W
            SlHP -= 1;
            
            //���݂������W���擾
            Vector3 hitPos = col.ClosestPointOnBounds(this.transform.position);

            //�G�t�F�N�g���Ăяo��
            GameObject effect = Instantiate(damageEf) as GameObject;

            //���݂������W����G�t�F�N�g��r�o
            effect.transform.position = (Vector3)hitPos;
            
            //�X���C���̂g�o���O�ɂȂ�Δj��
            if (SlHP <= 0) Destroy(gameObject, 0.2f);


        }
       



    }
     

}
     
