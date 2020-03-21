using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    LineRenderer lineRenderer;

    public float rotateSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = this.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,rotateSpeed * Time.deltaTime,0);
        lineRenderer.SetPosition(0, this.transform.position);
        RaycastHit hit;
        if(Physics.Raycast(transform.position,transform.forward * -1, out hit)){
            if(hit.collider){
                lineRenderer.SetPosition(1,hit.point);
                if(hit.collider.gameObject.CompareTag("Player")){
                      Destroy(hit.collider.gameObject);
                }
            }
        }
        else{
            lineRenderer.SetPosition(1,transform.forward * 5000);
        }

    }
}
