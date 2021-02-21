using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    float spawnCD = 0.2f;
    float spawnCDremaining = 5f;

    [System.Serializable]
    public class WaveComponent
    {
        public GameObject enemyPrefab;
        public int num;
        [System.NonSerialized]
        public int spawned = 0;
    }

    public WaveComponent[] waveComps;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        

        spawnCDremaining -= Time.deltaTime;
        if (spawnCDremaining < 0)
        {
            spawnCDremaining = spawnCD;

            bool didSpawn = false;

            //Go through the wave components untill we find something to spawn
            foreach(WaveComponent wc in waveComps)
            {
                if(wc.spawned < wc.num)
                {
                    GameObject.FindObjectOfType<WinCondition>().numberOfEnemys++;
                    //spawn
                    wc.spawned++;
                    Instantiate(wc.enemyPrefab, this.transform.position, this.transform.rotation);

                    didSpawn = true;
                    break;

                }
            }

            if(didSpawn == false)
            {

                if(transform.parent.childCount > 1)
                {
                    transform.parent.GetChild(1).gameObject.SetActive(true);
                }
                else
                {

                }

                //Wave Complete
                //TODO: Spawn another Wave
                Destroy(gameObject);
            }

        }

    }
}
