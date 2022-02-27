using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [System.NonSerialized]
    public int currentStageNum = 0; //���݂̃X�e�[�W�ԍ��i0�n�܂�j

    [SerializeField]
    string[] stageName; //�X�e�[�W��
    [SerializeField]
    GameObject fadeCanvasPrefab;
    [SerializeField]
    float fadeWaitTime = 1.0f; //�t�F�[�h���̑҂�����

    GameObject fadeCanvasClone;
    FadeCanvas fadeCanvas;

    //�ŏ��̏���
    void Start()
    {
        //�V�[����؂�ւ��Ă����̃Q�[���I�u�W�F�N�g���폜���Ȃ��悤�ɂ���
        DontDestroyOnLoad(gameObject);
    }

    //���t���[���̏���
    void Update()
    {

    }

    //���̃X�e�[�W�ɐi�ޏ���
    public void NextStage()
    {
        currentStageNum += 1;

        //�R���[�`�������s
        StartCoroutine(WaitForLoadScene());
    }

    //�V�[���̓ǂݍ��݂Ƒҋ@���s���R���[�`��
    IEnumerator WaitForLoadScene()
    {
        //�t�F�[�h�I�u�W�F�N�g�𐶐�
        fadeCanvasClone = Instantiate(fadeCanvasPrefab);

        //�R���|�[�l���g���擾
        fadeCanvas = fadeCanvasClone.GetComponent<FadeCanvas>();

        //�t�F�[�h�C��������
        fadeCanvas.fadeIn = true;

        yield return new WaitForSeconds(fadeWaitTime);

        //�V�[����񓯊��œǍ����A�ǂݍ��܂��܂őҋ@����
        yield return SceneManager.LoadSceneAsync(stageName[currentStageNum]);

        //�t�F�[�h�A�E�g������
        fadeCanvas.fadeOut = true;
    }

    //�Q�[���I�[�o�[����
    public void GameOver()
    {

    }

}