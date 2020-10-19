using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{    
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    [SerializeField] int scoreWhenKilled = 15;

    [SerializeField] int remainingHits = 10;

    ScoreBoard scoreBoard;
    // Start is called before the first frame update
    void Start()
    {
        AddNonTriggerBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddNonTriggerBoxCollider()
    {
        Collider enemyBoxCollider = gameObject.AddComponent<BoxCollider>();
        enemyBoxCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        scoreBoard.ScoreHit(scoreWhenKilled);
        remainingHits--;
        if (remainingHits <= 0)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;


        Destroy(gameObject);
    }
}
