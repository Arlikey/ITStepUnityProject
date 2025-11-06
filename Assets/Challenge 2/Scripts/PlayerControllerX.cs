using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Challenge2
{
	public class PlayerControllerX : MonoBehaviour
	{
		public GameObject dogPrefab;

		[SerializeField]
		private float _cooldown = 1.0f;

		private float _nextAvailableTime;

		// Update is called once per frame
		void Update()
		{
			// On spacebar press, send dog
			if (Input.GetKeyDown(KeyCode.Space) && Time.time >= _nextAvailableTime)
			{
				Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
				_nextAvailableTime = Time.time + _cooldown;
			}
		}
	}
}
