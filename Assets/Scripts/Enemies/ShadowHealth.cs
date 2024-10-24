using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowHealth : MonoBehaviour
{
    public int shadowHealth = 1000;

    public void TakeDamage()
    {
        shadowHealth -= 1;
    }

    private void Update()
    {
        if (shadowHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}

