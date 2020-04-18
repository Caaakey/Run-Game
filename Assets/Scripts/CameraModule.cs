using UnityEngine;

class CameraModule : MonoBehaviour
{
    public Transform playerTransform = null;
    private float distance;

    private void Awake()
    {
        distance = playerTransform.position.x;
    }

    private void FixedUpdate()
    {
        transform.localPosition = new Vector3(
            playerTransform.position.x - distance,
            0, 0);
    }

}
