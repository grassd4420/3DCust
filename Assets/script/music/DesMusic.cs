using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DesMusic : MonoBehaviour
{
    [SerializeField] string intoro1;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
    }

    private void OnMouseDown()
    {
        SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetActiveScene());
        SceneManager.LoadScene(intoro1);
    }
}
