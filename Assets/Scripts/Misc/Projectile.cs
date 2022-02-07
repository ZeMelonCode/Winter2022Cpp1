using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifetime;

    // Start is called before the first frame update
    void Start()
    {
        if (lifetime <= 0)
            lifetime = 2.0f;

        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        Destroy(gameObject, lifetime);
    }

    private void OnCollisionEnter(Collision other) {
        if(other.collider.tag != "Player" && other.collider.tag != "Powerup" && other.collider.tag != "Collectable" ){
            Destroy(gameObject);
        }
    }
}
