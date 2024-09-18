using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLorePanel : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            SceneManager.LoadScene("Level 1");
        }
    }
}
