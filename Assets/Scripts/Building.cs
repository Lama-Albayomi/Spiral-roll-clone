using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour{
    void Start()
    {
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag(Helper.spiral)){
            this.gameObject.SetActive(false);
        }
        else if (other.CompareTag(Helper.player)){
            other.GetComponent<PlayerMovement>().BreakScraper();
        }
    }
    
}
