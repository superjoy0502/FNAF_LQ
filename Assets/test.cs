using UnityEngine;
using System.Collections;

public class test : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(60*(Vector3.up * Time.deltaTime));

    }
}
