using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [Header("Gameplay")]
    public bool IsAI;
    public float MoveSpeed;
    public GameObject Aim;

    [Header("Controls")]
    public KeyCode LeftKey = KeyCode.A;
    public KeyCode RightKey = KeyCode.D;
    public KeyCode DownKey = KeyCode.S;
    public KeyCode UpKey = KeyCode.W;


    public void Move(Vector2 Direction)
    {
        Direction = Direction.normalized;

        transform.Translate(MoveSpeed * Time.deltaTime * Direction);

        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsAI)
        {
            if (Input.GetKey(UpKey)) Move(transform.up);
            if (Input.GetKey(DownKey)) Move(-transform.up);
            if (Input.GetKey(LeftKey)) Move(-transform.right);
            if (Input.GetKey(RightKey)) Move(transform.right);
        }

        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
    }
}
