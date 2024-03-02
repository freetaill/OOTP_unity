using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Game_play_Event: MonoBehaviour
{
    // �ʿ��� ������Ʈ ����
    public int my_team;
    public int side_team;
    public Dropdown dropdown;
    public GameObject[] player_perfab;
    public Transform[] player_trans;
    public Image[] Logo;
    public Sprite[] img_list;
    public GameObject[] play_game_obj;
    public GameObject[] game_result_obj;

    // ���� ��������
    string[] hitter_name = new string[17];
    int[,] Player_hitter = new int[17, 20];
    string[] pitcher_name = new string[13];
    int[,] Player_pitcher = new int[13, 20];
    GameObject[,] hit_player_list = new GameObject[2,17];

    // ��� ���
    int[] half_set;
    int[] round_point;
    int[] Total_log; 

    private void Start()
    {
        Game_set();
    }

    // ����
    void Destroy_object(Transform transform)
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        Debug.Log("����");
    }

    //Game_set ȭ�� ��ɾ�
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
            // ���� ������ ���ο� �ؽ�Ʈ ���� �����ؾ� �Ѵٸ� �Ʒ��� ���� ó���� �� �ֽ��ϴ�.
            Text[] textObjects = newItem.GetComponentsInChildren<Text>();
            textObjects[0].text = i.ToString()+"�� Ÿ��";
            textObjects[1].text = Manager.Instance.team[side_team].Get_hitter_name(i);
            //textObjects[2].text = ;
            //textObjects[3].text = ;
            //textObjects[4].text = ;
        }
        for (int i = 9; i < 17; i++)
        {
            GameObject newItem = Instantiate(player_perfab[0], player_trans[0]);
            // ���� ������ ���ο� �ؽ�Ʈ ���� �����ؾ� �Ѵٸ� �Ʒ��� ���� ó���� �� �ֽ��ϴ�.
            Text[] textObjects = newItem.GetComponentsInChildren<Text>();
            textObjects[0].text = "�ĺ�";
            textObjects[1].text = Manager.Instance.team[side_team].Get_hitter_name(i);
            //textObjects[2].text = ;
            //textObjects[3].text = ;
            //textObjects[4].text = ;
        }
        Debug.Log("Ÿ�� �����");
    }
    void AddDataView_pit()
    {
        Destroy_object(player_trans[1]);
        for (int i = 0; i < 5; i++)
        {
            GameObject newItem = Instantiate(player_perfab[1], player_trans[1]);
            // ���� ������ ���ο� �ؽ�Ʈ ���� �����ؾ� �Ѵٸ� �Ʒ��� ���� ó���� �� �ֽ��ϴ�.
            Text[] textObjects = newItem.GetComponentsInChildren<Text>();
            textObjects[0].text = i.ToString() + "�� ����";
            //textObjects[1].text = hitter_name[side_team * 13 + i];
            //textObjects[2].text = ;
            //textObjects[3].text = ;
            //textObjects[4].text = ;
        }
        for (int i = 5; i < 13; i++)
        {
            GameObject newItem = Instantiate(player_perfab[1], player_trans[1]);
            // ���� ������ ���ο� �ؽ�Ʈ ���� �����ؾ� �Ѵٸ� �Ʒ��� ���� ó���� �� �ֽ��ϴ�.
            Text[] textObjects = newItem.GetComponentsInChildren<Text>();
            textObjects[0].text = "�߰�";
            //textObjects[1].text = hitter_name[side_team * 13 + i];
            //textObjects[2].text = ;
            //textObjects[3].text = ;
            //textObjects[4].text = ;
        }
        Debug.Log("���� �����");
    }

    void Add_game_player_lsit()
    {
        Destroy_object(play_game_obj[1].transform);
        for (int i = 0; i < 9; i++)
        {
            GameObject newItem = Instantiate(player_perfab[2], play_game_obj[1].transform);
            // ���� ������ ���ο� �ؽ�Ʈ ���� �����ؾ� �Ѵٸ� �Ʒ��� ���� ó���� �� �ֽ��ϴ�.
            Text[] textObjects = newItem.GetComponentsInChildren<Text>();
            textObjects[0].text = "[ " + i.ToString() + "�� ]";
            textObjects[1].text = Manager.Instance.team[side_team].Get_hitter_name(i); // �̸�
            //textObjects[2].text = ; //���� �����
            textObjects[3].text = Manager.Instance.team[side_team].Get_hitter_positon(i); //������
            //textObjects[4].text = ; // Ÿ��
        }
        for (int i = 9; i < 17; i++)
        {
            GameObject newItem = Instantiate(player_perfab[0], player_trans[0]);
            // ���� ������ ���ο� �ؽ�Ʈ ���� �����ؾ� �Ѵٸ� �Ʒ��� ���� ó���� �� �ֽ��ϴ�.
            Text[] textObjects = newItem.GetComponentsInChildren<Text>();
            textObjects[0].text = "�ĺ�";
            textObjects[1].text = Manager.Instance.team[side_team].Get_hitter_name(i);
            //textObjects[2].text = ;
            //textObjects[3].text = ;
            //textObjects[4].text = ;
        }
    }

    //Game_play ȭ�� �Լ�

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
