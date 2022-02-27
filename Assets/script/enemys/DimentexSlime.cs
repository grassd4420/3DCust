using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��Ԉړ��\�iDimentex�j�X���C���̃X�N���v�g

public class DimentexSlime : MonoBehaviour
{
    public GameObject GameManager;
   
    public int SlHP = 6; //Dimentex�X���C����HP
    public GameObject damageEf;//�_���[�W�G�t�F�N�g
    float minAngle = 0.0F;//��]�p
    float maxAngle = 90.0F;//��]�p
    private BoxCollider[] boxcol;//�{�b�N�X�R���C�_�[�p�̔z��


    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        //�R����
        if (GameManager.GetComponent<Switcher1>().vi == true)
        {
            //�ڐG�p�ƃg���K�[�p�̃{�b�N�X�R���C�_�[���擾�@�z��Ɋi�[
            boxcol = GetComponents<BoxCollider>();
            for (int i = 0; i < boxcol.Length; i++)
            {
                boxcol[0].size = new Vector3(21f, 12f, 1f);
                boxcol[0].center = new Vector3(0, 0, 0);
                boxcol[1].size = new Vector3(12.79f, 2.2f, 0.5f);
                boxcol[1].center = new Vector3(0.19f, 5.96f, 0f);
            }

            //��]������3����Ԃɔ��f
            float angle = Mathf.LerpAngle(minAngle, maxAngle, 1);
            transform.eulerAngles = new Vector3(0, angle, 0);

        }

        if (GameManager.GetComponent<Switcher1>().vi == false)
        {

            //�ڐG�p�ƃg���K�[�p�̃{�b�N�X�R���C�_�[���擾�@�z��Ɋi�[
            boxcol = GetComponents<BoxCollider>();
            for (int i = 0; i < boxcol.Length; i++)
            {
                boxcol[0].size = new Vector3(18f, 12f, 30f);
                boxcol[0].center = new Vector3(0, 0, 0);
                boxcol[1].size = new Vector3(12.79f, 2.2f, 30f);
                boxcol[1].center = new Vector3(0.19f, 5.96f, 0f);
            }


            //��]������2����Ԃɔ��f
            float angle = Mathf.LerpAngle(maxAngle, minAngle, 1);
            transform.eulerAngles = new Vector3(0, angle, 0);

        }
    }
    private void OnTriggerEnter(Collider col)
    {


        if (col.gameObject.tag == "Player")
        {
            // j��
            SlHP -= 1;
            Vector3 hitPos = col.ClosestPointOnBounds(this.transform.position);
            GameObject effect = Instantiate(damageEf) as GameObject;
            effect.transform.position = (Vector3)hitPos;
            if (SlHP<=0)Destroy(gameObject, 0.2f);
            
        }
        // j��



    }
}
