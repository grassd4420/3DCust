using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Intro2Animation : MonoBehaviour
{
    private float countup = 0.0f;
    public GameObject GameManager;
    public Image sen1;
    public Image sen2;
    public Image sen3;
    public Image gro1;
    public Image gro2;
    public Image mou1;
    public Image sky1;
    public Image sky2;
    public Image sky3;
    public Image sky4;
    public Image sky5;
    public Image stage;
    public Image mess;



    //ŽžŠÔ‚ð•\Ž¦‚·‚éTextŒ^‚Ì•Ï”
    public Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {

        countup += Time.deltaTime;
        timeText.text = countup.ToString("f1") + "•b";

        //•`‰æŠJŽn
        sen1.fillAmount += Time.deltaTime * 0.13f;

        //ˆÈ‰ºŽžŠÔ‚ª—ˆ‚½‚ç•`‰æ
        if (countup >= 2.0f)
        {
            sen2.fillAmount += Time.deltaTime * 0.15f;
        }
        if (countup >= 2.4f)
        {
            sen3.fillAmount += Time.deltaTime * 0.15f;
        }
        if (countup >= 9.8f)
        {
            gro1.fillAmount += Time.deltaTime * 0.3f;
        }
        if (countup >= 10.5f)
        {
            mou1.fillAmount += Time.deltaTime * 0.3f;
        }
        if (countup >= 10.5f)
        {
            gro2.fillAmount += Time.deltaTime * 0.3f;
        }
        if (countup >= 13.2f)
        {
            sky1.fillAmount += Time.deltaTime * 0.9f;

        }
        if (countup >= 15f)
        {
            sky2.fillAmount += Time.deltaTime;
        }
        if (countup >= 16f)
        {
            sky3.fillAmount += Time.deltaTime * 1.5f;
        }
        if (countup >= 17f)
        {
            sky4.fillAmount += Time.deltaTime * 1.5f;
        }
        if (countup >= 17.5f)
        {
            sky5.fillAmount += Time.deltaTime * 1.5f;
        }
        if (countup >= 18.5f)
        {
            stage.fillAmount += Time.deltaTime * 1.5f;
        }
        if (countup >= 19.5f)
        {
            mess.fillAmount += Time.deltaTime * 1.5f;
        }
    }

}
