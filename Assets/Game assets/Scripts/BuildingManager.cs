using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{

    public GameObject selectedTowerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTowerPrefab(GameObject towerPrefab)
    {
        selectedTowerPrefab = towerPrefab;
    }
}
