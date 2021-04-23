using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    private Transform _transform;
    public GameObject tarjet;
    private float x, y, z;

    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        x = _transform.position.x;
        y = tarjet.transform.position.y;
        z = _transform.position.z;
        _transform.position = new Vector3(x, y + 0.4f, z);
    }
}