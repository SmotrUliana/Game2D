using UnityEngine;

public class InputAdapter
{
    public float HorizontalInput => Input.GetAxisRaw("Horizontal");
    public float VerticalInput => Input.GetAxisRaw("Vertical");
    public bool IsJumpPressed => Input.GetButtonDown("Jump");
}