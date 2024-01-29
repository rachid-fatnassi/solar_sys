using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystem : MonoBehaviour
{
    public Transform earth;
    public Transform jupyter;
    public Transform moon;

    public float earthRotationSpeed = 50f;
    public float jupyterRotationSpeed = 50f;
    public float moonRotationSpeed = 30f;

    void Update()
    {
        // Earth's rotation around its own axis
        earth.Rotate(Vector3.up, earthRotationSpeed * Time.deltaTime);

        // jupyter and Moon orbiting around Earth
        jupyter.position = Quaternion.Euler(0, earthRotationSpeed * Time.deltaTime, 0) * (jupyter.position - earth.position) + earth.position;
        moon.position = Quaternion.Euler(0, earthRotationSpeed * Time.deltaTime, 0) * (moon.position - earth.position) + earth.position;

        // Moon orbiting around jupyter
        moon.position = Quaternion.Euler(0, jupyterRotationSpeed * Time.deltaTime, 0) * (moon.position - jupyter.position) + jupyter.position;

        // jupyter's rotation around its own axis
        jupyter.Rotate(Vector3.up, jupyterRotationSpeed * Time.deltaTime);
    }
}