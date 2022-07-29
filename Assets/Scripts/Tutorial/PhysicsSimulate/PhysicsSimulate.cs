using UnityEngine;
using UnityEngine.SceneManagement;

namespace Mark.Ballinger.GAM405.Scripting.for.Game.Development.B
{
	
	public class PhysicsSimulate : MonoBehaviour
	{
		[Range(1, 120)]
		public int TargetFrameRate = 60;

		private float _timer;

		private float _physicsScale = 1;

		protected void Start()
		{
			// FrameRate	60 this is	
			// Required to manually manipulate current framerate
			QualitySettings.vSyncCount = 0;

			// Physics autosimulate is true by default. set to false to call the simulate function
			Physics.autoSimulation = false;
		}

		protected void OnValidate()
		{
			// FrameRate set to values with a good range of 1 to 120
			// then it chanegs the frameRate
			TargetFrameRate = Mathf.Clamp(TargetFrameRate, 1, 120);
			if (Application.targetFrameRate != TargetFrameRate)
			{
				Application.targetFrameRate = TargetFrameRate;
				Debug.Log(Application.targetFrameRate);
			}
		}

		protected void Update()
		{
			// Physics			
			if (Physics.autoSimulation)
			{
				return; // do nothing if the automatic simulation is enabled
			}

			// Time Dilation area
			if (Input.GetKey(KeyCode.LeftShift))
			{
				// Slow Speed down
				Time.timeScale = 0.25f;
			}
			else
			{
				// Normal Speed
				Time.timeScale = 1;
			}

			// Physics Dilation input get keydown spacebar
			if (Input.GetKey(KeyCode.Space))
			{
				// physics scales set to Slow Speed
				_physicsScale = 0.25f;
			}
			else
			{
				// _physicsscale set to normal Speed
				_physicsScale = 1;
			}

			_timer += Time.deltaTime;

			// Physics to Wait enough "DeltaTime" before calling Simulate()
			// then it will Catch up with the game time.
			// move the set physics simulation forward in portions of Time.fixedDeltaTime

			// i can comment out the while statement and it will show you the dilation NOT working recomment to set it backl to normal
			while (_timer >= Time.fixedDeltaTime)
			{
				_timer -= Time.fixedDeltaTime / _physicsScale;

				// Note that unity docs says don't want to pass the variable delta to Simulate 
				// as it will cause problems and leads instability.
				Physics.Simulate(Time.fixedDeltaTime);
			}

			// Here you can access the transforms state right after the simulation, if needed
		}
	}
}