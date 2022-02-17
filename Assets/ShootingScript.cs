using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ShootingScript : MonoBehaviour
{
  //  public OVRGrabbable ovrGrabbable;
    public OVRInput.Button shootingButton;
    public GameObject particle;
    public GameObject particleTarget;
    public GameObject particle2;

    private Vector3 scaleChange;
    private bool canScale = false;
    public GameObject hitObject;
    // Start is called before the first frame update
    void Start()
    {
       // ovrGrabbable = GetComponent<OVRGrabbable>();
    }

    // Update is called once per frame
    void Update()
    {
       

        if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            //turn on once on press.
            particle2.SetActive(true);
            RaycastHit hitData;
            
            if (Physics.Raycast(ray, out hitData, 40))
            {
                particle2.SetActive(false);
                hitObject = hitData.transform.gameObject;
                Debug.DrawRay(ray.origin, ray.direction * 100000, Color.green);
                Debug.Log("Activate Tractor Beam!");
                Debug.Log(hitObject);
                //turn on particle but set to hit object 
              
                //enable scale changing only if valid object 
                if (hitObject.tag == "Interactable")
                {
                    particleTarget.transform.position = hitObject.transform.position;
                    particle.SetActive(true);
                    scaleChange = new Vector3(4f, 4f, 4f);
                    try
                    {
                        hitObject.transform.SetParent(gameObject.GetComponent<Transform>());
                        hitObject.GetComponent<Rigidbody>().useGravity = false;
                        hitObject.GetComponent<Rigidbody>().isKinematic = true;
                        canScale = true;
                    }
                    catch(Exception e)
                    {

                    }
                }
            }

          

        }

        if (canScale && OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            Debug.Log("Press A working");
            if (canScale)
            {
                Debug.Log("Trying to scale!");
                hitObject.transform.localScale += scaleChange*Time.deltaTime*3;
            }

        }
        if (canScale && OVRInput.Get(OVRInput.Button.Two, OVRInput.Controller.RTouch))
        {
            Debug.Log("Press B working");
            if (canScale)
            {
                Debug.Log("Trying to scale!");
                hitObject.transform.localScale -= scaleChange * Time.deltaTime*3;
            }

        }
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            //shoot stuff
            Debug.Log("Deactivate Tractor Beam");
            particle2.SetActive(false);
            particle.SetActive(false);
            hitObject.transform.SetParent(null);
            hitObject.GetComponent<Rigidbody>().useGravity = true;
            hitObject.GetComponent<Rigidbody>().isKinematic = false;
            canScale = false;
        }
       // Vector2 input = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
       // Debug.Log(input.x + "y " + input.y);


    }
}
