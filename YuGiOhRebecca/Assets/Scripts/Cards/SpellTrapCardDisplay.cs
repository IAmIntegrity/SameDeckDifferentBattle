using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SpellTrapCardDisplay : MonoBehaviour
{
    public SpellTrapScriptableObject card;

    [SerializeField] private TMP_Text cardNameText, cardSymbolText, cardEffectText, spellTrapTypeText;
    [SerializeField] private Image cardOutlineImage, cardPictureImage;
    [SerializeField] private GameObject spellTrapPrefab;

    private Vector3 selectedCardVector3 = new Vector3(-700, 0, 0), selectedCardFloat = new Vector3(0.7f, 0.7f, 0.7f);

    private void Start()
    {
        cardNameText.text = card.cardName;
        cardSymbolText.text = card.cardSymbol;
        cardEffectText.text = card.cardEffect;
        spellTrapTypeText.text = $"[{card.spellTrapType}]";
        cardOutlineImage.sprite = card.cardOutline;
        cardPictureImage.sprite = card.cardPicture;
    }

    public void CardSelected()
    {

        if (GameObject.Find("SelectedCard"))
        {
            Destroy(GameObject.Find("SelectedCard"));
        }

        GameObject spellTrapClone = Instantiate(spellTrapPrefab, GameObject.Find("Canvas").transform);
        spellTrapClone.transform.localPosition = selectedCardVector3;
        spellTrapClone.transform.localScale = selectedCardFloat;
        Destroy(spellTrapClone.GetComponent<Button>());
        Destroy(spellTrapClone.transform.GetChild(6).gameObject);
        spellTrapClone.GetComponent<SpellTrapCardDisplay>().card = card;
        spellTrapClone.name = "SelectedCard";
    }
}
