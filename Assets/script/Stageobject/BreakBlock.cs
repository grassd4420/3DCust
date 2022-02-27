using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBlock : MonoBehaviour
{
    public GameObject GameManager;
    private BoxCollider[] boxcol;//�{�b�N�X�R���C�_�[�p�̔z��

    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        //�RD��
        if (GameManager.GetComponent<Switcher1>().vi == true)
        {
            //�ڐG�p�ƃg���K�[�p�̃{�b�N�X�R���C�_�[���擾�@�z��Ɋi�[
            boxcol = GetComponents<BoxCollider>();
            for (int i = 0; i < boxcol.Length; i++)
            {
                boxcol[0].size = new Vector3(1f, 1f, 1f);
                boxcol[0].center = new Vector3(0, -0.1f, 0);
                boxcol[1].size = new Vector3(1, 1, 1);
                
            }


        }
        //�QD��
        if (GameManager.GetComponent<Switcher1>().vi == false)
        {
            //�ڐG�p�ƃg���K�[�p�̃{�b�N�X�R���C�_�[���擾�@�z��Ɋi�[
            boxcol = GetComponents<BoxCollider>();
            for (int i = 0; i < boxcol.Length; i++)
            {
                boxcol[0].size = new Vector3(1f, 1f, 40f);
                boxcol[0].center = new Vector3(0, -0.1f, 0);
                boxcol[1].size = new Vector3(1, 1, 40);
                
            }

        }
    }
    private void OnTriggerEnter(Collider col)
    {

        //Player�̃^�O�̃I�u�W�F�N�g�ƐڐG�����ꍇ
        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject,0.1f);
        }
        // j��



    }
}
