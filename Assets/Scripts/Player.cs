using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rig;   //Character animation components
    private Animator ani;   // Character steel body components
    private Vector3 moveDir;  // Character movement vector
    private Vector3 faceDir;  // Character rotation vector
    private float horizontal;  // horizontal X-axis value
    private float vertical;  // horizontal Y-axis value
    private AudioSource audioSource;
    public bool isdead = false;
    private RaycastHit raycastHit;   // Save the emitted ray and return it to the content
    private RaycastHit monsterHit;

    public GameObject fx_fire;
    public AudioClip fire_music;
    public Transform fire_pos;


    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        ani = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("Shoot!");
            ani.SetTrigger("Shoot");
            Instantiate(fx_fire, fire_pos.position, fire_pos.rotation);
            audioSource.clip = fire_music;
            audioSource.Play();
            Ray ray = new Ray(fire_pos.position, fire_pos.forward);

            bool res = Physics.Raycast(ray, out monsterHit, 1000, 1 << LayerMask.NameToLayer("Enemy"));
            if (res)
            {
                print("hit:" + monsterHit.collider.name);
                monsterHit.collider.GetComponent<Animator>().SetTrigger("die");
                monsterHit.collider.GetComponent<Monster>().isdead = true;
            }
        }
    }
    private void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if (horizontal != 0 || vertical != 0)
        {
            //Character movement
            PlayerMove();
        }

        //Character animation control

        ani.SetFloat("x", horizontal);
        ani.SetFloat("y", vertical);

        //Character rotation
        PlayerRotate();
    }
    void PlayerMove()
    {
        moveDir = new Vector3(horizontal, 0, vertical);
        moveDir.Normalize();
        rig.MovePosition(transform.position + moveDir * 5 * Time.fixedDeltaTime);

    }
    void PlayerRotate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        bool result = Physics.Raycast(ray, out raycastHit, 1000, 1 << LayerMask.NameToLayer("floor"));

        if (result)
        {
            faceDir = raycastHit.point - transform.position;
            Quaternion dir = Quaternion.LookRotation(faceDir);
            rig.MoveRotation(dir);


        }
    }
}