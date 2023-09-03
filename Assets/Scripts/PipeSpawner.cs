using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 1, 2);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Spawn()
    {
        Instantiate(pipePrefab, new Vector3(9.5f, Random.Range(2.5f, -2.5f), 0), Quaternion.identity);
    }
}
