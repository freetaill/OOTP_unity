using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class Manage_Create_list : MonoBehaviour
{
    public GameObject prefab_hit; // 사용할 프리팹
    public GameObject prefab_pit;
    public Transform content_hit; // ScrollView의 Content Transform을 연결해주세요.
    public Transform content_pit;
    public List<GameObject> More_record_list;

    // 예시 데이터
    //private string[] data = { "Data 1", "Data 2", "Data 3", "Data 4", "Data 5" };
    int my_team = 0;

    void Start()
    {
        my_team = Manager.Instance.my_team;
        // 데이터를 스크롤뷰에 추가
        AddDataToScrollView_hit();
        AddDataToScrollView_pit();
    }

    void AddDataToScrollView_hit()
    {
        // 프리팹으로부터 새로운 인스턴스 생성 후 ScrollView의 Content에 추가
        for (int i = 0; i < 17; i++)
        {
            GameObject newItem = Instantiate(prefab_hit, content_hit);
            // 만약 프리팹 내부에 텍스트 등을 변경해야 한다면 아래와 같이 처리할 수 있습니다.
            Text[] textObjects = newItem.GetComponentsInChildren<Text>();
            Button buttenObject = newItem.GetComponentInChildren<Button>();
            if (i < 10){ textObjects[0].text = (i + 1).ToString() + "번"; }
            else { textObjects[0].text = "후보"; }
            textObjects[0].text = i.ToString() + "번";
            textObjects[1].text = Manager.Instance.team[my_team].Get_hitter_name(i);
            textObjects[2].text = Manager.Instance.team[my_team].Get_hitter_positon(i);
            textObjects[3].text = Manager.Instance.team[my_team].Get_hitter_condition(i);

            for (int j = 5; j < 10; j++)
            {
                textObjects[j].text = Manager.Instance.team[my_team].Get_hitter_stat(i, j-3).ToString();
            }
            int currentPlayerIndex = i; // 클로저에서 사용하기 위한 변수
            buttenObject.onClick.AddListener(() => OnButtonClick_hit(currentPlayerIndex));
        }
    }
    void AddDataToScrollView_pit()
    {
        for (int i = 0; i < 13; i++)
        {
            GameObject newItem = Instantiate(prefab_pit, content_pit);
            // 만약 프리팹 내부에 텍스트 등을 변경해야 한다면 아래와 같이 처리할 수 있습니다.
            Text[] textObjects = newItem.GetComponentsInChildren<Text>();
            Button buttenObject = newItem.GetComponentInChildren<Button>();
            if (textObjects.Length >= 10)
            {
                for (int j = 4; j < 10; j++)
                {
                    textObjects[j].text = Manager.Instance.team[my_team].Get_pitcher_stat(i, j - 2).ToString();
                }
            }
            int currentPlayerIndex = i; // 클로저에서 사용하기 위한 변수
            buttenObject.onClick.AddListener(() => OnButtonClick_pit(currentPlayerIndex));
        }
    }

    void OnButtonClick_hit(int playerIndex)
    {
        Debug.Log("Button Clicked for player at index: " + playerIndex);

        Text[] textObjects = More_record_list[1].GetComponentsInChildren<Text>();
        textObjects[0].text = Manager.Instance.team[my_team].Get_hitter_name(playerIndex);

        for (int j = 4; j < 9; j++)
        {
            textObjects[j].text = Manager.Instance.team[my_team].Get_hitter_stat(playerIndex, j - 2).ToString();
        }
        More_record_list[0].SetActive(true);
    }
    void OnButtonClick_pit(int playerIndex)
    {
        Debug.Log("Button Clicked for player at index: " + playerIndex);

        Text[] textObjects = More_record_list[3].GetComponentsInChildren<Text>();
        for (int j = 4; j < 9; j++)
        {
            textObjects[j].text = Manager.Instance.team[my_team].Get_pitcher_stat(playerIndex, j-2).ToString();
        }
        More_record_list[2].SetActive(true);
    }
}
