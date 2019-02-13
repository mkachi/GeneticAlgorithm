using UnityEngine;
using System.Collections;

public class AliveObject
    : MonoBehaviour
{
    public Gene Genome { get; set; }

    private void Awake()
    {
        Genome = new Gene(1.0f, 1.0f, 1.0f, 1.0f);
    }
}