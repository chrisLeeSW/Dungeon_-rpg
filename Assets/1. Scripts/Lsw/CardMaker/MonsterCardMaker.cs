using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterCard", menuName = "MakeCardType/Monster")]
public class MonsterCardMaker : SharedCardType
{
    public MonsterType monsterType; // 만약 몬스터카드일경우 어떤 몬스터카드의 전용인지 선택 가능
                                    //만약 Nonea  면 고블린 스켈레톤 좀비들 모두 공용카드
}
