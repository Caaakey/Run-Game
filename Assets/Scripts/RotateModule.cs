using UnityEngine;

class RotateModule : MonoBehaviour
{
    public float speed = 30f;
    private void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}
