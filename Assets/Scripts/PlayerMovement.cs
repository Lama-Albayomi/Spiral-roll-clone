using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Range(0,20)]
    public float speed;
    public Transform spiralHolder;
    private Rigidbody rb;
    private Animator animator;
    public GameObject spiralPrefab;
    private Spiral spiral;
    public bool canScrape = false;
    public bool cantGoDawn = false;

    // animaton states
    int scraperUp=0; 
    int scraperDown=1;
    int scraperBreak=1;
    
    void Start()
    {
        rb= GetComponent<Rigidbody>();
        animator= GetComponent<Animator>();
    }

    void Update()
    {
        rb.velocity=Vector3.forward*speed;
        
            if (Input.GetMouseButtonDown(0)){
                if (canScrape){
                    StartScraping();
                }
                else if (cantGoDawn){
                    BreakScraper();
                }
            }
            if (Input.GetMouseButton(0)&&canScrape){
                spiral.UpdateRadius();
            }
            if (Input.GetMouseButtonUp(0)&&canScrape){
                // scraper up animation
                animator.SetInteger("State",scraperUp);
                spiral.StopedScraping();
            }
        
        if (!canScrape && spiral!=null){
            StopScraping();
        }

    }
    private void StartScraping(){
        // scraper dawn animation
        animator.SetInteger("State",scraperDown);
        // create spiral
        spiral=Instantiate(spiralPrefab,spiralHolder,false).GetComponent<Spiral>();
    }
    private void StopScraping(){
        // scraper up animation
        animator.SetInteger("State",scraperUp);
        spiral.StopedScraping();
        spiral=null;
    }
    private void BreakScraper(){
        // lose animation
        animator.SetInteger("State",scraperBreak);
        Debug.Log("BreakScraper");
    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag(Helper.path)){
            canScrape = true;
        }
        else if (other.CompareTag(Helper.obstical)){
            cantGoDawn = true;
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.CompareTag(Helper.path)){
            canScrape = false;
        }
        else if (other.CompareTag(Helper.obstical)){
            cantGoDawn = false;
        }
    }
}
