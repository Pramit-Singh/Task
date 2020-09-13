using Photon.Pun;
using UnityEngine;


public class TouchManagerScript : MonoBehaviourPun
{
    public PlayerJumpScript playerJump;

    // Update is called once per frame
    void Update()
    {
        TouchControll();
    }

    void TouchControll()
    {
        if (Input.touchCount == 1)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.name);
                if (hit.collider != null)
                {
                    GameObject touchedObject = hit.transform.gameObject;

                    if (touchedObject.tag == "Player" && photonView.IsMine)
                    {
                        playerJump.JumpPlayer();
                    }
                }
            }
        }

        foreach (Touch touch in Input.touches)
        {
            if (touch.position.x < Screen.width / 2)
            {
                playerJump.Movement("Left");
            }
            else if (touch.position.x > Screen.width / 2)
            {
                playerJump.Movement("Right");
            }
        }
    }

  
}
