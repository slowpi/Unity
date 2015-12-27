using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}
public class PlayerController : MonoBehaviour {
    private Rigidbody rb;
    public float speed;
    public Boundary boundary;
    public float tilt;
    public GameObject shot;
    public Transform shopSpawn;
    public float fireRate;
    private float nextFire;
    private AudioSource audioSource;
    public SimpleTouchPad touchPad;
    public SimpleTouchAreaButton areaButton;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (areaButton.CanFire() && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shopSpawn.position, shopSpawn.rotation);
            audioSource.Play();

        }
    }
    void FixedUpdate()
    {
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");
        Vector2 direction = touchPad.GetDirection();
        //Debug.Log(direction);
        Vector3 movement = new Vector3(direction.x * speed, 0.0f, direction.y * speed);
        rb.velocity = movement;
        rb.position = new Vector3(Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax), 0.0f, Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax));
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }
}
