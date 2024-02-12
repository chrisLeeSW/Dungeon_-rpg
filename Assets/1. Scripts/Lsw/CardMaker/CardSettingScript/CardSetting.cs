using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSetting : MonoBehaviour
{
    public SharedCardType cardType;
    public float cardSize = 150f;

    public List<Sprite> cardBackGroundSprite = new List<Sprite>();
    public Sprite cardCostSprite; // cardSize /3 ?
    public void TestPrintCode()
    {
        Debug.Log("Test");
    }
}
