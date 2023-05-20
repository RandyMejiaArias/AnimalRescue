using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if(Physics.Raycast(ray, out hitInfo)){
                if(hitInfo.collider.gameObject.tag == "PowerUpObject" && hitInfo.collider.gameObject.GetComponent<PickableObject>().pickWithKey == true) {
                    Debug.Log(hitInfo.collider.gameObject.tag);
                    hitInfo.collider.gameObject.GetComponent<PickableObject>().PickUp();
                    Destroy(hitInfo.collider.gameObject);
                }
            }
        }
    }

    private void onTriggerStay(Collider other) {
        Debug.Log("other.tag");
        Debug.Log(other.tag);
        if(other.tag == "PowerUpObject" && other.GetComponent<PickableObject>().pickAuto == true) {
            Debug.Log("PickAuto");
            other.GetComponent<PickableObject>().PickUp();
            Destroy(other.gameObject);
        }

        if(other.tag == "PowerUpObject") {
            Debug.Log("PickClick");
            if(Input.GetMouseButtonDown(1) && other.GetComponent<PickableObject>().pickWithKey == false) {
                other.GetComponent<PickableObject>().PickUp();
                Destroy(other.gameObject) ;
            }
        }
    }
}
