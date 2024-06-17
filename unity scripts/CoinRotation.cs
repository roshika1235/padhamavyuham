using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CoinRotation : MonoBehaviour
{
    public float rotationSpeed = 100f;

    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);
    }
}

