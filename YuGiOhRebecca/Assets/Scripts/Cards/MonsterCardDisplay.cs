using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MonsterCardDisplay : MonoBehaviour
{
    public MonsterScriptableObject card;

    [SerializeField] private TMP_Text cardNameText, cardSymbolText, cardEffectText, monsterTypeText, monsterLevelText, monsterAttackText, monsterDefenseText;
    [SerializeField] private Image cardOutlineImage, cardPictureImage;
    [SerializeField] private GameObject monsterPrefab;

    private Vector3 selectedCardVector3 = new Vector3(-700, 0, 0), selectedCardFloat = new Vector3(0.7f, 0.7f, 0.7f);

    private void Start()
    {
        cardNameText.text = card.cardName;
        cardSymbolText.text = card.cardSymbol;
        cardEffectText.text = card.cardEffect;
        if (card.cardHasEffect)
        {
            monsterTypeText.text = $"[{card.monsterType}/Effect]";
        }
        else
        {
            monsterTypeText.text = $"[{card.monsterType}]";
        }
        monsterLevelText.text = $"Level: {card.monsterLevel}";
        monsterAttackText.text = $"ATK/ {card.monsterAttack}";
        monsterDefenseText.text = $"DEF/ {card.monsterDefense}";
        cardOutlineImage.sprite = card.cardOutline;
        cardPictureImage.sprite = card.cardPicture;
    }

    public void CardSelected()
    {
        if (GameObject.Find("SelectedCard"))
        {
            Destroy(GameObject.Find("SelectedCard"));
        }

        GameObject monsterClone = Instantiate(monsterPrefab, GameObject.Find("Canvas").transform);
        monsterClone.transform.localPosition = selectedCardVector3;
        monsterClone.transform.localScale = selectedCardFloat;
        Destroy(monsterClone.GetComponent<Button>());
        Destroy(monsterClone.transform.GetChild(9).gameObject);
        monsterClone.GetComponent<MonsterCardDisplay>().card = card;
        monsterClone.name = "SelectedCard";
    }
}
