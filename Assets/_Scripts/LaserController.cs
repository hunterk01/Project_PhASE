using UnityEngine;
using System.Collections;

public class LaserController : MonoBehaviour
{

    LineRenderer line;
    public float kineticForce = 10;
    public float torqueForce = 10;
    public float laserMaxDistance = 100;
    Renderer renderer;
    ParticleSystem ps;
    ParticleSystem.EmissionModule em;
    public int gun = 1;
    public float mass = 0.01f;
    public float scale = 0.005f;
    public float scaleMin = 0.5f;
    public float scaleMax = 3.5f;
    public float massMin = 1;
    public float massMax = 30;
    public Vector3 tractorForce = new Vector3(1,1,1);
    public Light light;
    float distance;
    Transform jointedObject;
    FixedJoint jointedJoint;
    SpringJoint springyJoint;
    public float jointBreakForce = 1;
    public float springForce = 1;
    ObjectParameters objectParameters;
    //public Rigidbody player;

    // Use this for initialization
    void Start()
    {
        line = gameObject.GetComponent<LineRenderer>();
        line.enabled = false;
        renderer = gameObject.GetComponent<Renderer>();
        gameObject.GetComponent<Light>().enabled = false;
        ps = gameObject.GetComponent<ParticleSystem>();
        light = gameObject.GetComponent<Light>();
        
        //player = gameObject.GetComponent<Rigidbody>();
        em = ps.emission;
        em.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        FireLaser();
        GunSelection();
    }

    void FireGun()
    {
        switch (gun)
        {
            case 5:
                GrappleBeam();
                ;
                break;
            case 4:
                GravityBeam();
                ;
                break;
            case 3:
                TorqueBeam();
                ;
                break;
            case 2:
                MassBeam();
                ;
                break;
            case 1:
                KineticBeam();
                break;

        }
    }

    void GunSelection()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            gun = 1;
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            gun = 2;
        else if(Input.GetKeyDown(KeyCode.Alpha3))
            gun = 3;
        else if (Input.GetKeyDown(KeyCode.Alpha4))
            gun = 4;
        else if(Input.GetKeyDown(KeyCode.Alpha5))
            gun = 5;
    }

    void KineticBeam()
    {
        renderer.material.mainTextureOffset = new Vector2(0, Time.time);

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;


        line.SetPosition(0, ray.origin);
        

        if (Physics.Raycast(ray, out hit, laserMaxDistance))
        {
            line.SetPosition(1, hit.point);
            distance = (hit.point - ray.origin).magnitude;
            ps.startLifetime = distance;
            ps.startColor = Color.green;
            light.color = Color.green;

            objectParameters = hit.collider.gameObject.GetComponent<ObjectParameters>();
         
            if (hit.rigidbody && objectParameters.canKinetic)
            {
                if (Input.GetButton("Fire1"))
                {
                    hit.rigidbody.AddForceAtPosition(transform.forward * kineticForce, hit.point);
                }
                else if (Input.GetButton("Fire2"))
                {
                    hit.rigidbody.AddForceAtPosition(-transform.forward * 10, hit.point);
                }

            }
        }
        else
        {
            line.SetPosition(1, ray.GetPoint(laserMaxDistance));
        }

    }

    void MassBeam()
    {
        //min scale 0.5, max scale 3.5
        //min mass 1, max mass 30s
        renderer.material.mainTextureOffset = new Vector2(0, Time.time);

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;


        line.SetPosition(0, ray.origin);
        
        if (Physics.Raycast(ray, out hit, laserMaxDistance))
        {
            ObjectParameters OPScale;

            OPScale = hit.transform.GetComponent<ObjectParameters>();

            Vector3 scaleGovMax = new Vector3(OPScale.maxScale, OPScale.maxScale, OPScale.maxScale);
            Vector3 scaleGovMin = new Vector3(OPScale.minScale, OPScale.minScale, OPScale.minScale);

            line.SetPosition(1, hit.point);
            distance = (hit.point - ray.origin).magnitude;
            ps.startLifetime = distance;
            ps.startColor = Color.red;
            light.color = Color.red;

            objectParameters = hit.collider.gameObject.GetComponent<ObjectParameters>();

            if (hit.rigidbody && objectParameters.canMass)
            {
                if (Input.GetButton("Fire1"))
                {
                    hit.rigidbody.mass += mass;
                    hit.transform.localScale += new Vector3(scale, scale, scale);
                    if (hit.rigidbody.mass > objectParameters.maxMass)
                        hit.rigidbody.mass = objectParameters.maxMass;

                    if (hit.transform.localScale.y > objectParameters.maxScale)
                        hit.transform.localScale = scaleGovMax;
                }
                else if (Input.GetButton("Fire2"))
                {
                   hit.rigidbody.mass -= mass;
                   hit.transform.localScale -= new Vector3(scale, scale, scale);

                    if (hit.rigidbody.mass < objectParameters.minMass)
                        hit.rigidbody.mass = objectParameters.minMass;

                    if (hit.transform.localScale.y < objectParameters.minScale)
                    hit.transform.localScale = scaleGovMin;
                }

            }
        }
        else
        {
            line.SetPosition(1, ray.GetPoint(laserMaxDistance));
        }
    }

    void TorqueBeam()
    {
        renderer.material.mainTextureOffset = new Vector2(0, Time.time);

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;


        line.SetPosition(0, ray.origin);
       

        if (Physics.Raycast(ray, out hit, laserMaxDistance))
        {
            Rigidbody rb = hit.rigidbody;
            line.SetPosition(1, hit.point);
            distance = (hit.point - ray.origin).magnitude;
            ps.startLifetime = distance;
            ps.startColor = Color.yellow;
            light.color = Color.yellow;

            objectParameters = hit.collider.gameObject.GetComponent<ObjectParameters>();

            if (hit.rigidbody && objectParameters.canTorque)
            {
                if (Input.GetButton("Fire1"))
                {
                    rb.AddRelativeTorque(Vector3.up * torqueForce);
                }
                else if (Input.GetButton("Fire2"))
                {
                    rb.AddRelativeTorque(-Vector3.up * torqueForce);
                }
                //else if (Input.GetButton("Fire1") && Input.GetButton("Shift"))
                //{
                //    rb.AddRelativeTorque(Vector3.right * laserForce);
                //}
                //else if (Input.GetButton("Fire2") && Input.GetButton("Shift"))
                //{
                //    rb.AddRelativeTorque(-Vector3.right * laserForce);
                //}

            }
        }
        else
        {
            line.SetPosition(1, ray.GetPoint(laserMaxDistance));
        }
    }

    void GravityBeam()
    {
        renderer.material.mainTextureOffset = new Vector2(0, Time.time);

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;


        line.SetPosition(0, ray.origin);
        

        // attempt to pickup
        if (Physics.Raycast(ray, out hit, laserMaxDistance))
        {
            line.SetPosition(1, hit.point);
            distance = (hit.point - ray.origin).magnitude;
            ps.startLifetime = distance / 5;
            ps.startColor = Color.blue;
            light.color = Color.blue;

            objectParameters = hit.collider.gameObject.GetComponent<ObjectParameters>();

            if (hit.rigidbody && !jointedObject && objectParameters.canGravity)
            {
                Vector3 lastHit = hit.point;

                if (Input.GetButton("Fire1") || Input.GetButton("Fire2"))
                {

                    distance = (hit.point - ray.origin).magnitude;

                    jointedObject = hit.collider.gameObject.transform;
                    jointedJoint = jointedObject.gameObject.AddComponent<FixedJoint>();                  
                    jointedJoint.connectedBody = GetComponent<Rigidbody>();
                    jointedJoint.autoConfigureConnectedAnchor = true;
                    jointedJoint.breakForce = jointBreakForce;
                }
                                  
            }
        }
        else
        {
            line.SetPosition(1, ray.GetPoint(laserMaxDistance));

        }

    }

    void GrappleBeam()
    {
        renderer.material.mainTextureOffset = new Vector2(0, Time.time);

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;


        line.SetPosition(0, ray.origin);
   

        if (Physics.Raycast(ray, out hit, laserMaxDistance))
        {
            Rigidbody rb = hit.rigidbody;
            line.SetPosition(1, hit.point);
            distance = (hit.point - ray.origin).magnitude;
            ps.startLifetime = distance / 2;

            if (hit.rigidbody)
            {
                if (Input.GetButton("Fire1"))
                {

                     //player.AddForce(transform.forward * kineticForce, ForceMode.Acceleration);
                    
                }
                else if (Input.GetButton("Fire2"))
                {
                   
                }

            }
        }
        else
        {
            line.SetPosition(1, ray.GetPoint(laserMaxDistance));
        }
    }

    void FireLaser()
    {
        if (Input.GetButton("Fire1") || Input.GetButton("Fire2"))
        {
            line.enabled = true;
            gameObject.GetComponent<Light>().enabled = true;
            em.enabled = true;
           
            FireGun();
        }
        else
        {
            line.enabled = false;
            gameObject.GetComponent<Light>().enabled = false;
            em.enabled = false;
            ps.Clear();

            if(jointedObject)
            {
                
                Destroy(jointedObject.gameObject.GetComponent<FixedJoint>());
                Destroy(gameObject.GetComponent<FixedJoint>());
                Destroy(jointedObject.gameObject.GetComponent<SpringJoint>());
                Destroy(gameObject.GetComponent<SpringJoint>());

                jointedObject = null;
            }
        }

    }
}