using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Game_play_Event: MonoBehaviour
{
    // 필요한 오브젝트 설정
    public int my_team;
    public int side_team;
    public Dropdown dropdown;
    public GameObject[] player_perfab;
    public Transform[] player_trans;
    public Image[] Logo;
    public Sprite[] img_list;
    public GameObject[] play_game_obj;
    public GameObject[] game_result_obj;

    // 변수 가져오기
    string[] hitter_name = new string[17];
    int[,] Player_hitter = new int[17, 20];
    string[] pitcher_name = new string[13];
    int[,] Player_pitcher = new int[13, 20];
    GameObject[,] hit_player_list = new GameObject[2,17];

    // 경기 기록
    int[] half_set;
    int[] round_point;
    int[] Total_log; 

    private void Start()
    {
        Game_set();
    }

    // 공용
    void Destroy_object(Transform transform)
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        Debug.Log("삭제");
    }

    //Game_set 화면 명령어
    void Game_set()
    {
        //dropdown = GetComponent<Dropdown>();
        my_team = 0;
        side_team = 0;
        if (my_team == dropdown.value)
        {
            int indexs = (my_team + 1) % 10;
            dropdown.value = indexs;
        }
        dropdown.onValueChanged.AddListener(delegate { OnValueChanged(dropdown); });
        OnValueChanged(dropdown);
    }

    void OnValueChanged(Dropdown dropdown)
    {
        if (dropdown.value == my_team)
        {
            dropdown.value = side_team;
            return;
        }
        else
        {
            side_team = dropdown.value;
            Logo[0].sprite = img_list[side_team];
            AddDataView_hit();
            AddDataView_pit();
            return;
        }
    }

    void AddDataView_hit()
    {
        Destroy_object(player_trans[0]);
        for (int i = 0; i < 9; i++)
        {
            GameObject newItem = Instantiate(player_perfab[0], player_trans[0]);
            // 만약 프리팹 내부에 텍스트 등을 변경해야 한다면 아래와 같이 처리할 수 있습니다.
            Text[] textObjects = newItem.GetComponentsInChildren<Text>();
            textObjects[0].text = i.ToString()+"번 타수";
            textObjects[1].text = Manager.Instance.team[side_team].Get_hitter_name(i);
            //textObjects[2].text = ;
            //textObjects[3].text = ;
            //textObjects[4].text = ;
        }
        for (int i = 9; i < 17; i++)
        {
            GameObject newItem = Instantiate(player_perfab[0], player_trans[0]);
            // 만약 프리팹 내부에 텍스트 등을 변경해야 한다면 아래와 같이 처리할 수 있습니다.
            Text[] textObjects = newItem.GetComponentsInChildren<Text>();
            textObjects[0].text = "후보";
            textObjects[1].text = Manager.Instance.team[side_team].Get_hitter_name(i);
            //textObjects[2].text = ;
            //textObjects[3].text = ;
            //textObjects[4].text = ;
        }
        Debug.Log("타수 재생성");
    }
    void AddDataView_pit()
    {
        Destroy_object(player_trans[1]);
        for (int i = 0; i < 5; i++)
        {
            GameObject newItem = Instantiate(player_perfab[1], player_trans[1]);
            // 만약 프리팹 내부에 텍스트 등을 변경해야 한다면 아래와 같이 처리할 수 있습니다.
            Text[] textObjects = newItem.GetComponentsInChildren<Text>();
            textObjects[0].text = i.ToString() + "번 투수";
            //textObjects[1].text = hitter_name[side_team * 13 + i];
            //textObjects[2].text = ;
            //textObjects[3].text = ;
            //textObjects[4].text = ;
        }
        for (int i = 5; i < 13; i++)
        {
            GameObject newItem = Instantiate(player_perfab[1], player_trans[1]);
            // 만약 프리팹 내부에 텍스트 등을 변경해야 한다면 아래와 같이 처리할 수 있습니다.
            Text[] textObjects = newItem.GetComponentsInChildren<Text>();
            textObjects[0].text = "중계";
            //textObjects[1].text = hitter_name[side_team * 13 + i];
            //textObjects[2].text = ;
            //textObjects[3].text = ;
            //textObjects[4].text = ;
        }
        Debug.Log("투수 재생성");
    }

    void Add_game_player_lsit()
    {
        Destroy_object(play_game_obj[1].transform);
        for (int i = 0; i < 9; i++)
        {
            GameObject newItem = Instantiate(player_perfab[2], play_game_obj[1].transform);
            // 만약 프리팹 내부에 텍스트 등을 변경해야 한다면 아래와 같이 처리할 수 있습니다.
            Text[] textObjects = newItem.GetComponentsInChildren<Text>();
            textObjects[0].text = "[ " + i.ToString() + "번 ]";
            textObjects[1].text = Manager.Instance.team[side_team].Get_hitter_name(i); // 이름
            //textObjects[2].text = ; //오늘 컨디션
            textObjects[3].text = Manager.Instance.team[side_team].Get_hitter_positon(i); //포지션
            //textObjects[4].text = ; // 타율
        }
        for (int i = 9; i < 17; i++)
        {
            GameObject newItem = Instantiate(player_perfab[0], player_trans[0]);
            // 만약 프리팹 내부에 텍스트 등을 변경해야 한다면 아래와 같이 처리할 수 있습니다.
            Text[] textObjects = newItem.GetComponentsInChildren<Text>();
            textObjects[0].text = "후보";
            textObjects[1].text = Manager.Instance.team[side_team].Get_hitter_name(i);
            //textObjects[2].text = ;
            //textObjects[3].text = ;
            //textObjects[4].text = ;
        }
    }

    //Game_play 화면 함수

    public void One_round_play()
    {
        round_point = new int[12] 
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        Total_log = new int[4] { 0, 0, 0, 0 };
        for(int i = 0; i < 12; i++)
        {
            half_set = new int[3] { 0, 0, 0 };
        }
    }
}
