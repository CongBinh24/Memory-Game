using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int timeLimit;
    public MatchItem[] matchItems;
    public MatchItemUI itemUIPb;
    public Transform gridRoot;
    public GameState state;
    private List<MatchItem> m_matchItemsCopy; // data, Game dung de random, shuffle khong hien thi tren man hinh
    private List<MatchItemUI> m_matchItemUIs; // the bai that nguoi choi thay tren man hinh
    private List<MatchItemUI> m_answers;
    private float m_timeCounting;
    private int m_totalMatchItem;
    private int m_totalMoving;
    private int m_rightMoving;
    private bool m_isAnswerChecking;

    public int TotalMoving { get => m_totalMoving;}
    public int RightMoving { get => m_rightMoving;}

    public override void Awake()
    {
        MakeSingleton(false);
        m_matchItemsCopy = new List<MatchItem>();
        m_matchItemUIs = new List<MatchItemUI>();
        m_answers = new List<MatchItemUI>();
        m_timeCounting = timeLimit;
        state = GameState.Starting;
    }

    private void GenerateMatchItems()
    {
        if (matchItems == null || matchItems.Length <= 0 || itemUIPb == null || gridRoot == null) return;

        int totalItem = matchItems.Length;
        int divItem = totalItem % 2;
        m_totalMatchItem = totalItem - divItem;

        for (int i = 0; i < m_totalMatchItem; i++) 
        {
            var matchItem = matchItems[i];
            if(matchItem != null)
                matchItem.Id = i;
        }

        m_matchItemsCopy.AddRange(matchItems); // 1/2 tong so the can dung trong game
        m_matchItemsCopy.AddRange(matchItems); // tong so the can dung trong game

        ShuffleMatchItems();
        ClearGrid();



    }
    private void ShuffleMatchItems()
    {
        if (m_matchItemsCopy == null || m_matchItemsCopy.Count <= 0) return;

        for (int i = 0; i < m_matchItemsCopy.Count; i++)
        {
            var temp = m_matchItemsCopy[i];
            if(temp != null)
            {
                int randIdx = Random.Range(0, m_matchItemsCopy.Count);
                m_matchItemsCopy [i] = m_matchItemsCopy[randIdx];
                m_matchItemsCopy[randIdx] = temp;

            }
        }
    }


    private void ClearGrid()
    {
        if (gridRoot == null) return;

        for (int i = 0; i < gridRoot.childCount; i++)
        {
            var child = gridRoot.GetChild(i);
            if (child)
                Destroy(child.gameObject);
        }
    }
}
