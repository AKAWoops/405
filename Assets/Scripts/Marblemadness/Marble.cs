using RMC.Mark.Ballinger.GAM405.Shared;
using UnityEngine;

namespace Mark.Ballinger.GAM405.Shared
{
	public class Marble : MonoBehaviour
	{
		[SerializeField]
		private bool _isDebug = false;

		[SerializeField]
		private float _speed = 20;

		[SerializeField]
		private Rigidbody _rigidbody = null;

		private Vector3 _lastInput = Vector3.zero;

		private Ray _isMarbleGroundedRay;

		private bool _isMarbleGrounded = true;
		private bool _isSpeedTooHigh = false;

		protected void Start()
		{
			_isMarbleGroundedRay = new Ray(transform.position, Vector3.down);
		}

		protected void Update()
		{
			float moveHorizontal = Input.GetAxis("Horizontal");
			float moveVertical = Input.GetAxis("Vertical");

			_lastInput = new Vector3(moveHorizontal, 0.0f, moveVertical);
			_isSpeedTooHigh = _rigidbody.velocity.magnitude > MarbleConstants.MarbleMaxSpeed;
		}

		protected void FixedUpdate()
		{
			if (MarbleGame.Instance.IsGameOver)
			{
				// When the game ends, come to a quick but gradual stop
				_rigidbody.angularDrag = MarbleConstants.MarbleAngularDragAtFinishArea;
				return;
			}

			// Check if we are on the ground (or close)
			_isMarbleGroundedRay.origin = transform.position;
			_isMarbleGrounded = Physics.Raycast(_isMarbleGroundedRay,
				MarbleConstants.IsMarbleGroundedRayDistance);

			if (_isDebug)
			{
				Debug.DrawRay(_isMarbleGroundedRay.origin, _isMarbleGroundedRay.direction,
								Color.red, 0.01f);
			}

			// Only allow forces if we are on the ground and not going too fast
			if (_isMarbleGrounded && !_isSpeedTooHigh)
			{
				_rigidbody.AddForce(_lastInput * _speed, ForceMode.Force);
			}
		}

		protected void OnCollisionEnter(Collision collision)
		{
			if (collision.gameObject.layer == LayerMask.NameToLayer (MarbleConstants.FloorLayer))
			{
				return;
			}

			SoundManager.Instance.PlayAudioClip(MarbleConstants.CollisionSound);
		}

		protected void OnTriggerEnter(Collider collider)
		{
			if (collider.gameObject.tag == MarbleConstants.CoinTag)
			{
				Coin coin = collider.gameObject.GetComponent<Coin>();
				if (coin != null && coin.IsAlive)
				{
					coin.DestroyMe();
					MarbleGame.Instance.Score += MarbleConstants.PointsPerCoin;

					//////////////////////////////////
					//1. Play Sound
					//////////////////////////////////
					SoundManager.Instance.PlayAudioClip(MarbleConstants.CoinSound);
				}
			}

			if (collider.gameObject.tag == MarbleConstants.FinishAreaTag)
			{
				MarbleGame.Instance.EndTheGame(true);
			}
		}
	}
}