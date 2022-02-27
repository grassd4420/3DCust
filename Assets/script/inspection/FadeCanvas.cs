using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeCanvas : MonoBehaviour
{

    [System.NonSerialized]
    public bool fadeIn = false;
    [System.NonSerialized]
    public bool fadeOut = false;

    [SerializeField]
    Image panelImage;
    [SerializeField]
    float fadeSpeed = 0.02f;

    float red, green, blue, alpha;

    //�ŏ��̏���
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        //���̐F���擾
        red = panelImage.color.r;
        green = panelImage.color.g;
        blue = panelImage.color.b;
        alpha = panelImage.color.a;
    }

    //���t���[���̏���
    void Update()
    {
        if (fadeIn)
        {
            FadeIn();
        }
        else if (fadeOut)
        {
            FadeOut();
        }
    }

    //�t�F�[�h�C��
    void FadeIn()
    {
        alpha += fadeSpeed;

        SetAlpha();

        if (alpha >= 1)
        {
            fadeIn = false;
        }
    }

    //�t�F�[�h�A�E�g
    void FadeOut()
    {
        alpha -= fadeSpeed;

        SetAlpha();

        if (alpha <= 0)
        {
            fadeOut = false;

            Destroy(gameObject);
        }
    }

    //�����x��ύX
    void SetAlpha()
    {
        panelImage.color = new Color(red, green, blue, alpha);
    }
}