using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBreak : MonoBehaviour
{
    private ParticleSystem particle;
    private SpriteRenderer sr;
    private BoxCollider2D bc;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        //StartCoroutine(Break());

    }

    private IEnumerable Break()
    {
        

        yield return new WaitForSeconds(particle.main.startLifetime.constantMax);
        Destroy(gameObject);
    }
}
