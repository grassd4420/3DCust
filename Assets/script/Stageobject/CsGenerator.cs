using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�]�����ė����Q���̐�������


public class CsGenerator : MonoBehaviour
{

    public GameObject CsPrefab;
    float span = 5.0f;�@//�����Ԋu
    float delta = 0;
    public Vector3 pos;
    public int x, y;�@//�������W�̍ő�ƍŏ��l

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject go = Instantiate(CsPrefab) as GameObject;
            int px = Random.Range(x,y);
            go.transform.position = new Vector3(pos.x, pos.y, px);
        }
    }
}
