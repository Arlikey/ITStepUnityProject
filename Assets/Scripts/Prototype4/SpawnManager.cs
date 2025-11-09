using UnityEngine;

namespace Prototype4
{
	public class SpawnManager : MonoBehaviour
	{
		[SerializeField]
		private GameObject _enemyPrefab;

		[SerializeField]
		private float _spawnRadius = 10.0f;
		// Start is called once before the first execution of Update after the MonoBehaviour is created
		void Start()
		{
			SpawnEnemy();
		}

		private void SpawnEnemy()
		{
			Vector3 spawnPos = GenerateRandomPoint();

			Instantiate(_enemyPrefab, spawnPos, Quaternion.identity);
		}

		private Vector3 GenerateRandomPoint()
		{
			float spawnPosX = Random.Range(-_spawnRadius, _spawnRadius);
			float spawnPosZ = Random.Range(-_spawnRadius, _spawnRadius);
			Vector3 spawnPos = new Vector3(spawnPosX, 0f, spawnPosZ);
			return spawnPos;
		}

		// Update is called once per frame
		void Update()
		{

		}
	}

}