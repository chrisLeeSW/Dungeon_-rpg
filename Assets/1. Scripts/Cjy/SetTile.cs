using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetTile : MonoBehaviour
{
    public GameObject Prefab;
    // Start is called before the first frame update
    void Start()
    {
        //Ÿ�� ��� ���� 2�� for��
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                //Ÿ�� 5x5 ����
                GameObject newTile = Instantiate(Prefab);
                newTile.transform.position = new Vector3(j, 0, i);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
