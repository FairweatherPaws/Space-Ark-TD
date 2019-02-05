using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour

{

    public int dakka, rateOfFire, reloadRate, leftAngle, rightAngle, pelletDurability, pelletCount;
    private float fireTimer, firingAngle;
    public float pelletCooldown;
    private int shotNumber;
    public GameObject pellet;

    // Start is called before the first frame update
    void Start()
    {
        fireTimer = pelletCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        fireTimer -= Time.deltaTime * rateOfFire;
        if (fireTimer < 0)
        {
            fireTimer = pelletCooldown;
           
            GameObject newPellet = Instantiate(pellet, transform.position, Quaternion.identity);
            firingAngle = leftAngle + shotNumber * (rightAngle - leftAngle) / pelletCount + Random.Range(-1f, 1f);
            if (shotNumber == pelletCount)
            {
                shotNumber = -1;
                fireTimer = reloadRate;
            }
            shotNumber++;
            newPellet.GetComponent<Rigidbody2D>().AddForce(new Vector2(firingAngle, (50 - Mathf.Abs(firingAngle)) / 3));
            newPellet.GetComponent<PelletScript>().damage = dakka;
            newPellet.GetComponent<PelletScript>().durability = pelletDurability;
        }
    }
}
