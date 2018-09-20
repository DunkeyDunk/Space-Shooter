using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Boundary
{
    public float
        xMin =-6,
        xMax = 6,
        zMin =-4,
        zMax = 7;
}

public class PlayerController : MonoBehaviour {

    public float speed = 10;
    public Boundary boundary;

    void FixedUpdate()
    {
        float moveHorrizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorrizontal, 0.0f, moveVertical);
        GetComponent<Rigidbody>().velocity = movement*speed;

        GetComponent<Rigidbody>().position = new Vector3
        (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
        );
    }
}
