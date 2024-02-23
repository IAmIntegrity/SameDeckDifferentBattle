using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<CardScriptableObject> allCardsList = new List<CardScriptableObject>();

    [SerializeField] private GameObject playerHandObject, monsterPrefab, spellTrapPrefab;
    private int cardDistancing = 150, cardOffset = 300;

    private void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject cardClone;
            CardScriptableObject randCard = allCardsList.ToArray()[Random.Range(0, allCardsList.Count)];

            if (randCard.cardSymbol == "Spell" || randCard.cardSymbol == "Trap")
            {
                cardClone = Instantiate(spellTrapPrefab, new Vector3((playerHandObject.transform.position.x - cardOffset) + (cardDistancing * i), playerHandObject.transform.position.y, playerHandObject.transform.position.z), Quaternion.identity);
                cardClone.GetComponent<SpellTrapCardDisplay>().card = (SpellTrapScriptableObject)randCard;
                cardClone.name = randCard.cardName;
            }
            else
            {
                cardClone = Instantiate(monsterPrefab, new Vector3((playerHandObject.transform.position.x - cardOffset) + (cardDistancing * i), playerHandObject.transform.position.y, playerHandObject.transform.position.z), Quaternion.identity);
                cardClone.GetComponent<MonsterCardDisplay>().card = (MonsterScriptableObject)randCard;
                cardClone.name = randCard.cardName;
            }
            cardClone.transform.SetParent(playerHandObject.transform);
        }
    }
}
