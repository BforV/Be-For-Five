using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace InfimaGames.LowPolyShooterPack { 
public class CharacterJump : MonoBehaviour
{

    public Vector3 jump;
    public bool isGrounded;
    public Movement movement;
    //public float fallingGravityScale = 40;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && movement.grounded)
        {

            rb.AddForce(jump, ForceMode.Impulse);
            isGrounded = false;
        }

    }

}
}