using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
     [SerializeField] InputAction thrust;
     [SerializeField] InputAction rotation;
     [SerializeField] float thrustStrength = 1000f;
     [SerializeField] float rotationStrength = 100f;

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
               // Debug.Log("Cek data roket terbang/tidak");
               rb.AddRelativeForce(Vector3.up * thrustStrength * Time.fixedDeltaTime);
               if (!audioSource.isPlaying)
               {
                    audioSource.Play();
               }
          }
          else
          {
               audioSource.Stop();
          }
     }

     private void ProcessRotation()
     {
          // Debug.Log("Cek data roket rotasi/tidak");
          // Debug.Log("Disini hasil nilai rotasi: " + rotationInput);
          float rotationInput = rotation.ReadValue<float>();
          if (rotationInput < 0)
          {
               ApplyRotation(rotationStrength);
          }
          else if (rotationInput > 0)
          {
               ApplyRotation(-rotationStrength);
          }

     }

     private void ApplyRotation(float rotationThisframe)
     {
          rb.freezeRotation = true;
          transform.Rotate(Vector3.forward * rotationThisframe * Time.fixedDeltaTime);
          rb.freezeRotation = false;
     }
}
