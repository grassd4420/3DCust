using UnityEngine;
using System.Collections.Generic;
public class InputProxy : MonoBehaviour
{
    public static InputProxy Instance { get; private set; }
    public List<KeyCode> disabledKeys = new List<KeyCode>();
    void Start()
    {
        Instance = this;
    }
    void OnDestroy()
    {
        Instance = null;
    }
    public bool GetKey(KeyCode key)
    {
        return !disabledKeys.Contains(key) && Input.GetKey(key);
    }
}