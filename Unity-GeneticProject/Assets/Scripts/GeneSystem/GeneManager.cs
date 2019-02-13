using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public static class GeneManager
{
    private static List<Animal> _animals = new List<Animal>();

    public static void AddAnimal(Animal animal)
    {
        _animals.Add(animal);
    }

    public static void Evolution()
    {
        _animals = (from animal in _animals orderby animal.Genome.Rank descending select animal).ToList();

        List<Gene> newGeneration = new List<Gene>();
        for (int i = 0; i < _animals.Count; ++i)
        {
            Gene mother = _animals[Random.Range(0, 5)].Genome;
            Gene fother = _animals[i].Genome;
            Gene evoluteGene = fother.Evolution(mother);
            newGeneration.Add(evoluteGene);
        }

        for (int i = 0; i < newGeneration.Count; ++i)
        {
            _animals[i].Genome = newGeneration[i];
        }
    }
}