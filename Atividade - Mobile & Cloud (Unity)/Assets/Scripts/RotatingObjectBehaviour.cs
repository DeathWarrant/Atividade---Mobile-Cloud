using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObjectBehaviour : MonoBehaviour
{
    public float rotationSpeed = 0.0f;

    private void Update ()
    {
        RotateObject();	
	}

    private void RotateObject()
    {
        Vector3 rotationVector = new Vector3(0, rotationSpeed, 0);
        gameObject.transform.Rotate(rotationVector * Time.deltaTime);
    }
}
