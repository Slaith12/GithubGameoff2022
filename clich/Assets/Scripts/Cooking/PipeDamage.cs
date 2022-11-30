using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeDamage : MonoBehaviour
{
    [SerializeField] CookingMinigame minigame;
    [SerializeField] float maxHealth = 20;
    [SerializeField] Transform rock;
    private float health;
    private Vector3 prevPos;

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        prevPos = rock.position;
    }

    private void OnTriggerEnter2D(Collider2D collision) //this is guaranteed to be the rock
    {
        if (!minigame.started)
            return;
        float damage = (rock.position - prevPos).sqrMagnitude;
        Debug.Log($"Damage: {damage}");
        if (damage > maxHealth / 4)
        {
            damage = maxHealth / 4;
            Debug.Log("Damage Cap Exceeded");
        }
        health -= damage;
        if (health <= 0)
            minigame.EndMinigame(true);
    }
}
