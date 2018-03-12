using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotion : MonoBehaviour
{
    public Transform Target;
    private Vector3 cameraPosition;
    private Vector3 moveVector;


	void Start ()
    {
        cameraPosition = transform.position - Target.position;
	}
	
	void Update ()
    {
        CameraMove();
	}

    void CameraMove()
    {
        moveVector = Target.position + cameraPosition;
        moveVector.x = 0f;
        moveVector.y = 0f;

        transform.position = moveVector;
    }
}
