using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // Referencia al objeto que la cámara debe seguir.
    public float smoothTime = 0.3f;  // Tiempo suavizado de seguimiento.
    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, target.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}

