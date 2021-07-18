using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsManager : MonoBehaviour
{


    #region Inspector
    [SerializeField] private List<CardSO> cardSoCollection;
    [SerializeField] private SaveSo SaveSo;

    #endregion



    #region ClassData

     private List<Card> myCards = new List<Card>();
     private List<int> idList = new List<int>();

    #endregion



    #region Interface
    public IEnumerator GetNewCards()
    {

       yield return StartCoroutine(numberCollector(new Vector2(0, cardSoCollection.Count), myCards.Count));
        
        for (int i = 0; i < myCards.Count; i++)
        {
            myCards[i].LoadNewCardData(cardSoCollection[idList[i]].cardData);
            myCards[i].LoadCardVisuals();
        }
    }


    #endregion

    #region Process
    void SaveCards()
    {
        SaveSo.idList = idList;
    }
    void LoadSavedCards()
    {
        for (int i = 0; i < myCards.Count; i++)
        {
            myCards[i].LoadNewCardData(cardSoCollection[SaveSo.idList[i]].cardData);
            myCards[i].LoadCardVisuals();
        }
    }
    private void Start()
    {
        //catch all childrenCards
        GetChildCards();
        

    }


    void GetChildCards()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            myCards.Add(transform.GetChild(i).GetComponent<Card>());
        }
    }

    
    IEnumerator numberCollector(Vector2 range, int count)
    {
        List<int> numberList = new List<int>();
        while (numberList.Count < count)
        {
            bool flag = false;
            int newNum = (int)Random.Range(range.x, range.y);
            foreach(int found in numberList)
            {
                if (found == newNum) flag = true;
            }
            if (!flag) numberList.Add(newNum);
                yield return null;
        }
        idList = numberList;

    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
           StartCoroutine(GetNewCards());
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveCards();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadSavedCards();
        }
    }

    #endregion

}
