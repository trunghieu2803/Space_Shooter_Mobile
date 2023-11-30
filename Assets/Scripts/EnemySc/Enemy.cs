using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float headth;
    [SerializeField] protected Rigidbody2D rb;

    [SerializeField] protected float damage;
    [SerializeField] protected GameObject explosionPrefab;

    [SerializeField] protected Animator anim;
    [Header("Score"), SerializeField]
    protected int scoreValue;
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
        EndGameManager.endManager.UpdateScore(scoreValue);
    }

}
