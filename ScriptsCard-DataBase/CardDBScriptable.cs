using System;
using System.Collections.Generic;
using UnityEngine;

// nombre de la base de datos con su ruta
[CreateAssetMenu(fileName = "CardDB", menuName = "Database/CardDB", order = 0)]
public class CardDBScriptable : ScriptableObject
{
    public enum Effect { None, Damage, Heal, IncreaseDamage, IncreaseHealth }
    public enum EffectTarget { player, enemy, playerCard, enemyCard, allPlayerCard, allEnemyCard }
    [SerializeField] List<CardInfo> cardList;

    public CardInfo GetRandomCard()
    {
        // uso la biblioteca de UnityEngine y no la de System para devolver una carta
        // aleatoria entre 0 y el maximo que tiene la lista de cartas
        return cardList[UnityEngine.Random.Range(0, cardList.Count)];
    }
}

[Serializable]
public class CardInfo
{
    public string cardName;
    public int cardCost;

    public Sprite cardImage;

    public string cardDescription;
    public int cardDamage;
    public int cardHealth;

    public CardDBScriptable.Effect enumEffect;
    public int effectAmount;
    public CardDBScriptable.EffectTarget effectTarget;

}

