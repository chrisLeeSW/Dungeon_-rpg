using System;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[CustomEditor(typeof(CardSetting))]
public class CardSettingEdtior : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        CardSetting cardsetting = (CardSetting)target;
        if(cardsetting.cardType == null)
        {
            EditorGUILayout.HelpBox("카드 세팅이 없습니다.", MessageType.Error);
        }
        else
        {
            if(cardsetting.cardBackGroundSprite.Count ==0)
            {
                EditorGUILayout.HelpBox("카드 배경이미지를 넣어주세요", MessageType.Error);
            }
            else if (GUILayout.Button("Make Card"))
            {
                var panel = cardsetting.GetComponent<RectTransform>();
                panel.anchorMin = new Vector2(0.5f, 0.5f);
                panel.anchorMax = new Vector2(0.5f, 0.5f);
                panel.sizeDelta = new Vector2(cardsetting.cardSize, cardsetting.cardSize *2 );

                if(panel.childCount == 0)
                {
                    var cardBackGround = new GameObject("CardBackGround");
                    cardBackGround.transform.SetParent(panel, false);  // 원하는 부모 RectTransform에 추가

                    CardBackGroundSetting(cardsetting , cardBackGround);

                    var cardName = new GameObject("CardNamePanel");
                    cardName.transform.SetParent(cardBackGround.transform, false);

                    CardNameSetting(cardsetting, cardName);

                    var cardCost = new GameObject("CardCostSprite");
                    cardCost.transform.SetParent(cardBackGround.transform, false);

                    CardCostSetting(cardsetting, cardCost);

                    var cardMainImage = new GameObject("CardMainImage");
                    cardMainImage.transform.SetParent(cardBackGround.transform, false);
                    CardMainImageSetting(cardsetting, cardMainImage);

                    var cardManual = new GameObject("CardManualText");
                    cardManual.transform.SetParent(cardBackGround.transform, false);
                    CardManualTextSetting(cardsetting, cardManual);
                }


                cardsetting.TestPrintCode();
            }
        }
    }


    private void CardBackGroundSetting(CardSetting cardsetting,GameObject obj)
    {
        var uiImageRect = obj.AddComponent<RectTransform>();
        uiImageRect.sizeDelta = new Vector2(cardsetting.cardSize, cardsetting.cardSize * 2);

        Image uiImage = obj.AddComponent<Image>();
        switch (cardsetting.cardType.cardLevel)
        {
            case CardLevel.Common:
                uiImage.sprite = cardsetting.cardBackGroundSprite[(int)CardLevel.Common];
                break;
            case CardLevel.Rare:
                uiImage.sprite = cardsetting.cardBackGroundSprite[(int)CardLevel.Rare];
                break;
            case CardLevel.Unique:
                uiImage.sprite = cardsetting.cardBackGroundSprite[(int)CardLevel.Unique];
                break;
        }
    }

    private void CardNameSetting(CardSetting cardsetting, GameObject cardName)
    {
        var cardNameAnchor = cardName.AddComponent<RectTransform>();

        cardNameAnchor.anchorMin = new Vector2(0.5f, 1f);
        cardNameAnchor.anchorMax = new Vector2(0.5f, 1f);
        cardNameAnchor.sizeDelta = new Vector2(cardsetting.cardSize / 2, cardsetting.cardSize / 10);
        cardNameAnchor.localPosition = new Vector3(0f, cardsetting.cardSize - (cardNameAnchor.sizeDelta.y/2), 0f);

        var canvasCardRender = cardName.AddComponent<CanvasRenderer>();
        canvasCardRender.cullTransparentMesh = true;

        var canvasUiImage = cardName.AddComponent<Image>();
        //canvasUiImage.sprite = cardsetting.cardType.cardSprite; // 나중에 다른 제목 백그라운드 코드 설정 해야함
        canvasUiImage.maskable = true;

        var textName = new GameObject("CardNameText");
        textName.transform.SetParent(cardName.transform, false);

        var textSize = textName.AddComponent<RectTransform>();
        textSize.sizeDelta = cardNameAnchor.sizeDelta;
        textSize.anchorMin = new Vector2(0.5f, 0.5f);
        textSize.anchorMax = new Vector2(0.5f, 0.5f);

        var textCanvasRensder = textName.AddComponent<CanvasRenderer>();
        textCanvasRensder.cullTransparentMesh = true;

       

        var textMeshProUGUI = textName.AddComponent<TextMeshProUGUI>();
        textMeshProUGUI.text = cardsetting.cardType.cardName;
        //textMeshProUGUI.font =   // font 결정되면 사용
        textMeshProUGUI.fontSize = 15f;
        textMeshProUGUI.alignment = TextAlignmentOptions.Center;
        textMeshProUGUI.color = Color.red;
    }

    private void CardCostSetting(CardSetting cardsetting, GameObject cardCost)
    {
        var cardCostSize = cardCost.AddComponent<RectTransform>();
        cardCostSize.anchorMin = new Vector2(1f, 1f);
        cardCostSize.anchorMax = new Vector2(1f, 1f);
        float cardCostScale = cardsetting.cardSize / 3; 
        cardCostSize.sizeDelta = new Vector2(cardCostScale, cardCostScale);



        var cardCostRender= cardCost.AddComponent<CanvasRenderer>();
        cardCostRender.cullTransparentMesh= true;

        var cardCostImage = cardCost.AddComponent<Image>();
        cardCostImage.raycastTarget = false;
        cardCostImage.sprite = cardsetting.cardCostSprite;


        var cardCostText = new GameObject("CardCost");
        cardCostText.transform.SetParent(cardCost.transform, false);
        var cardCostTextTransform = cardCostText.AddComponent<RectTransform>();

        cardCostTextTransform.sizeDelta = new Vector2(cardCostScale,cardCostScale);
        cardCostTextTransform.anchorMax = new Vector2(0.5f, 0.5f);
        cardCostTextTransform.anchorMin = new Vector2(0.5f, 0.5f);

        var cardCostTextRende = cardCostText.AddComponent<CanvasRenderer>();
        cardCostTextRende.cullTransparentMesh= true;


        var cardCostTextMeshProUGUI = cardCostText.AddComponent<TextMeshProUGUI>();
        cardCostTextMeshProUGUI.text = $"{cardsetting.cardType.cost}";
        // cardCostTextMeshProUGUI.font = 
        cardCostTextMeshProUGUI.fontSize = 30f;
        cardCostTextMeshProUGUI.alignment = TextAlignmentOptions.Center;
        cardCostTextMeshProUGUI.color = Color.red;
    }
    private void CardMainImageSetting(CardSetting cardSetting , GameObject cardMainImage)
    {
        var cardMainImagePosistion = cardMainImage.AddComponent<RectTransform>();
        cardMainImagePosistion.sizeDelta = new Vector2(cardSetting.cardSize * 0.8f, cardSetting.cardSize);
        cardMainImagePosistion.localPosition = new Vector3(0f, cardMainImagePosistion.sizeDelta.y /6 , 0f);

        var cardMainImageCanvasRender = cardMainImage.AddComponent<CanvasRenderer>();
        cardMainImageCanvasRender.cullTransparentMesh = true;

        var cardMainImageSprite = cardMainImage.AddComponent<Image>();
        cardMainImageSprite.raycastTarget= false;
        cardMainImageSprite.sprite = cardSetting.cardType.cardSprite;
    }
    
    private void CardManualTextSetting(CardSetting cardSetting , GameObject cardManualText)
    {
        var cardManulTextRectTransform = cardManualText.AddComponent<RectTransform>();
        cardManulTextRectTransform.sizeDelta = new Vector2(cardSetting.cardSize * 0.6f, cardSetting.cardSize * 0.3f);
        cardManulTextRectTransform.localPosition = new Vector3(0f, cardSetting.cardSize * 0.6f * -1f, 0f);

        var cardManulTextMeshProUGUI = cardManualText.AddComponent<TextMeshProUGUI>();
        // cardManulTextMeshProUGUI.font =
        cardManulTextMeshProUGUI.color = Color.red;
        cardManulTextMeshProUGUI.text = cardSetting.cardType.cardManual;
        cardManulTextMeshProUGUI.alignment = TextAlignmentOptions.Center;
        cardManulTextMeshProUGUI.fontSize = 15f;
    }
}
