using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Prototype5
{
	public class Target : MonoBehaviour
	{
		private Rigidbody _rb;

		private float xRange = 4.3f;

		[SerializeField]
		private float _minForce = 10.0f;
		[SerializeField]
		private float _maxForce = 20.0f;

		[SerializeField]
		private float _rangeTorgue = 2.0f;

		[SerializeField]
		private int _score;

		[SerializeField]
		private ParticleSystem _particleSystem;

		public event Action<int> OnClicked;
		// Start is called once before the first execution of Update after the MonoBehaviour is created
		void Start()
		{
			_rb = GetComponent<Rigidbody>();
			transform.position = GetRandomPos();
			_rb.AddForce(Vector3.up * GetRandomForce(), ForceMode.Impulse);
			_rb.AddTorque(
				new Vector3(
					GetRandomTorque(),
					GetRandomTorque(),
					GetRandomTorque()
				),
				ForceMode.Impulse
			);

		}

		private float GetRandomForce()
		{
			return Random.Range(_minForce, _maxForce);
		}

		private Vector3 GetRandomPos()
		{
			return new Vector3(Random.Range(-xRange, xRange), -1.0f);
		}

		private float GetRandomTorque()
		{
			return Random.Range(-_rangeTorgue, _rangeTorgue);
		}

		private void OnTriggerEnter(Collider other)
		{
			Destroy(gameObject);
		}

		private void OnMouseDown()
		{
			OnClicked?.Invoke(_score);
			Instantiate(_particleSystem, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}

}