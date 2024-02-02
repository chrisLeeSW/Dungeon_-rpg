using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //���콺 �ø��� Ÿ���� ������, ������ ���� ���·� ����
    private void OnMouseEnter()
    {
        transform.GetComponent<Renderer>().material.color = Color.red;
    }
    private void OnMouseExit()
    {
        transform.GetComponent<Renderer>().material.color = Color.white;
    }
    //���콺 Ŭ�� �� Player�� ��ǥ ������ Ŭ���� Ÿ���� ��ġ�� ����, y���� ��� �� ����
    private void OnMouseDown()
    {
        PlayerMove.instance.DesPoint.x = transform.position.x;
        PlayerMove.instance.DesPoint.z = transform.position.z;
        Debug.Log(PlayerMove.instance.DesPoint);
    }
}
