using UnityEngine;

public class EnvironmentChecker
    : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 5);
    }
}
