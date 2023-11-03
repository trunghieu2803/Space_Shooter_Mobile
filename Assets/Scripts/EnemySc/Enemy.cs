using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float headth;
    [SerializeField] protected Rigidbody2D rb;
    void Start()
    {

    }

    public void TakeDamage(float dmg)
    {
        headth -= dmg;
        HurtSequence();
        if(headth <= 0)
        {
            DeathSequence();
        }
    }

     public virtual void HurtSequence()
    {

    }

    public virtual void DeathSequence()
    {

    }

}
