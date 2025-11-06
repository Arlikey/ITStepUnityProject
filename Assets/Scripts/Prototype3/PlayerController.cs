using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Prototype3
{
	public class PlayerController : MonoBehaviour
	{
		[SerializeField]
		private float _jumpForce = 500.0f;
		[SerializeField]
		private float _gravityModifier = 9.81f;

		private Rigidbody _rb;

		private InputAction _jumpAction;

		private bool _isGrounded = true;

		void Start()
		{
			_rb = GetComponent<Rigidbody>();
			Physics.gravity *= _gravityModifier;

			_jumpAction = InputSystem.actions.FindAction("Jump");
			_jumpAction.performed += OnJump;
		}

		void Update()
		{

		}

		private void OnJump(InputAction.CallbackContext context)
		{
			if (_isGrounded)
			{
				_rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
				_isGrounded = false;
			}
		}

		private void OnCollisionEnter(Collision collision)
		{
			_isGrounded = true;
		}
	}

}