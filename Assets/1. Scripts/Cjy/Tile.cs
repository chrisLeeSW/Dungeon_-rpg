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

    //마우스 올리면 타일이 빨간색, 내리면 이전 상태로 변경
    private void OnMouseEnter()
    {
        transform.GetComponent<Renderer>().material.color = Color.red;
    }
    private void OnMouseExit()
    {
        transform.GetComponent<Renderer>().material.color = Color.white;
    }
    //마우스 클릭 시 Player의 목표 지점을 클릭한 타일의 위치로 변경, y축은 고려 안 했음
    private void OnMouseDown()
    {
        PlayerMove.instance.DesPoint.x = transform.position.x;
        PlayerMove.instance.DesPoint.z = transform.position.z;
        Debug.Log(PlayerMove.instance.DesPoint);
    }
}
