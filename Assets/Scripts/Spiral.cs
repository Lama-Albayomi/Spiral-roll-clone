using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spiral : MonoBehaviour
{

    private float size ;
    private Rigidbody rb;
    private Spiral spiral;
    [Range(0,1)]
    public float startSpiralGrowthSpeed;
    private float spiralGrowthSpeed;

    [Range(0,1000)]
    public float throwForce;
    private float length = 0.3f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        SetUpVariables();
    }

    void Update()
    {
        
    }
    private void SetUpVariables(){
        length = transform.localScale.x;
        size = transform.localScale.y;
        spiralGrowthSpeed = startSpiralGrowthSpeed;
    }
    public void UpdateRadius(){
        size+=Time.deltaTime*spiralGrowthSpeed;

        if (size>0.4f && length!=1f){
            length = 1f;
        }

        this.transform.localScale = new Vector3(length, size, size);

        if (spiralGrowthSpeed>0.1f){
            // slow the groth
            spiralGrowthSpeed-=0.005f;
        }
    }
    public void StopedScraping(){
        rb.useGravity = true;
        Vector3 direction = new Vector3(0,1,1);
        rb.AddForce(direction*throwForce);
        // small ones fly higher
        rb.mass= size;
        this.transform.parent = null;
    }
    private void OnTriggerEnter(Collider other) {
        
    }
}
