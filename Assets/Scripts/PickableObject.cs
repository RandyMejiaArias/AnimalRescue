using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{
    public bool pickWithKey;
    public bool pickAuto;

    public MainCharacter mainCharacter;

    public int type;

    // Start is called before the first frame update
    void Start()
    {
        mainCharacter = GameObject.FindGameObjectWithTag("Player").GetComponent<MainCharacter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickUp() {
        switch (type) {
            case 1:
                mainCharacter.initialSpeed += 3;
                break;

            default:
                Debug.Log("There is not effect.");
                break;
        }
    }
}
