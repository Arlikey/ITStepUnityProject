using UnityEngine;

namespace Prototype2
{
	public class AnimalSpawner : MonoBehaviour
	{
		[SerializeField]
		private GameObject[] _animalPrefabs;

		[SerializeField]
		private float _startDelay = 2.0f;
		[SerializeField]
		private float _interval = 1.5f;

		[SerializeField]
		private float _xRange = 15f;
		[SerializeField]
		private float _zSpawnPos = 19f;
		void Start()
		{
			InvokeRepeating("SpawnRandomAnimal", _startDelay, _interval);
		}

		void Update()
		{

		}

		private void SpawnRandomAnimal()
		{
			int index = Random.Range(0, _animalPrefabs.Length);

			float xSpawnCoord = Random.Range(-_xRange, _xRange);
			Vector3 spawnPos = new Vector3(xSpawnCoord, 0, _zSpawnPos);

			Instantiate(_animalPrefabs[index], spawnPos, _animalPrefabs[index].transform.rotation);
		}
	}

}
