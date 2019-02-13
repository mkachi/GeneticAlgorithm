using UnityEngine;

public enum BiomeType
{
    None,
    Desert,
    Polar,
    Normal,
}

[RequireComponent(typeof(Region))]
public class Biome
    : MonoBehaviour
{
    [SerializeField]
    private Region _region;
    [SerializeField]
    private BiomeType _biome = BiomeType.None;
    public BiomeType BiomeType { get { return _biome; } }

    public bool InBiome(Vector3 position)
    {
        return _region.InRegion(position);
    }
}