using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Cat : MonoBehaviour
{
    public GameObject symbolMission;
    public MainCharacter mainCharacter;
    public GameObject panelNPC;
    public GameObject panelMission;
    public TextMeshProUGUI textMission;
    public bool isPlayerNear;
    public GameObject[] objectives;
    public int quantityObjectives;
    public GameObject buttonMission;

    // Start is called before the first frame update
    void Start()
    {
        quantityObjectives = objectives.Length;
        textMission.text = "Al parecer esta herido, adelante hay un cartón, recójelo para crear un inmovilizador.";
        mainCharacter = GameObject.FindGameObjectWithTag("Player").GetComponent<MainCharacter>();
        symbolMission.SetActive(true);
        panelNPC.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X)) {
            Vector3 playerPosition = new Vector3(transform.position.x, mainCharacter.gameObject.transform.position.y, transform.position.z);
            mainCharacter.gameObject.transform.LookAt(playerPosition);

            mainCharacter.animator.SetFloat("SpeedX", 0);
            mainCharacter.animator.SetFloat("SpeedY", 0);
            mainCharacter.enabled = false;
            panelNPC.SetActive(false);

            StartMission();
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            isPlayerNear = true;
            panelNPC.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == "Player") {
            isPlayerNear = false;
            panelNPC.SetActive(false);
        }
    }

    public void StartMission() {
        mainCharacter.enabled = true;
        for(int i = 0; i < objectives.Length; i++)
            objectives[i].SetActive(true);
        isPlayerNear = false;
        symbolMission.SetActive(false);
        panelNPC.SetActive(false);
        panelMission.SetActive(true);
    }
}
