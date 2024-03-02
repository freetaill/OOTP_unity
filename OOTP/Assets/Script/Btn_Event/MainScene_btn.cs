using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScene_btn : MonoBehaviour
{
    public List<GameObject> Screen_list;
    public List<GameObject> RAS_list;
    public List<GameObject> BANT_list;
    public List<GameObject> Setting_list;

    private void Start()
    {
        Screen_list[0].SetActive(true);
        Screen_list[1].SetActive(false);
        Screen_list[2].SetActive(false);
        Screen_list[3].SetActive(false);
        Screen_list[4].SetActive(false);
        Screen_list[5].SetActive(false);
    }

    // Main_Screen 화면 버튼

    public void Select_Screen_btn()
    {
        Screen_list[0].SetActive(false);
        Screen_list[1].SetActive(true);
        Screen_list[2].SetActive(false);
        Screen_list[3].SetActive(false);
        Screen_list[4].SetActive(false);
        Screen_list[5].SetActive(false);
    }
    public void Record_and_set_Screen_btn()
    {
        Screen_list[0].SetActive(false);
        Screen_list[1].SetActive(false);
        Screen_list[2].SetActive(true);
        Screen_list[3].SetActive(false);
        Screen_list[4].SetActive(false);
        Screen_list[5].SetActive(false);
        Start_RAS();
    }
    public void Buy_and_Team_set_Screen_btn()
    {
        Screen_list[0].SetActive(false);
        Screen_list[1].SetActive(false);
        Screen_list[2].SetActive(false);
        Screen_list[3].SetActive(true);
        Screen_list[4].SetActive(false);
        Screen_list[5].SetActive(false);
    }
    public void Setting_btn()
    {
        Screen_list[0].SetActive(false);
        Screen_list[1].SetActive(false);
        Screen_list[2].SetActive(false);
        Screen_list[3].SetActive(false);
        Screen_list[4].SetActive(true);
        Screen_list[5].SetActive(false);
    }
    public void EndGame_btn()
    {
        Screen_list[0].SetActive(true);
        Screen_list[1].SetActive(false);
        Screen_list[2].SetActive(false);
        Screen_list[3].SetActive(false);
        Screen_list[4].SetActive(false);
        Screen_list[5].SetActive(false);
    }
    
    // Select_Screen 화면 버튼
    public void Go_One_round_btn()
    {
        SceneManager.LoadScene("One_round_Scene");
    }
    public void Go_League_btn()
    {
        SceneManager.LoadScene("League_Scene");
    }

    public void Go_Event_Game_btn()
    {
        SceneManager.LoadScene("Event_gameScene");
    }

    //Record_and_set_Screen 화면 버튼

    void Start_RAS()
    {
        RAS_list[0].SetActive(true);
        RAS_list[1].SetActive(false);
        RAS_list[2].SetActive(false);
        RAS_list[3].SetActive(false);
        RAS_list[4].SetActive(false);
        RAS_list[5].SetActive(false);
        RAS_list[6].SetActive(false);
    }
    public void Click_show_hitter()
    {
        RAS_list[0].SetActive(true);
        RAS_list[1].SetActive(false);
        RAS_list[2].SetActive(false);
        RAS_list[3].SetActive(false);
        RAS_list[4].SetActive(false);
        RAS_list[5].SetActive(false);
        RAS_list[6].SetActive(false);
    }
    public void Click_show_pitcher()
    {
        RAS_list[0].SetActive(false);
        RAS_list[1].SetActive(false);
        RAS_list[2].SetActive(true);
        RAS_list[3].SetActive(false);
        RAS_list[4].SetActive(false);
        RAS_list[5].SetActive(false);
        RAS_list[6].SetActive(false);
    }

    public void Close_Player_record_hitter()
    {
        RAS_list[0].SetActive(false);
        RAS_list[1].SetActive(false);
        RAS_list[2].SetActive(false);
        RAS_list[3].SetActive(false);
        RAS_list[4].SetActive(false);
        RAS_list[5].SetActive(false);
        RAS_list[6].SetActive(false);
    }

    public void Close_Player_record_pitcher()
    {
        RAS_list[0].SetActive(false);
        RAS_list[1].SetActive(false);
        RAS_list[2].SetActive(false);
        RAS_list[3].SetActive(false);
        RAS_list[4].SetActive(false);
        RAS_list[5].SetActive(false);
        RAS_list[6].SetActive(false);
    }
    public void Game_record_btn()
    {
        if (RAS_list[4].activeSelf == false)
        {
            RAS_list[0].SetActive(false);
            RAS_list[1].SetActive(false);
            RAS_list[2].SetActive(false);
            RAS_list[3].SetActive(false);
            RAS_list[4].SetActive(true);
            RAS_list[5].SetActive(false);
            RAS_list[6].SetActive(false);
        }
        else
        {
            RAS_list[0].SetActive(false);
            RAS_list[1].SetActive(false);
            RAS_list[2].SetActive(false);
            RAS_list[3].SetActive(false);
            RAS_list[4].SetActive(false);
            RAS_list[5].SetActive(false);
            RAS_list[6].SetActive(false);
        }
    }
    public void Open_Change_player_btn()
    {
        RAS_list[0].SetActive(false);
        RAS_list[1].SetActive(false);
        RAS_list[2].SetActive(false);
        RAS_list[3].SetActive(false);
        RAS_list[4].SetActive(false);
        RAS_list[5].SetActive(true);
        RAS_list[6].SetActive(false);
    }

    public void Close_Change_player_btn()
    {
        RAS_list[0].SetActive(false);
        RAS_list[1].SetActive(false);
        RAS_list[2].SetActive(false);
        RAS_list[3].SetActive(false);
        RAS_list[4].SetActive(false);
        RAS_list[5].SetActive(false);
        RAS_list[6].SetActive(false);
    }
    public void Change_one_page_pit()
    {
        RAS_list[6].SetActive(false);
    }

    public void Change_two_page_pit()
    {
        RAS_list[6].SetActive(true);
    }

    //Buy_and_Team_set_Screen 화면 버튼

    // Setting 화면 버튼

    // 공용
    public void Lording() { }
    public void Back_Main_Screen_btn()
    {
        Screen_list[0].SetActive(true);
        Screen_list[1].SetActive(false);
        Screen_list[2].SetActive(false);
        Screen_list[3].SetActive(false);
        Screen_list[4].SetActive(false);
        Screen_list[5].SetActive(false);
    }
}
