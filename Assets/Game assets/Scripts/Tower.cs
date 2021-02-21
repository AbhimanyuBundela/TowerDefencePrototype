using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    Transform topTransform;
    Transform barrelTransform;

    public float range = 10f;
    public GameObject bulletPrefab;

    public int cost = 20;

    public float fireCooldown = 0.5f;
    float fireCooldownLeft = 0f;

    public float damage = 1f;
    public float radius = 0f;

    // Start is called before the first frame update
    void Start()
    {
        topTransform = transform.Find("Top");
        barrelTransform = topTransform.Find("Barrel");
    }

    // Update is called once per frame
    void Update()
    {
        //TODO : Optimize this code
        Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();

        Enemy nearestEnemy = null;
        float dist = Mathf.Infinity;

        foreach (Enemy e in enemies)
        {
            float d = Vector3.Distance(this.transform.position, e.transform.position);
            if(nearestEnemy == null || d < dist)
            {
                nearestEnemy = e;
                dist = d;
            }
        }

        if(nearestEnemy == null)
        {
            //no enemies
            return;
        }

        Vector3 dir = nearestEnemy.transform.position - this.transform.position;

        Quaternion lookRot = Quaternion.LookRotation(dir);

        topTransform.rotation = Quaternion.Euler(0, lookRot.eulerAngles.y, 0);

        fireCooldownLeft -= Time.deltaTime;
        if (fireCooldownLeft <= 0 && dir.magnitude<=range)
        {
            fireCooldownLeft = fireCooldown;
            ShootAt(nearestEnemy);
        }

    }

    void ShootAt(Enemy e)
    {
        //TODO : Fire at the tip
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, barrelTransform.position, barrelTransform.rotation);

        Bullet b = bulletGO.GetComponent<Bullet>();
        b.target = e.transform;

        b.damage = damage;
        b.radius = radius;
    }
}
