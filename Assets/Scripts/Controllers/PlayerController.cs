using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool IsActive;

    [SerializeField]
    private GameObject playerModel;
    //[SerializeField]
    //private PlayerCamera cam;

    //If there is a free play
    public float speed;
    [SerializeField]
    private Rigidbody myRb;
    [SerializeField]
    private Joystick joystick;
    [SerializeField]
    private Animator playerAnim;

    private int collectedCoinCount;

    private void Start()
    {
        Initialize(); 
    }

    public void Initialize()
    {

    }

    public void StartGame()
    {
        //PlayerAccount.Module.Refresh();
        IsActive = true;
        myRb.isKinematic = false;
        //agent.gameObject.SetActive(true);
        //agent.StartGame();
        //cam.StartGame();
    }

    public void SetPlayerPosition(Vector3 pos)
    {
        myRb.transform.position = pos;
    }

    public void GameOver()
    {
        IsActive = false;
        //agent.GameOver();
    }

    public void Reload()
    {
        //agent.gameObject.SetActive(false);
        myRb.isKinematic = true;
        IsActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsActive)
        {
            return;
        }
        Debug.Log(joystick.Direction.magnitude);
        //Controls
        //float horizontal = Input.GetAxisRaw("Horizontal");
        //float vertical = Input.GetAxisRaw("Vertical");

        //Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        if(joystick.Direction.magnitude != 0)
        {
            playerAnim.SetBool("isRunning", true);
            transform.forward = new Vector3(joystick.Direction.x, 0, joystick.Direction.y);
            myRb.MovePosition(myRb.position + (transform.forward.normalized * Time.deltaTime * speed));

        } else
        {
            playerAnim.SetBool("isRunning", false);
        }

    }
}
