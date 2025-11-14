using UnityEngine;

namespace Prototype4
{
	public class SpawnManager : MonoBehaviour
	{
		[SerializeField]
		private GameObject _enemyPrefab;
		[SerializeField]
		private GameObject _powerUpPrefab;

		[SerializeField]
		private float _spawnRadius = 10.0f;

		private int _enemyCount;
		private int _waveNumber = 1;
		// Start is called once before the first execution of Update after the MonoBehaviour is created
		void Start()
		{
			//SpawnEnemy();
			SpawnEnemyWave(_waveNumber);
		}

		private void SpawnEnemy()
		{
			Vector3 spawnPos = GenerateRandomPoint();

			var enemy = Instantiate(_enemyPrefab, spawnPos, Quaternion.identity).GetComponent<Enemy>();
			_enemyCount++;
			enemy.DeathEvent += () => _enemyCount--;
		}

		private Vector3 GenerateRandomPoint()
		{
			float spawnPosX = Random.Range(-_spawnRadius, _spawnRadius);
			float spawnPosZ = Random.Range(-_spawnRadius, _spawnRadius);
			Vector3 spawnPos = new Vector3(spawnPosX, 0f, spawnPosZ);
			return spawnPos;
		}

		private void SpawnEnemyWave(int spawnCount)
		{
			for (int i = 0; i < spawnCount; i++)
			{
				SpawnEnemy();
			}
			Instantiate(_powerUpPrefab, GenerateRandomPoint(), Quaternion.identity);
		}

		// Update is called once per frame
		void Update()
		{
			if (_enemyCount <= 0) {
				SpawnEnemyWave(++_waveNumber);
			}
		}
	}

}