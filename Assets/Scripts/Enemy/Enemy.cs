using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(SpriteRenderer), typeof(Animator))]
public class Enemy : MonoBehaviour
{
    public bool verbose;
    EnemySounds es;
    [SerializeField] protected int maxHealth;

    protected int _health;
    public AudioClip deathSound;
    protected SpriteRenderer sr;
    protected Animator anim;
    public AudioMixerGroup soundFXGroup;
    public int health
    {
        get { return _health; }
        set
        {
            _health = value;

            if (_health > maxHealth)
                _health = maxHealth;

            if (_health <= 0)
                Death();
        }
    }

    public virtual void Death()
    {
        es.Play(deathSound, soundFXGroup);
        if (verbose)
            Debug.Log("Can be overriden in child classes to implement their own game over/death");
    }

    public virtual void TakeDamage(int damage)
    {
        health -= damage;
    }

    public virtual void DestroyObj()
    {
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    public virtual void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        es = GetComponent<EnemySounds>();
        if (maxHealth <= 0)
            maxHealth = 10;

        health = maxHealth;
    }
}
