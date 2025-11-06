using UnityEngine;

namespace Prototype2
{
	[RequireComponent(typeof(PoolableObject))]
	public class DestroyOutOfBounds : MonoBehaviour
	{
		[SerializeField]
		private float _upperBound = 20.0f;
		[SerializeField]
		private float _lowerBound = -5.0f;

		private PoolableObject _poolable;

		void Start()
		{
			_poolable = GetComponent<PoolableObject>();
		}

		void Update()
		{
			if (transform.position.z > _upperBound)
			{
				_poolable.ReturnCallback();
				//Destroy(gameObject);
			}
			else if (transform.position.z < _lowerBound)
			{
				_poolable.ReturnCallback();
				//Destroy(gameObject);
				Debug.Log("Game Over");
				Time.timeScale = 0.0f;
			}
		}
	}

}