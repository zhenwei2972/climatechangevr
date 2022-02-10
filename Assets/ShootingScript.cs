using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public OVRGrabbable ovrGrabbable;
    public OVRInput.Button shootingButton;
    public GameObject particle;
    public GameObject particleTarget;
    private Vector3 scaleChange;
    private bool canScale = false;
    public GameObject hitObject;
    // Start is called before the first frame update
    void Start()
    {
        ovrGrabbable = GetComponent<OVRGrabbable>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if(ovrGrabbable.isGrabbed)
        {
            Debug.Log("Grabbing this" + ovrGrabbable);
        }
        if(ovrGrabbable.isGrabbed && OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            
            RaycastHit hitData;
            
            if (Physics.Raycast(ray, out hitData, 20))
            {
                hitObject = hitData.transform.gameObject;
                Debug.DrawRay(ray.origin, ray.direction * 100000, Color.green);
                Debug.Log("Activate Tractor Beam!");
                Debug.Log(hitObject);
                particleTarget.transform.position = hitObject.transform.position;
                particle.SetActive(true);
               // Vector2 input = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
                //Debug.Log(input.x + "y " + input.y);
                scaleChange = new Vector3(2f,2f,2f);
                hitObject.transform.SetParent(gameObject.GetComponent<Transform>());
                hitObject.GetComponent<Rigidbody>().useGravity = false;
                hitObject.GetComponent<Rigidbody>().isKinematic = true;
                canScale = true;

            }
          

        }
        if (OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            Debug.Log("Press A working");
            if (canScale)
            {
                Debug.Log("Trying to scale!");
                hitObject.transform.localScale += scaleChange*Time.deltaTime*3;
            }

        }
        if (OVRInput.Get(OVRInput.Button.Two, OVRInput.Controller.RTouch))
        {
            Debug.Log("Press B working");
            if (canScale)
            {
                Debug.Log("Trying to scale!");
                hitObject.transform.localScale -= scaleChange * Time.deltaTime*3;
            }

        }
        if (ovrGrabbable.isGrabbed && OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            //shoot stuff
            Debug.Log("Deactivate Tractor Beam");
            particle.SetActive(false);
            hitObject.transform.SetParent(null);
            hitObject.GetComponent<Rigidbody>().useGravity = true;
            hitObject.GetComponent<Rigidbody>().isKinematic = false;
        }
       // Vector2 input = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
       // Debug.Log(input.x + "y " + input.y);


    }
}
