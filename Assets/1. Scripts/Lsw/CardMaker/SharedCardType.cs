using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "SharedCard", menuName = "MakeCardType/Shared")]
public class SharedCardType : ScriptableObject
{
    [HideInInspector]public bool isCompleteSetting;  // 밑에 변수들다 세팅해줘야지만 할 수있게 에디터 코딩예정
    public string cardName;
    public CardLevel cardLevel; // 카드 등급(커먼 , 레어 유닠,)
    public CardType cardType; // 카드 타입 (공격 , 방어 , 스킬)
    public MonsterType monsterType; // 만약 몬스터카드일경우 어떤 몬스터카드의 전용인지 선택 가능
                                    //만약 Nonea  면 고블린 스켈레톤 좀비들 모두 공용카드

    public int cost; // 행동포인트

    public int attack; // 공격력
    public int defense; // 방어력
    public int speed; // 스피드로 우선순위 결정넣어봄 

    public BuffType cardBuffType;

    public Sprite cardSprite; //이건 추후 private 및 List로 만들어서 에디터코딩    
    public string cardManual;
}
