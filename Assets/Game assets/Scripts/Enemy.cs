using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    GameObject pathGO;

    Transform targetPathNode;
    int pathNodeIndex = 0;

    public float speed = 5f;

    public float health = 1f;

    public int moneyValue = 1;

    // Start is called before the first frame update
    void Start()
    {
        pathGO = GameObject.Find("Path");
    }

    void GetNextPathNode()
    {
        if (pathNodeIndex < pathGO.transform.childCount)
        {
            targetPathNode = pathGO.transform.GetChild(pathNodeIndex);
            pathNodeIndex++;
        }
        else
        {
            targetPathNode = null;
            ReachedGoal();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
         if(targetPathNode == null)
         {
             GetNextPathNode();
             if(targetPathNode == null)
             {
                 // Run out of path!
                 ReachedGoal();
                return;
             }
         }

         Vector3 dir = targetPathNode.position - this.transform.localPosition;

         float distThisFrame = speed * Time.deltaTime;

         if(dir.magnitude <= distThisFrame)
         {
             //Reached Node
             targetPathNode = null;
         }
         else
         {
             //TODO : Make the movement smooth pathNodeIndex <= pathGO.transform.childCount
             //Move towards node
             transform.Translate(dir.normalized * distThisFrame, Space.World);
             Quaternion targetRotation = Quaternion.LookRotation(dir);
             this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, Time.deltaTime* 5);
         }
    }

    void ReachedGoal()
    {
        GameObject.FindObjectOfType<ScoreManager>().LoseLife();
        GameObject.FindObjectOfType<WinCondition>().numberOfEnemys--;
        Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            GameObject.FindObjectOfType<WinCondition>().numberOfEnemys--;
            Die();
        }
    }

    void Die()
    {
        GameObject.FindObjectOfType<ScoreManager>().money += moneyValue;
        Destroy(gameObject);
    }
}
