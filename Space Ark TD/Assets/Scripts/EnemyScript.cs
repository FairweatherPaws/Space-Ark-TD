using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private GameObject go;
    private Rigidbody2D rigbod;

    // Start is called before the first frame update
    void Awake()
    {
        go = GetComponent<GameObject>();
        rigbod = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rigbod.velocity.y > -8) { rigbod.gravityScale = 0.3f; }
        else { rigbod.gravityScale = 0; }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("SS");
        float scaleMultiplier = collision.transform.localScale.x;
        float scaleCoefficient = transform.position.x;
        float horizontalForce = 100 * scaleCoefficient / scaleMultiplier;
        rigbod.AddRelativeForce(new Vector2(horizontalForce, horizontalForce));
    }
}
