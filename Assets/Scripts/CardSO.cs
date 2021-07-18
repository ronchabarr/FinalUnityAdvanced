using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "ScriptAbleObjects/Card")]
public class CardSO : ScriptableObject
{
    public CardData cardData;
}
[System.Serializable]
public class CardData
{
    #region GetSet

     public int GetId { get { return id; } }
     public string GetSetName { get { return name; } set { name = value; } }
     public int GetSetPower { get { return power; } set { power = value; } }
     public Sprite GetSetSprite { get { return sprite; } set { sprite = value; } }
     public string GetSetDescription { get { return desctiption; } set { desctiption = value; } }

    #endregion


    #region Inspector

    [SerializeField] private int id;
    [SerializeField] private string name;
    [SerializeField] private int power;
    [SerializeField] private Sprite sprite;
    [SerializeField] private string desctiption;

    #endregion

    #region Constructors

    public CardData(string newName,int newPower,Sprite newSprite,string newDescription,int newId)
    {
        id = newId;

        name = newName;

        power = newPower;

        sprite = newSprite;

        desctiption = newDescription;

    }

    public CardData(CardData originCard)
    {
        id = originCard.id;
         
        name = originCard.GetSetName;

        power = originCard.GetSetPower;

        sprite = originCard.GetSetSprite;

        desctiption = originCard.desctiption;

    }

    #endregion




}
