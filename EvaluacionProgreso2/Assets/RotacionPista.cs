using UnityEngine;

public class RotacionPista : MonoBehaviour
{
    public float velocidadRotacion = 10f;

    void Update()
    {
        // Rotar alrededor del eje Z
        transform.Rotate(Vector3.forward * velocidadRotacion * Time.deltaTime);
    }
}

