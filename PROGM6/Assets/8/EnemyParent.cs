using UnityEngine;

public class EnemyParent : MonoBehaviour
{
    public float speed = 5f;     
    public int health = 3;     
    public float range = 100f;

    private Vector3 startPosition;
    private bool moveRight = true;

    protected void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (health > 0)
        {
            MoveEnemy();
        }
    }

    protected void MoveEnemy()
    {
        float maxOffset = range / 2;
        if (moveRight)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            if (transform.position.x > startPosition.x + maxOffset)
                moveRight = false;
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            if (transform.position.x < startPosition.x - maxOffset)
                moveRight = true;
        }
    }


    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy is destroyed!");
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Projectile"))
        {
            TakeDamage(1);
            Destroy(collision.gameObject);
        }
    }
}
