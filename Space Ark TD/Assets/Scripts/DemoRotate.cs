using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoRotate : MonoBehaviour
{
    Transform par;
    private float ticker;
    float speed = 3;
    float timeToRotate = 1f;
    // Start is called before the first frame update
    void Start()
    {
        par = transform.parent;
        ticker = Random.Range(1, 2);
    }

    // Update is called once per frame
    void Update()
    {
        ticker -= Time.deltaTime;
        if(ticker<0)
        {
            // Rotate cannon
            // Pick a point in the front quadrant and rotate towards it
            Vector3 tpoint = new Vector3(transform.position.x + Random.Range(-0.9f, 0.9f), transform.position.y + 2, 0) - new Vector3(transform.position.x, transform.position.y, 0);

            //  transform.LookAt(tpoint);
            //transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
            StartCoroutine(Rotator(tpoint));
            ticker = Random.Range(timeToRotate + 0.5f, timeToRotate + 1.5f);
        }
    }

    IEnumerator Rotator(Vector3 movementDirection)
    {
        float angle = Mathf.Atan2(movementDirection.x, movementDirection.y) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

        Quaternion targetRotation = Quaternion.LookRotation(movementDirection);
        Quaternion currentRotation = transform.rotation;
        for (float i = 0; i < 1.0f; i += Time.deltaTime / timeToRotate)
        {

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, angle), 10 * Time.deltaTime);
            yield return null;
        }
    }
}
