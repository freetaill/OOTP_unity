using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class One_round_Scene_btn : MonoBehaviour
{
    public List<GameObject> Screen_list;
    public List<GameObject> Set_list;
    public List<GameObject> Play_list;
    public List<GameObject> Result_list;

    private void Start()
    {
        Screen_list[0].SetActive(true);
        Screen_list[1].SetActive(false);
        Screen_list[2].SetActive(false);
    }

    // 게임 설정 화면

    // Game_set 화면 버튼
    public void Back_MainScene_btn()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void Start_game_btn()
    {
        Screen_list[0].SetActive(false);
        Screen_list[1].SetActive(true);
        Screen_list[2].SetActive(false);
    }
    // Game_play 화면 버튼
    // Result_Screen 화면 버튼
}
