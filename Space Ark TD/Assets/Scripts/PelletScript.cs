﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletScript : MonoBehaviour
{

    public int damage, durability;
    private bool ignoreCheck;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!ignoreCheck)
        {
            if (transform.position.y > -6.5) {
                ignoreCheck = true;
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
        if (Mathf.Abs(transform.position.x) > 7 || Mathf.Abs(transform.position.y) > 12) { Destroy(this.gameObject); }
   }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float scaleMultiplier = collision.transform.localScale.x;
        float scaleCoefficient = transform.position.x;
        float horizontalForce = 100 * (scaleCoefficient - scaleMultiplier);
        durability--;
        if (collision.gameObject.tag == "Paddle") { GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0.4f*horizontalForce, 0.2f * horizontalForce)); }
        if (durability < 1) { Destroy(this.gameObject); }
    }
}
