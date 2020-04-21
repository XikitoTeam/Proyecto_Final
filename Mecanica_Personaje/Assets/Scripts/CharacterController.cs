using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Collider
    private IsGrounded feed = null;
    //Rigidbody
    private Rigidbody rb;

    //Variables

        //Velocidad de movimiento
        public int MoveSpeed;

        //Velocidad de giro
        public int RotateSpeed;

        //Fuerza del salto
        public int JumpForce;

        //Velociades del Dash
        private float dashTime;
        public float dashSpeed;
        public float startDashTime;

        // Efecto del dash
        public GameObject dashEffect;

    



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        feed = GameObject.Find("Feed").GetComponent<IsGrounded>();

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
        Jump();
        Dash();

        

        

    }



    private void Move()
    {
        // Movimiento 

        if (Input.GetKey(KeyCode.W))
        {

            transform.Translate((Vector3.forward * MoveSpeed) * Time.deltaTime);

        }

        if (Input.GetKey(KeyCode.S))
        {

            transform.Translate((Vector3.forward * -MoveSpeed) * Time.deltaTime);

        }
    }

    private void Rotate()
    {

        // Rotacion

       if (Input.GetKey(KeyCode.A))
       {

          transform.Rotate((Vector3.up * RotateSpeed) * Time.deltaTime);

       }

       if (Input.GetKey(KeyCode.D))
       {

          transform.Rotate((Vector3.up * -RotateSpeed) * Time.deltaTime);

       }

    }

    private void Jump()
    {
        // Salto

        if (Input.GetKey(KeyCode.Space) && feed.is_grouned) rb.AddForce((Vector3.up * JumpForce), ForceMode.Impulse);
        
    }

    private void Dash()
    {

        // Dash solo hacia delante

        if (dashTime <= 0)
        {
            dashTime = startDashTime;
        }

        else
        {

            if (Input.GetKey(KeyCode.RightControl))
            {
                // Instanciar efecto
                Instantiate(dashEffect, transform.position, Quaternion.identity);
                rb.AddForce(this.transform.forward * dashSpeed, ForceMode.Impulse);

            }
        }

    }
}
