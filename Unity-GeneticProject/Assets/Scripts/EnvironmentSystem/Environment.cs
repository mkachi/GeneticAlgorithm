using UnityEngine;
using System.Collections.Generic;

public class Environment
    : MonoBehaviour
{
    [SerializeField]
    private List<Biome> _biomes = new List<Biome>();

    public BiomeType GetBiome(Vector3 position)
    {
        for (int i = 0; i < _biomes.Count; ++i)
        {
            if (_biomes[i].InBiome(position))
            {
                return _biomes[i].BiomeType;
            }
        }
        return BiomeType.Normal;
    }
}