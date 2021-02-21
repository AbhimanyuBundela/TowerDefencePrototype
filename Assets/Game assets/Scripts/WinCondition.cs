using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{

    private int numberOfChilds = 0;
    public int numberOfEnemys = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(numberOfEnemys);

        numberOfChilds = transform.childCount;


        if(numberOfChilds == 0 && numberOfEnemys <= 0)
        {
            numberOfEnemys = 0;
            GameObject.FindObjectOfType<Manager>().LoadNewScene("Win");
        }
        
    }
}
