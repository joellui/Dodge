using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    public Vector2 speedMinMax;
    float speed;

    private float visibleHightThreshold;
    // Start is called before the first frame update
    void Start()
    {
        speed = Mathf.Lerp(speedMinMax.x,speedMinMax.y,Difficulty.GetDifficultyPercentage());

        visibleHightThreshold = -Camera.main.orthographicSize - transform.localScale.y;

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down*speed*Time.deltaTime);

        if (transform.position.y < visibleHightThreshold )
        {
            Destroy(gameObject);
        }
    }
}
