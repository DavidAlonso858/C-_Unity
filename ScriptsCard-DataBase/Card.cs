using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    CardInfo cardInfo;

    [SerializeField] private TextMeshProUGUI textCardName;
    [SerializeField] private TextMeshProUGUI textCardCost;
    [SerializeField] private Image imageCardImage;
    [SerializeField] private TextMeshProUGUI textCardDescription;
    [SerializeField] private TextMeshProUGUI textCardDamage;
    [SerializeField] private TextMeshProUGUI textCardHealth;

    [SerializeField] private GameObject statsObject, coverObject;


    private void ShowCard()
    {
        textCardName.text = cardInfo.cardName;
        textCardCost.text = cardInfo.cardCost.ToString();
        imageCardImage.sprite = cardInfo.cardImage;
        textCardDescription.text = cardInfo.cardDescription;
        textCardDamage.text = cardInfo.cardDamage.ToString();
        textCardHealth.text = cardInfo.cardHealth.ToString();
        coverObject.SetActive(false);

        if (cardInfo.cardDamage <= 0)
        {
            statsObject.SetActive(false);
        }

    }

    public void SetCardInfo(CardInfo _cardInfo)
    {
        cardInfo = _cardInfo;
        ShowCard();
    }

    // Update is called once per frame
    private void Update()
    {

    }

}
