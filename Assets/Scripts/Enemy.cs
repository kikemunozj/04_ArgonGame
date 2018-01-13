using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;

    [SerializeField] int scorePerHit = 12;


    ScoreBoard scoreBoard;


    private void Start()
    {
        AddCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();

    }

    private void AddCollider()
    {
        Collider enemyCollider = gameObject.AddComponent<BoxCollider>();
        enemyCollider.isTrigger = false;

    }

    void OnParticleCollision(GameObject other)
    {
        scoreBoard.ScoreHit(scorePerHit);
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        EnemyDeath();
    }

    private void EnemyDeath()
    {
      
        Destroy(gameObject);
    }
}