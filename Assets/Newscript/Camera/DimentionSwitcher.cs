using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//２ｄと3ｄの空間を切り替えるスクリプト
public class DimentionSwitcher : MonoBehaviour
{
    [SerializeField] private TimeCounter GameObject;
    

    
    public GameObject mainCam;//２ｄカメラ
    public GameObject subCam;//3ｄカメラ
    public bool overtime = false;//空間切り替え可能か判定

    public bool vi = false; //空間切り替え判定

    //////  vi false   2d  /////
    //////  vi true    3d  /////

    //////  overtime false 空間切り替え可能   /////
    //////  overtime true  空間切り替え不可  /////


 


    // Start is called before the first frame update

    void Start()
    {

        mainCam.SetActive(true);
        subCam.SetActive(false);
        

    }

    // Update is called once per frame
    void Update()
    {
        //空間切り替え可能な場合
        if(overtime == false)
        {
            //Ｇキーを押すと空間切り替え
            if (Input.GetKeyDown(KeyCode.G))
            {
                mainCam.SetActive(!mainCam.activeSelf);
                subCam.SetActive(!subCam.activeSelf);

                vi = !vi;
            }
        }

        //制限時間以上３ｄ空間に居ると空間切り替え不可

        //TimeCounterのoverを参照
        if (GameObject.over == true)
        {
           
            if (!overtime)
            {

                overtime = true;
                //強制的に切り替え
                mainCam.SetActive(!mainCam.activeSelf);
                subCam.SetActive(!subCam.activeSelf);
                vi = !vi;
            }

        }

        //空間切り替え不可を解除

        //TimeCounterのoverを参照
        if (GameObject.over == false)
        {
            overtime = false;
        }

    }
    
}
