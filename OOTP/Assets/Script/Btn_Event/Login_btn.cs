using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Login_btn : MonoBehaviour
{
    public void EnterLogin()
    {
        SceneManager.LoadScene("MainScene");
    }
}
