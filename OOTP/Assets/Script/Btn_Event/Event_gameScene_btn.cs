using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Event_gameScene_btn : MonoBehaviour
{
    // ���� ���� ȭ��
    public void Back_MainScene_btn()
    {
        SceneManager.LoadScene("MainScene");
    }
}
