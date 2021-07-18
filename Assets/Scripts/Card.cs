using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Card : MonoBehaviour
{
    #region Inspector
    [Header("DataSource")]
    [Space]
    [Space]
    [SerializeField] private CardData cardData;
    
    [Header("Components")]
    [SerializeField] private Image backgroundImage;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI powerText;
    [SerializeField] private TextMeshProUGUI desctiptionText;
    #endregion



    #region ClassData



    #endregion

    #region Interface

    public void LoadCardVisuals()
    {
        LoadVisuals();
    }
    public void LoadNewCardData(CardData newCardData) => MakeNewCard(newCardData);
   
    #endregion

    #region Process

    void LoadVisuals()
    {
        backgroundImage.sprite = cardData.GetSetSprite;
        nameText.text = cardData.GetSetName;
        powerText.text = cardData.GetSetPower.ToString();
        desctiptionText.text = cardData.GetSetDescription;
    }

    void MakeNewCard(CardData newCardData)
    {
        cardData = new CardData(newCardData);
    }
    
    #endregion

}
