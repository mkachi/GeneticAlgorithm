#include <iostream>
#include <vector>
#include <queue>
#include <random>
#include <cmath>

#define TARGET_VALUE 100

int random(int min, int max, bool minus = false)
{
	std::mt19937 rng;
	rng.seed(std::random_device()());
	std::uniform_int_distribution<std::mt19937::result_type> dist(min, max);
	int result = dist(rng);

	if (minus && random(0, 100) > 50)
	{
		return -result;
	}
	return result;
}

class Genome
{
private:
	std::vector<int> _datas;
	int _fitness;

public:
	Genome(const std::vector<int> datas)
		: _datas(datas)
	{
		int sum = 0;
		for (auto& value : datas)
		{
			sum += value;
		}
		_fitness = TARGET_VALUE - (sum);
	}
	Genome(Genome& other)
		: _datas(other._datas)
		, _fitness(other._fitness) { }
	~Genome() {}

	void setData(int index, int value) { _datas[index] = value; }
	int getData(int index) { return _datas[index]; }

	int getFitness() { return _fitness; }

	Genome* maiting(Genome* father)
	{
		int mutentRange = random(0, 100);
		int rangeValue = 0;
		if (mutentRange < 3)
		{
			rangeValue = random(0, 4, true);
		}

		Genome* result(this);
		int slot = random(0, _datas.size() - 1);
		result->setData(slot, father->getData(slot) + rangeValue);
		result->updateFitness();
		return result;
	}

	void updateFitness()
	{
		int sum = 0;
		for (auto& value : _datas)
		{
			sum += value;
		}
		_fitness = abs(TARGET_VALUE - (sum));
	}

	void print()
	{
		std::cout << "{ ";
		for (int i = 0; i < _datas.size(); ++i)
		{
			std::cout << _datas[i] << " ";
		}
		std::cout << " } = ";
		std::cout << _fitness << std::endl;
	}

};

std::vector<Genome*> initGenomes()
{
	std::vector<Genome*> result;
	for (int i = 0; i < 10; ++i)
	{
		result.push_back(new Genome(
		{ 
			random(0, 9, true), 
			random(0, 9, true),
			random(0, 9, true),
			random(0, 9, true),
			random(0, 9, true),
			random(0, 9, true),
			random(0, 9, true),
			random(0, 9, true),
			random(0, 9, true),
			random(0, 9, true),
			random(0, 9, true),
			random(0, 9, true),
			random(0, 9, true) 
		}));
	}
	return result;
}

void printGenomes(int generation, std::vector<Genome*>& genomes)
{
	std::cout << generation << " Generation" << std::endl;
	for (int i = 0; i < genomes.size(); ++i)
	{
		genomes[i]->print();
	}
}

std::vector<Genome*> newGeneration(std::vector<Genome*>& beforeGeneration)
{
	std::vector<Genome*> result;
	for (auto& genome : beforeGeneration)
	{
		Genome* child = genome->maiting(beforeGeneration[random(0, 3)]);
		result.push_back(child);
	}
	return result;
}

int main()
{
	std::vector<Genome*> generation = initGenomes();

	int generationCount = 0;

	while (true)
	{
		printGenomes(++generationCount, generation);

		for (int i = 0; i < generation.size(); ++i)
		{
			if (generation[i]->getFitness() == 0)
			{
				goto SUPER_BREAK;
			}
		}
		std::sort(generation.begin(), generation.end(), [](Genome* a, Genome* b) { return a->getFitness() < b->getFitness(); });
		generation = newGeneration(generation);
	}
	SUPER_BREAK:
	std::cout << "==================" << std::endl;
	printGenomes(generationCount, generation);

	for (auto& genome : generation)
	{
		if (genome != nullptr)
		{
			delete genome;
			genome = nullptr;
		}
	}
	generation.clear();


	return 0;
}