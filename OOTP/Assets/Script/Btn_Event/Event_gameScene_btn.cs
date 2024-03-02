using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Event_gameScene_btn : MonoBehaviour
{
    // 게임 설정 화면
    public void Back_MainScene_btn()
    {
        SceneManager.LoadScene("MainScene");
    }
}
