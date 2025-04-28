using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
     [SerializeField] InputAction thrust;
     [SerializeField] InputAction rotation;
     [SerializeField] float thrustStrength = 1000f;
     [SerializeField] float rotationStrength = 100f;
     [SerializeField] AudioClip mainEngineSFX;
     [SerializeField] ParticleSystem mainEngineParticles;
     [SerializeField] ParticleSystem leftTrustParticles;
     [SerializeField] ParticleSystem rightRhrustParticles;

     Rigidbody rb;
     AudioSource audioSource;

     private void Start()
     {
          rb = GetComponent<Rigidbody>();
          audioSource = GetComponent<AudioSource>();
     }

     private void OnEnable()
     {
          thrust.Enable();
          rotation.Enable();
     }

     private void FixedUpdate()
     {
          ProcessThrush();
          ProcessRotation();
     }

     private void ProcessThrush()
     {
          if (thrust.IsPressed())
          {
               StartThrusting();
          }
          else
          {
               StopThrusting();
          }
     }
     private void ProcessRotation()
     {
          RotationThrusting();

     }

     private void StartThrusting()
     {
          // Debug.Log("Cek data roket terbang/tidak");
          rb.AddRelativeForce(Vector3.up * thrustStrength * Time.fixedDeltaTime);
          if (!audioSource.isPlaying)
          {
               audioSource.PlayOneShot(mainEngineSFX);
          }
          if (!mainEngineParticles.isPlaying)
          {
               mainEngineParticles.Play();
          }
     }

     private void StopThrusting()
     {
          audioSource.Stop();
          mainEngineParticles.Stop();
     }

     private void RotationThrusting()
     {
          // Debug.Log("Cek data roket rotasi/tidak");
          // Debug.Log("Disini hasil nilai rotasi: " + rotationInput);
          float rotationInput = rotation.ReadValue<float>();
          if (rotationInput < 0)
          {
               RightRotation();

          }
          else if (rotationInput > 0)
          {
               LeftRotation();
          }
          else
          {
               StopRotation();
          }
     }

     private void RightRotation()
     {
          ApplyRotation(rotationStrength);
          if (!leftTrustParticles.isPlaying)
          {
               rightRhrustParticles.Stop();
               leftTrustParticles.Play();
          }
     }

     private void LeftRotation()
     {
          ApplyRotation(-rotationStrength);
          if (!rightRhrustParticles.isPlaying)
          {
               leftTrustParticles.Stop();
               rightRhrustParticles.Play();
          }
     }

     private void StopRotation()
     {
          leftTrustParticles.Stop();
          rightRhrustParticles.Stop();
     }

     private void ApplyRotation(float rotationThisframe)
     {
          rb.freezeRotation = true;
          transform.Rotate(Vector3.forward * rotationThisframe * Time.fixedDeltaTime);
          rb.freezeRotation = false;
     }
}

// Nanti menambahkan asset obstacle lain
// Add Level Design
// Optimization Game
// Testing