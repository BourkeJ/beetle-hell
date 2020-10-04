using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Vector3 startPos;
    public GameObject mainCamera;
    public float intensity;
    public float yIntensity;
    public float slowingDistance;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main.gameObject;
        startPos = transform.position;
        //intensity = transform.position.z;
        //yIntensity = transform.position.z+.1f;
    }

    // Update is called once per frame
    void LateUpdate()
    {
     //   if (mainCamera.transform.position.x < slowingDistance)
      //  {
            transform.position = new Vector3(startPos.x + mainCamera.transform.position.x / intensity, startPos.y + mainCamera.transform.position.y / yIntensity, transform.position.z);
      //  }
    //    else
     //   {
     //       transform.position = new Vector3(startPos.x + mainCamera.transform.position.x / intensity, startPos.y + mainCamera.transform.position.y / intensity, transform.position.z);
     //   }

    }
}
