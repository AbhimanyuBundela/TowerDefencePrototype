using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpot : MonoBehaviour
{

    void OnMouseUp()
    {
        Debug.Log("TowerSpot Clicked");

        BuildingManager bm = GameObject.FindObjectOfType<BuildingManager>();
        if(bm.selectedTowerPrefab != null)
        {
            ScoreManager sm = GameObject.FindObjectOfType<ScoreManager>();
            if(sm.money < bm.selectedTowerPrefab.GetComponent<Tower>().cost)
            {
                Debug.Log("Not enough money");
                return;
            }

            sm.money -= bm.selectedTowerPrefab.GetComponent<Tower>().cost;

            Instantiate(bm.selectedTowerPrefab, transform.parent.position, transform.parent.rotation);
            Destroy(transform.parent.gameObject);
        }
    }

}
