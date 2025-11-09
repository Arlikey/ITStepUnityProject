using UnityEngine;

namespace Prototype4
{
	public class Enemy : MonoBehaviour
	{
		[SerializeField]
		private float _speed = 7.0f;

		private GameObject _player;

		private Rigidbody _rigidBody;
		void Start()
		{
			_rigidBody = GetComponent<Rigidbody>();

			_player = GameObject.Find("Player");
		}

		void Update()
		{
			Vector3 lookDir = (_player.transform.position - transform.position).normalized;
			_rigidBody.AddForce(lookDir * _speed);
		}
	}

}