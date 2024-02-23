using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScriptableObject : ScriptableObject
{
    public string cardName, cardSymbol, cardEffect;
    public Sprite cardOutline, cardPicture;
    public bool cardHasEffect;
}
