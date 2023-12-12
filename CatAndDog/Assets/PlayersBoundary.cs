using UnityEngine;

public class PlayersBoundary : MonoBehaviour
{
    [SerializeField] private Transform cat, dog;

    private void LateUpdate()
    {
        float xPos = (cat.position.x + dog.position.x) / 2f;
        transform.position = new Vector3(xPos, transform.position.y, 0);
    }
}
