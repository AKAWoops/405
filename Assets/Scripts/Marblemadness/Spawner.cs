
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//this below command is to suppress the error message for not having anything set in fields or nothing added being an instance of an object for eg stops the message from hitting the console
#pragma warning disable 649  
namespace SAE.Mark.Ballinger.GAM405.Shared
{
	public class Spawner : MonoBehaviour
	{
		[SerializeField]
		private bool _willSpawnImmediately = true;

		// How amount per spawn?
		[SerializeField]
		private int _spawnAmount = 1;

		// How long between each spawn, seconds?
		[SerializeField]
		private float _spawnDelay = 3f;

		// The enemy prefab to be spawned?
		[SerializeField]
		private GameObject _prefab;
		
		[SerializeField]
		private Transform _parent;

		[SerializeField]
		private Transform _origin;

		[SerializeField]
		private bool _useOriginOffsetRandom = true;

		[SerializeField]
		private Vector3 _originOffsetRandom = new Vector3();

		[SerializeField]
		private bool _useOriginOffsetSystematic = false;

		[SerializeField]
		private Vector3 _originOffsetSystematic = new Vector3();

		[SerializeField]
		private bool _willDestroySpawned = true;

		[SerializeField]
		private bool _willDestroySleeping = true;

		private List<GameObject> _spawnedObjects;

		[SerializeField]
		private UnityEvent OnSpawned = new UnityEvent();

		protected void Start()
		{
			_spawnedObjects = new List<GameObject>();

			// Call repeated every X seconds (if non-zero)
			if (_spawnDelay > 0)
			{
				InvokeRepeating("Spawn", _spawnDelay, _spawnDelay);
			}
			

			// Also spawn one immediately
			if (_willSpawnImmediately)
			{
				Spawn();
			}
		}

		private void Spawn()
		{
			for (int i = 0; i < _spawnAmount; i++)
			{
				// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation. yet to be created will do over the next couple of weeks
				GameObject spawned = Instantiate<GameObject>(_prefab);
				spawned.transform.SetParent(_parent, true);
				spawned.transform.position = _origin.position;

				_spawnedObjects.Add(spawned);

				// this code below goes through and Systematically changes the starting position for the Marble well sphere assets
				if (_useOriginOffsetSystematic)
				{
					float x = _originOffsetSystematic.x * i;
					float y = _originOffsetSystematic.y * i;
					float z = _originOffsetSystematic.z * i;
					spawned.transform.Translate(new Vector3(x, y, z));
				}

				// Randomly change starting position
				if (_useOriginOffsetRandom)
				{
					float x = Random.Range(-_originOffsetRandom.x, _originOffsetRandom.x);
					float y = Random.Range(-_originOffsetRandom.y, _originOffsetRandom.y);
					float z = Random.Range(-_originOffsetRandom.z, _originOffsetRandom.z);
					spawned.transform.Translate(new Vector3(x, y, z));
				}
			}

			OnSpawned.Invoke();


			
		}


		protected void Update()
		{
			if (_willDestroySpawned)
			{
				for (int s = _spawnedObjects.Count -1; s >= 0; s--)
				{
					// If sufficiently 'low', then delete to improve performance
					if (_spawnedObjects[s].transform.position.y < -10)
					{
						Destroy(_spawnedObjects[s]);
						_spawnedObjects.RemoveAt(s);
					}
				}
			}

			if (_willDestroySleeping)
			{
				for (int s = _spawnedObjects.Count - 1; s >= 0; s--)
				{
					// If the objects are completely 'still', delete to save on memeory resources this will improve performance dont want to happen what did with non destruct bullets ahaha
					Rigidbody rigidBody = _spawnedObjects[s].GetComponent<Rigidbody>();
					if (rigidBody != null)
					{
						if (rigidBody.IsSleeping())
						{
							Destroy(_spawnedObjects[s]);
							_spawnedObjects.RemoveAt(s);
						}
					}
				}
			}
		}
	}
}