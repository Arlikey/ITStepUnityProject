using UnityEditor;
using UnityEngine;

namespace Prototype1
{
	public class FollowPlayer : MonoBehaviour
	{
		[SerializeField]
		private GameObject _player;
		private Vector3 _offset;

		// Start is called once before the first execution of Update after the MonoBehaviour is created
		void Start()
		{
			_offset = transform.position;
		}

		// Update is called once per frame
		void LateUpdate()
		{
			transform.position = _player.transform.position + _offset;
		}
	}
}


