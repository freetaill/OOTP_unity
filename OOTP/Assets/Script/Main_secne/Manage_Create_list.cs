using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class Manage_Create_list : MonoBehaviour
{
    public GameObject prefab_hit; // ����� ������
    public GameObject prefab_pit;
    public Transform content_hit; // ScrollView�� Content Transform�� �������ּ���.
    public Transform content_pit;
    public List<GameObject> More_record_list;

    // ���� ������
    //private string[] data = { "Data 1", "Data 2", "Data 3", "Data 4", "Data 5" };
    int my_team = 0;

    void Start()
    {
        my_team = Manager.Instance.my_team;
        // �����͸� ��ũ�Ѻ信 �߰�
        AddDataToScrollView_hit();
        AddDataToScrollView_pit();
    }

    void AddDataToScrollView_hit()
    {
        // ���������κ��� ���ο� �ν��Ͻ� ���� �� ScrollView�� Content�� �߰�
        for (int i = 0; i < 17; i++)
        {
            GameObject newItem = Instantiate(prefab_hit, content_hit);
            // ���� ������ ���ο� �ؽ�Ʈ ���� �����ؾ� �Ѵٸ� �Ʒ��� ���� ó���� �� �ֽ��ϴ�.
            Text[] textObjects = newItem.GetComponentsInChildren<Text>();
            Button buttenObject = newItem.GetComponentInChildren<Button>();
            if (i < 10){ textObjects[0].text = (i + 1).ToString() + "��"; }
            else { textObjects[0].text = "�ĺ�"; }
            textObjects[0].text = i.ToString() + "��";
            textObjects[1].text = Manager.Instance.team[my_team].Get_hitter_name(i);
            textObjects[2].text = Manager.Instance.team[my_team].Get_hitter_positon(i);
            textObjects[3].text = Manager.Instance.team[my_team].Get_hitter_condition(i);

            for (int j = 5; j < 10; j++)
            {
                textObjects[j].text = Manager.Instance.team[my_team].Get_hitter_stat(i, j-3).ToString();
            }
            int currentPlayerIndex = i; // Ŭ�������� ����ϱ� ���� ����
            buttenObject.onClick.AddListener(() => OnButtonClick_hit(currentPlayerIndex));
        }
    }
    void AddDataToScrollView_pit()
    {
        for (int i = 0; i < 13; i++)
        {
            GameObject newItem = Instantiate(prefab_pit, content_pit);
            // ���� ������ ���ο� �ؽ�Ʈ ���� �����ؾ� �Ѵٸ� �Ʒ��� ���� ó���� �� �ֽ��ϴ�.
            Text[] textObjects = newItem.GetComponentsInChildren<Text>();
            Button buttenObject = newItem.GetComponentInChildren<Button>();
            if (textObjects.Length >= 10)
            {
                for (int j = 4; j < 10; j++)
                {
                    textObjects[j].text = Manager.Instance.team[my_team].Get_pitcher_stat(i, j - 2).ToString();
                }
            }
            int currentPlayerIndex = i; // Ŭ�������� ����ϱ� ���� ����
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
