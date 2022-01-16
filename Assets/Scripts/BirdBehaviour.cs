using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBehaviour : MonoBehaviour
{
    public float force_;
    public float gravity_value_;
    public float space_pressed_threshold_ = 0.2f;

    private bool space_pressed_;
    private float press_time_;
    private Rigidbody rb_;

    private void Awake()
    {
        rb_ = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!space_pressed_ && Input.GetKeyDown(KeyCode.Space))
        {
            press_time_ = Time.time;
            space_pressed_ = true;
        }

        if (Input.GetKeyUp(KeyCode.Space) || Time.time - press_time_ >= space_pressed_threshold_)
        {
            space_pressed_ = false;
        }

        // This only works if a collisions make the object inactive, disable this when debugging or Exceptions will be produced.
        /*
        if (gameObject.transform.position.x != 0 || gameObject.transform.position.z != 0) {
            gameObject.transform.Translate(-gameObject.transform.position.x, 0.0f, -gameObject.transform.position.z);
        }
        */

        //Debug.Log("Y: " + gameObject.transform.position.y);
    }

    void FixedUpdate()
    { 
        rb_.AddForce(0.0f, -gravity_value_, 0.0f, ForceMode.Impulse);

        if (space_pressed_) {
            rb_.AddForce(0.0f, force_ * 0.1f, 0.0f, ForceMode.VelocityChange);
        }
    }
}
