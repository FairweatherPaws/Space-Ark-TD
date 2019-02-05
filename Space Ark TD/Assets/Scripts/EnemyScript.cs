using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private GameObject go;
    private Rigidbody2D rigbod;
    public int hitpoints, maxHitpoints;
    public GameObject healthBar, gameController;

    // Start is called before the first frame update
    void Awake()
    {
        maxHitpoints = 5 + (int)((Random.Range(5, 15)));
        hitpoints = maxHitpoints;
        go = GetComponent<GameObject>();
        rigbod = GetComponent<Rigidbody2D>();
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        if (rigbod.velocity.y > -1) { rigbod.gravityScale = 0.01f; }
        else { rigbod.gravityScale = 0; }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int newHitpoints = hitpoints;
        float scaleMultiplier = collision.transform.localScale.x;
        float scaleCoefficient = transform.position.x;
        float horizontalForce = 100 * scaleCoefficient / scaleMultiplier;
        
        if (collision.gameObject.tag == "Paddle") { hitpoints -= 3; ChangeBar(); rigbod.AddRelativeForce(new Vector2(horizontalForce, 3*horizontalForce)); }
        if (collision.gameObject.tag == "Wall") { hitpoints -= 1; ChangeBar(); rigbod.AddRelativeForce(new Vector2(-horizontalForce, 0)); }

    }

    private void ChangeBar()
    {
        Vector3 v = healthBar.transform.localScale;
        healthBar.transform.localScale = new Vector3((float)hitpoints / (float)maxHitpoints, v.y, v.z);
        healthBar.GetComponent<SpriteRenderer>().color = new Color((maxHitpoints - hitpoints) * (255/maxHitpoints), hitpoints * (255 / maxHitpoints), 0);
        if (hitpoints < 1) { Destroy(this.gameObject); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "End Zone") { gameController.GetComponent<GameController>().triggerLoss(); }
    }
}
