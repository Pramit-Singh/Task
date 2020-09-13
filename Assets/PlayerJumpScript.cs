using Photon.Pun;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerJumpScript : MonoBehaviourPun
{

    public float jumpForce;
    public Material redPlayer;
    public Material greenPlayer;

    Rigidbody rigidbody;

    private void Awake()
    {
        if (photonView.IsMine)
        {
            print("MY");
            gameObject.GetComponent<PlayerJumpScript>().enabled = true;
            gameObject.GetComponent<TouchManagerScript>().enabled = true;
            gameObject.GetComponent<Renderer>().material = redPlayer;
        }
        else
        {
            gameObject.tag = "Untagged";
            gameObject.GetComponent<TouchManagerScript>().enabled = false;
            gameObject.GetComponent<Renderer>().material = greenPlayer;
            gameObject.GetComponent<PlayerJumpScript>().enabled = false;
        }
    }
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void JumpPlayer()
    {
        rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }


    public void Movement(string str)
    {
        switch (str)
        {
            case "Left":
                print("Left");
                transform.position += Vector3.left * Time.deltaTime;
                break;
            case "Right":
                print("Right");
                transform.position += Vector3.right * Time.deltaTime;
                break;
            default:
                print("default");
                break;
        }
    }
}
