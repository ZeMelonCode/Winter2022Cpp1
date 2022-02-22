using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : Enemy
{
    [SerializeField] float projectileForce;
    [SerializeField] float projectileFireRate;
    [SerializeField] float range ;

    float timeSinceLastFire;

    public Transform projectileSpawnPointRight;
    public Transform projectileSpawnPointLeft;

    public Projectile projectilePrefab;
    public bool flipped ;
    private bool withinRange = false;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        if (projectileForce <= 0)
            projectileForce = 7.0f;

        if (projectileFireRate <= 0)
            projectileFireRate = 2.0f;

        if (range <= 0)
            range = 5f;

        if (!projectilePrefab)
        {
            if (verbose)
                Debug.Log("Projectile Prefab has not be set on " + name);
        }
        if (!projectileSpawnPointRight)
        {
            if (verbose)
                Debug.Log("Projectile Spawn Point Right has not be set on " + name);
        }
        if (!projectileSpawnPointLeft)
        {
            if (verbose)
                Debug.Log("Projectile Spawn Point Left has not be set on " + name);
        }
    }

    public override void Death()
    {
        base.Death();
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Player").transform.position.x >= (transform.position.x - range) && GameObject.Find("Player").transform.position.x <= (transform.position.x + range))
        {
            withinRange = true;
        }
        else
        {
            withinRange = false;
        }
        if (!anim.GetBool("Fire") && withinRange)
        {
                if (Time.time >= timeSinceLastFire + projectileFireRate)
                {
                    anim.SetBool("Fire", true);
                }    
        }
        if(GameObject.Find("Player").transform.position.x > transform.position.x && flipped && (GameObject.Find("Player").transform.position.x - transform.position.x) <= range)
        {
            flipped = false;
            sr.flipX = !sr.flipX;
        }
        if(GameObject.Find("Player").transform.position.x < transform.position.x && !flipped && (transform.position.x - GameObject.Find("Player").transform.position.x) <= range)
        {
            flipped = true;
            sr.flipX = !sr.flipX;
        }
        
    }

    public void Fire()
    {
            timeSinceLastFire = Time.time;
            if(!flipped)
            {
                Projectile temp = Instantiate(projectilePrefab, projectileSpawnPointRight.position, projectileSpawnPointRight.rotation);
                temp.speed = projectileForce;
            }
            if(flipped)
            {
                Projectile temp = Instantiate(projectilePrefab, projectileSpawnPointLeft.position, projectileSpawnPointLeft.rotation);
                temp.speed = -projectileForce;
            }
    }

    public void ReturnToIdle()
    {
        anim.SetBool("Fire", false);
    }
}
