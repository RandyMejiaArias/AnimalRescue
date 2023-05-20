using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Objectives : MonoBehaviour
{
    public Cat cat;
    public MainCharacter mainCharacter;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            // Destroy(other.transform.parent.gameObject);
            cat.quantityObjectives--;
            cat.textMission.text = "Busca un poco de soga para hacer un torniquete.";
            if(cat.quantityObjectives <= 0) {
                cat.textMission.text = "Haz completado la misión.";
                cat.buttonMission.SetActive(true);
                mainCharacter.characterLevel++;
            }

            transform.parent.gameObject.SetActive(false);
        }
    }
}
