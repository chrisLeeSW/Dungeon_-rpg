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
        //타일 깔기 위한 2중 for문
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                //타일 5x5 복제
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
