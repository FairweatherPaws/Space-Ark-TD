using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCreator : MonoBehaviour
{
    public GameObject turretGrid;
    List<GameObject> gridParts = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        Transform container = turretGrid.transform.FindChild("Container");
        foreach(Transform child in container)
        {
            gridParts.Add(child.gameObject);
        }

        StartCoroutine(CreateGrid());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator CreateGrid()
    {
        foreach (GameObject g in gridParts)
        {
            g.transform.FindChild("GridMesh").GetComponent<MeshRenderer>().enabled = true;
            yield return new WaitForSeconds(0.06f);
        }
    }
}
