using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction thrust;

    Rigidbody rb;

     private void Start()
     {
          rb = GetComponent<Rigidbody>();
     }

     private void OnEnable()
     {
          thrust.Enable();
     }

     private void FixedUpdate()
     {
          if (thrust.IsPressed())
          {
            Debug.Log("Cek data");
            //rb.AddRelativeForce(0,0,100);
          }
     }
}
