using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "SharedCard", menuName = "MakeCardType/Shared")]
public class SharedCardType : ScriptableObject
{
    [HideInInspector]public bool isCompleteSetting;  // �ؿ� ������� ������������� �� ���ְ� ������ �ڵ�����
    public string cardName;
    public CardLevel cardLevel; // ī�� ���(Ŀ�� , ���� ����,)
    public CardType cardType; // ī�� Ÿ�� (���� , ��� , ��ų)
    public MonsterType monsterType; // ���� ����ī���ϰ�� � ����ī���� �������� ���� ����
                                    //���� Nonea  �� ��� ���̷��� ����� ��� ����ī��

    public int cost; // �ൿ����Ʈ

    public int attack; // ���ݷ�
    public int defense; // ����
    public int speed; // ���ǵ�� �켱���� �����־ 

    public BuffType cardBuffType;

    public Sprite cardSprite; //�̰� ���� private �� List�� ���� �������ڵ�    
    public string cardManual;
}
