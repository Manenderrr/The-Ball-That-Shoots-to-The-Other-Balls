using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    public GameObject Player;
    public float Speed = 1;
    public Vector3 PreviousPlayerPosition;
    public void Smooth(Vector2 NewPosition)
    {
        Vector2 PreviousPosition = transform.position;
        float t = 0;

        while (new Vector2(transform.position.x, transform.position.y) != PreviousPosition)
        {
            transform.position = Vector2.Lerp(PreviousPosition, NewPosition, t);
            t += Time.deltaTime * Speed;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position != PreviousPlayerPosition) Smooth(Player.transform.position);


        PreviousPlayerPosition = Player.transform.position;
    }
}
