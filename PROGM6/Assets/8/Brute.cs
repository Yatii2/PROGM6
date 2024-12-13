using UnityEngine;

public class Brute : EnemyParent
{
    
    void Start()
    {
        base.Start();

        health = 10;
        speed = 2f;
        range = 100f;
    }

    void Update()
    {
        if (health > 0)
        {
            MoveEnemy();
        }
    }
}
