using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//�Q����3���̋�Ԃ�؂�ւ���X�N���v�g
public class Switcher1 : MonoBehaviour
{
    public GameObject GameObject;
    public GameObject mainCam;//�Q���J����
    public GameObject subCam;//3���J����
    public bool overtime = false;//��Ԑ؂�ւ��\������

    public bool vi = false; //��Ԑ؂�ւ�����

    //////  vi false   2d  /////
    //////  vi true    3d  /////

    //////  overtime false ��Ԑ؂�ւ��\   /////
    //////  overtime true  ��Ԑ؂�ւ��s��  /////


    // void Timestop()
    //{
    //   Time.timeScale = 0;
    //   Invoke(nameof(Timest), 0.5f);

    //}
    //void Timest()
    //{
    //    Time.timeScale = 1.0f;

    //    Debug.Log("strat");
    // }


    // Start is called before the first frame update

    void Start()
    {

        mainCam.SetActive(true);
        subCam.SetActive(false);
        GameObject = GameObject.Find("GameObject");

    }

    // Update is called once per frame
    void Update()
    {
        //��Ԑ؂�ւ��\�ȏꍇ
        if(overtime == false)
        {
            //�f�L�[�������Ƌ�Ԑ؂�ւ�
            if (Input.GetKeyDown(KeyCode.G))
            {
                mainCam.SetActive(!mainCam.activeSelf);
                subCam.SetActive(!subCam.activeSelf);

                vi = !vi;


                //Timestop();
            }
        }

        //�������Ԉȏ�R����Ԃɋ���Ƌ�Ԑ؂�ւ��s��
        //TimeCounter��over���Q��
        if (GameObject.GetComponent<TimeCounter>().over == true)
        {
           
            if (!overtime)
            {

                overtime = true;
                //�����I�ɐ؂�ւ�
                mainCam.SetActive(!mainCam.activeSelf);
                subCam.SetActive(!subCam.activeSelf);
                

                vi = !vi;
            }

            //Timestop();

        }

        //��Ԑ؂�ւ��s������
        //TimeCounter��over���Q��
        if (GameObject.GetComponent<TimeCounter>().over == false)
        {
            overtime = false;
        }

    }
    
}
