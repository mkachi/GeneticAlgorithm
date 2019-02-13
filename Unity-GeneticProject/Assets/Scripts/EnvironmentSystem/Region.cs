using UnityEngine;
using System.Collections.Generic;

public class Region
    : MonoBehaviour
{
    [SerializeField]
    private Color _color;

    private List<Vector3> _regionNodes = new List<Vector3>();
    public List<Vector3> RegionNodes { get { return _regionNodes; } }

    private void Awake()
    {
        Transform[] children = transform.GetComponentsInChildren<Transform>();
        for (int i = 1; i < children.Length; ++i)
        {
            _regionNodes.Add(children[i].transform.position);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Transform[] children = transform.GetComponentsInChildren<Transform>();
        Gizmos.color = _color;
        if (children.Length >= 2)
        {
            for (int i = 2; i < children.Length; ++i)
            {
                Gizmos.DrawLine(children[i - 1].position, children[i].position);
            }
        }
    }

    public bool InRegion(Vector3 position)
    {
        int cn = 0;
        for (int i = 0; i < _regionNodes.Count; ++i)
        {
            int j = (i + 1) % _regionNodes.Count;
            if ((_regionNodes[i].z > position.z) != (_regionNodes[j].z > position.z))
            {
                double atx =
                    (_regionNodes[j].x - _regionNodes[i].x) *
                    (position.z - _regionNodes[i].z) / (_regionNodes[j].z - _regionNodes[i].z) + _regionNodes[i].x;
                if (position.x < atx)
                {
                    cn++;
                }
            }
        }
        return cn % 2 > 0;
    }
}