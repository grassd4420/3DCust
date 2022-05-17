using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage1IntroAnimation : MonoBehaviour
{
    private float countup = 0.0f;
    public Image sen1;
    public Image sen2;
    public Image sen3;
    public Image gro1;
    public Image mou1;
    public Image sky1;
    public Image sky2;
    public Image sky3;
    public Image stage;
    public Image mess;

    //ŽžŠÔ‚ð•\Ž¦‚·‚éTextŒ^‚Ì•Ï”
    public Text timeText;

    public Image Draw;//ŠÖ”‚É“n‚·Û‚É•`‰æ‚·‚é‰æ‘œ‚ðŠi”[‚·‚é—p
    private float DrawSpeed;//•`‰æƒXƒs[ƒh

    //ƒCƒ[ƒW‚ð•`‰æ‚·‚éŠÖ”(•`‰æ‚·‚é‰æ‘œ ,@•`‰æƒXƒs[ƒh)
    private void DrawaImages(Image Draw, float DrawSpeed)
    {
        Draw.fillAmount += Time.deltaTime * DrawSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
        countup += Time.deltaTime;
        timeText.text = countup.ToString("f1") + "•b";

        //•`‰æŠJŽn
        DrawaImages(sen1, 0.13f);

        //ˆÈ‰ºŽžŠÔ‚ª—ˆ‚½‚ç•`‰æ
        if (countup >= 2.0f)
        {
            DrawaImages(sen2, 0.15f);
        }

        if (countup >= 2.4f)
        {
            DrawaImages(sen3, 0.15f);
        }

        if (countup >= 9.8f)
        {
            DrawaImages(gro1, 0.3f);
        }

        if (countup >= 10.5f)
        {
            DrawaImages(mou1, 0.3f);
        }

        if (countup >= 13.2f)
        {
            DrawaImages(sky1, 0.9f);
        }

        if (countup >= 15f)
        {
            DrawaImages(sky2, 1f);
        }

        if (countup >= 16f)
        {
            DrawaImages(sky3, 1.5f);
        }

        if (countup >= 17.5f)
        {
            DrawaImages(stage, 1.5f);
        }

        if (countup >= 18.5f)
        {
            DrawaImages(mess, 1.5f);
        }

    }

}
