using UnityEngine;

public class Elf : EnemyParent
{
    private MeshRenderer objectRenderer;

    void Start()
    {
        base.Start();

        health = 3;
        speed = 5f;
        range = 100f;
        objectRenderer = GetComponent<MeshRenderer>();
        StartCoroutine(ToggleVisibility());
    }

    void Update()
    {
        if (health > 0)
        {
            MoveEnemy();
        }
    }
    private System.Collections.IEnumerator ToggleVisibility()
    {
        while (health > 0) 
        {
            yield return new WaitForSeconds(3f);
            objectRenderer.enabled = false;
            yield return new WaitForSeconds(0.5f);
            objectRenderer.enabled = true;
        }
    }
}

    
