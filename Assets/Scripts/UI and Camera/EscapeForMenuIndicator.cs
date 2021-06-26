using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EscapeForMenuIndicator : MonoBehaviour
{
    public MainController MainCamera;
    private TMP_Text TextComp;
    private void Awake()
    {
        TextComp = GetComponent<TMP_Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (MainCamera.EscapeForMenu)
        {
            case 0:
                TextComp.text = "Выключено";
                break;
            case 1:
                TextComp.text = "Включено";
                break;
        }
    }
}
