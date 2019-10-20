using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float m_MoveSpeed;

    private Rigidbody2D m_Rigidbody = null;
    private Animator m_Animator = null;

    private bool m_IsOnGround = false;
    private Vector2 m_ForceUpdate = Vector2.zero;

    void Start()
    {
        this.m_Rigidbody = this.GetComponent<Rigidbody2D>();
        this.m_Animator = this.GetComponent<Animator>();
    }

    void Update()
    {
        this.InputKeys();
        this.UpdateAnimations();
    }

    private void InputKeys()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            this.MoveUp();
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            this.MoveLeft();
        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
            this.MoveRight();
        }
    }

    private void UpdateAnimations()
    {
        Vector2 Force = this.m_Rigidbody.velocity;

        if (this.m_IsOnGround)
        {
            this.SetBool("IsJumping", false);
        }
        else
        {
            this.SetBool("IsJumping", true);
        }

        if(Mathf.Abs(Force.x) > 1.0f)
        {
            this.SetBool("IsRunning", true);
        }
        else
        {
            this.SetBool("IsRunning", false);
        }
    }

    private void MoveUp()
    {
        if (this.m_IsOnGround)
        {
            this.m_IsOnGround = false;

            this.Move(Vector2.up * 25.0f);
        }
    }

    private void MoveLeft()
    {
        this.Move(Vector2.left);
    }

    private void MoveRight()
    {
        this.Move(Vector2.right);
    }

    private void Move(Vector2 Direction)
    {
        this.m_Rigidbody.AddForce(Direction * this.m_MoveSpeed * Time.deltaTime);
    }

    private void SetBool(string Name, bool Value)
    {
        this.m_Animator.SetBool(Name, Value);
    }

    private void OnCollisionEnter2D(Collision2D Collider)
    {
        if(Collider.gameObject.tag.Equals("Ground"))
        {
            this.m_IsOnGround = true;
        }
    }
}
