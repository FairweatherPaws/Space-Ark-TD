using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour

{

    public int dakka, rateOfFire, leftAngle, rightAngle, pelletDurability;
    private float fireTimer;
    public GameObject pellet;

    // Start is called before the first frame update
    void Start()
    {
        fireTimer = 2;
    }

    // Update is called once per frame
    void Update()
    {
        fireTimer -= Time.deltaTime * rateOfFire;
        if (fireTimer < 0)
        {
            fireTimer = 2;
            GameObject newPellet = Instantiate(pellet, transform.position, Quaternion.identity);
            float firingAngle = Random.Range(leftAngle, rightAngle);
            
            newPellet.GetComponent<Rigidbody2D>().AddForce(new Vector2(firingAngle, (50 - Mathf.Abs(firingAngle)) / 3));
            newPellet.GetComponent<PelletScript>().damage = dakka;
            newPellet.GetComponent<PelletScript>().durability = pelletDurability;
        }
    }
}
