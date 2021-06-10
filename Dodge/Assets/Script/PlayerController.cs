using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 7f;
    public float screenHalfWidthInWorldUnits;
    public event System.Action OnPlayerDeath;

    private ParticleSystem particle;
    private MeshRenderer mr;
    private BoxCollider2D bc;

    // Start is called before the first frame update
    void Start()
    {
        float halfPlayerWidth = transform.localScale.x/2f;
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize+halfPlayerWidth;
    }

    private void Awake()
    {
        particle = GetComponentInChildren<ParticleSystem>();
        mr = GetComponent<MeshRenderer>();
        bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float velocity = inputX * speed;
        transform.Translate(Vector2.right * velocity*Time.deltaTime);

        if (transform.position.x < -screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(screenHalfWidthInWorldUnits, transform.position.y);
        }
        if (transform.position.x > screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(-screenHalfWidthInWorldUnits, transform.position.y);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Falling Block")
        {
            if (OnPlayerDeath != null)
            {
                OnPlayerDeath();
            }

            StartCoroutine(Break());
            
        }
    }

    private IEnumerator Break()
    {
        particle.Play();

        bc.enabled = false;
        mr.enabled = false;
        yield return new WaitForSeconds(particle.main.startLifetime.constantMax);
        Destroy(gameObject);
    }
    
    
}
