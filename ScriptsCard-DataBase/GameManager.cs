using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] CardDBScriptable cardDB;
    [SerializeField] GameObject cardObject;
    [SerializeField] Transform cardBox;

    void Awake()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(cardObject, cardBox).GetComponent<Card>().SetCardInfo(cardDB.GetRandomCard());

        }
    }

    void Update()
    {

    }
}
