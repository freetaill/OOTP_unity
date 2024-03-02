using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Game_log
{
    public int[,] All_game_log = new int[10, 20]; // 행(row), 열(col)
}

public class teams
{
    // 기본 정보
    public string[] teams_name = new string[10] 
    { "Samsung", "Lotte", "NC", "Doosan", "LG", "SSG", "KIA", "Kiwoom", "KT", "Hanwha" };
    public string[] hitter_position = new string[8] { "포수", "1루수", "2루수", "3루수", "유격수", "좌익수", "중경수", "우익수" };
    public string[] pitcher_position = new string[6] { "선발", "필승조", "추적조", "셋업", "롱릴", "마무리" };

    //팀 정보
    int team_num;
    int team_stadium;

    //선수 기록
    // 포지션 컨디션 선구안 정확도 파워 스피드 수비 오버롤
    string[] hitter_name = new string[17];
    int[,] hitter_stat = new int[17, 20];
    int[,] hitter_record = new int[17, 20];

    string[] pitcher_name = new string[13];
    int[,] pitcher_stat = new int[13, 20];
    int[,] pitcher_record = new int[13, 20];

    int dominated_hitter;

    //팀 기록
    int play_game = 0;
    int[] team_hitter_record = Enumerable.Repeat(0, 20).ToArray();
    int[] team_pitcher_record = Enumerable.Repeat(0, 20).ToArray();
    int[] win = Enumerable.Repeat(0, 10).ToArray();
    int[] lose = Enumerable.Repeat(0, 10).ToArray();
    int[] draw = Enumerable.Repeat(0, 10).ToArray();

    //접근 함수

    //초기설정
    public void Set_team_info(int num, string[] All_hitter_name, int[,] All_hitter_stat,
        string[] All_pitcher_name, int[,] All_pitcher_stat)
    {
        team_num = num;
        //team_stadium = 0;
        for (int i = 0; i < 17; i++)
        {
            hitter_name[i] = All_hitter_name[(num * 17) + i];
            for (int j = 0; j < 10; j++)
            {
                hitter_stat[i,j] = All_hitter_stat[(num * 30) + i, j];
            }
        }
        for (int i = 0; i < 13; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                pitcher_stat[i, j] = All_pitcher_stat[(num * 30) + i, j];
            }
        }
    }
    // 추가 함수
    void create_domi_list()
    {
        //int[] dominated = 
    }
    bool Isdominated(int pos)
    {
        return false;
    }

    //외부에서 한번에 접근
    public string[] Get_All_hitter_name() { return hitter_name; }
    public int[,] Get_All_hitter_stat() { return hitter_stat; }
    public string[] Get_All_pitcher_name() { return pitcher_name; }
    public int[,] Get_All_pitcher_stat() { return pitcher_stat; }

    //외부에서 개별접근
    public int Get_teams_num() { return team_num; }
    public string Get_team_name() { return teams_name[team_num]; }
    public string Get_hitter_name(int num) { return hitter_name[num]; }
    public string Get_hitter_positon(int num)
    {
        if (Isdominated(num)) { return "지명"; }
        else { return hitter_position[hitter_stat[num, 0] - 2]; }
    }
    public string Get_hitter_condition(int num)
    {
        switch (hitter_stat[num, 1])
        {
            case 1:
                return "[ 최상 ]";
            case 2: case 3:
                return "[  좋음  ]";
            case 4: case 5: case 6: case 7:
                return "[  보통  ]";
            case 8: case 9:
                return "[  나쁨  ]";
            case 10:
                return "[  최악  ]";
        }
        return "오류";
    }
    public int Get_hitter_stat(int num, int stat) { return hitter_stat[num, stat]; }
    public int Get_hitter_record(int num, int record) { return hitter_record[num, record]; }
    public string Get_pitcher_name(int num) { return pitcher_name[num]; }
    public int Get_pitcher_stat(int num, int stat) { return pitcher_stat[num, stat]; }
    public int Get_pitchter_record(int num, int record) { return pitcher_record[num, record]; }

    //정보 갱신
    public void updata_player_record() { }
    public void update_play_game(int value) { play_game += value; }
    public void update_result(bool Ishome, int away_score, int home_score, int battle_team)
    {
        if (Ishome)
        {
            if (home_score > away_score) { win[battle_team]++; }
            else if (home_score < away_score) { lose[battle_team]++; }
            else { draw[battle_team]++; }
        }
        else
        {
            if (home_score < away_score) { win[battle_team]++; }
            else if (home_score > away_score) { lose[battle_team]++; }
            else { draw[battle_team]++; }
        }
    }
}

public class Manager : MonoBehaviour
{
    //내부 인스턴스 변수
    private static Manager _instance;
    //외부 호출용 인스턴스 변수
    public static Manager Instance => Initialize();
    //변수
    public int my_team = 0;
    int[,] All_hitter_stat;
    int[,] All_pitcher_stat;
    string[] All_hitter_name;
    string[] All_pitcher_name;

    // 팀 목록
    // 0: Samsung;
    // 1: Lotte;
    // 2: NC;
    // 3: Doosan;
    // 4: LG;
    // 5: SSG;
    // 6: KIA;
    // 7: Kiwoom;
    // 8: KT;
    // 9: Hanwha;
    public teams[] team = new teams[10];


    private void Start()
    {
        Initialize();
        install_save();
        Set_data();
    }
    private static Manager Initialize()
    {
        if(_instance == null)
        {
            GameObject findManager = GameObject.Find("Manager");

            if(findManager == null)
            {
                findManager = new GameObject("Manager");

                findManager.AddComponent<Manager>();
            }

            DontDestroyOnLoad(findManager);

            _instance = findManager.GetComponent<Manager>();
        }
        return _instance;
    }

    void install_save()
    {
        All_hitter_name = GameObject.Find("EventSystem").
            GetComponent<Player_Info>().All_hitter_name;
        All_hitter_stat = GameObject.Find("EventSystem").
            GetComponent<Player_Info>().All_hitter_stat;
        All_pitcher_name = GameObject.Find("EventSystem").
            GetComponent<Player_Info>().All_pitcher_name;
        All_pitcher_stat = GameObject.Find("EventSystem").
            GetComponent<Player_Info>().All_pitcher_stat;
    }

    void Set_data()
    {
        for (int i = 0; i < team.Length; i++)
        {
            team[i] = new teams();
        }
        for (int i = 0; i < team.Length; i++)
        {
            team[i].Set_team_info(i, All_hitter_name, All_hitter_stat,
                    All_pitcher_name, All_pitcher_stat);
        }
    }
}
