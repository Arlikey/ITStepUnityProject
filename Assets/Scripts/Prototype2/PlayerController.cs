using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Prototype2
{
	public class PlayerController : MonoBehaviour
	{
		[SerializeField]
		private PoolableObject _foodPrefab;

		[SerializeField]
		private float _speed = 1.0f;

		[SerializeField]
		private float _bound = 15f;

		private InputAction _moveAction;
		private Vector2 _moveInput;

		private InputAction _fireAction;

		private ObjectPool<PoolableObject> _pool;

		void Start()
		{
			_pool = new ObjectPool<PoolableObject>(_foodPrefab);

			_moveAction = InputSystem.actions.FindAction("Move");
			_fireAction = InputSystem.actions.FindAction("Fire");

			_moveAction.performed += onMove;
			_moveAction.canceled += onMove;

			_fireAction.performed += onFire;
		}

		void Update()
		{
			if (Mathf.Abs(transform.position.x) > _bound)
			{
				transform.position = new Vector3(transform.position.x < 0 ? -_bound : _bound, 0f, 0f);
			}

			transform.Translate(new Vector3(_moveInput.x, 0, 0) * Time.deltaTime * _speed);
		}

		private void onMove(InputAction.CallbackContext context)
		{
			_moveInput = context.ReadValue<Vector2>();
		}

		private void onFire(InputAction.CallbackContext context)
		{
			var food = _pool.GetObject();

			food.gameObject.transform.position = transform.position;

			food.gameObject.SetActive(true);
			//Instantiate(_foodPrefab, transform.position, Quaternion.identity);
		}
	}
}


