using UnityEngine;

namespace Prototype2
{
	public class DestroyOutOfBounds : MonoBehaviour
	{
		[SerializeField]
		private float _upperBound = 20.0f;
		[SerializeField]
		private float _lowerBound = -5.0f;
		void Start()
		{

		}

		void Update()
		{
			if (transform.position.z > _upperBound)
			{
				Destroy(gameObject);
			}
			else if (transform.position.z < _lowerBound)
			{
				Destroy(gameObject);
				Debug.Log("Game Over");
				Time.timeScale = 0.0f;
			}
		}
	}

}