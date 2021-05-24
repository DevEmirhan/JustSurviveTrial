using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Space(10)] [Header("Bindings")]
    [SerializeField] private GameObject playerModel;
    [SerializeField] private Rigidbody myRb;
    [SerializeField] private Joystick joystick;
    [SerializeField] private Animator playerAnim;
    [SerializeField] private GameObject walkIndicator;
    [HideInInspector] public int keyRequirement;
    [HideInInspector] public bool isCollectedKeys = false;

    [Space(10)][Header("Arrangements")]
    [SerializeField] private float speedNormal;
    [SerializeField] private float speedBoosted;
    [SerializeField] private float boostDuration;

    private float playerSpeed;
    private bool IsActive;
    private int collectedKeyCount;
    private bool cameraZoomed;

    private void Start()
    {
        Initialize(); 
    }

    public void Initialize()
    {
        playerSpeed = speedNormal;
    }

    public void StartGame(int keyCount)
    {
        IsActive = true;
        playerSpeed = speedNormal;
        myRb.isKinematic = false;
        keyRequirement = keyCount;
    }

    public void SetPlayerPosition(Vector3 pos, Quaternion rot)
    {
        myRb.transform.position = pos;
        myRb.transform.rotation = rot;
    }

    public void GameOver()
    {
        //agent.GameOver();
    }

    public void Reload()
    {
        //agent.gameObject.SetActive(false);
        playerAnim.Rebind();
        collectedKeyCount = 0;
        playerAnim.speed = 1f;
        myRb.isKinematic = true;
        IsActive = false;
        isCollectedKeys = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsActive)
        {
            return;
        }

        //Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        if(joystick.Direction.magnitude != 0)
        {
            playerAnim.SetBool("IsRunning", true);
            transform.forward = new Vector3(joystick.Direction.x, 0, joystick.Direction.y);
            walkIndicator.transform.position = new Vector3(transform.position.x + joystick.Direction.x/2f, walkIndicator.transform.position.y, transform.position.z + joystick.Direction.y/2f);
            myRb.MovePosition(myRb.position + (transform.forward.normalized * Time.deltaTime * playerSpeed));
            if (cameraZoomed)
            {
                cameraZoomed = false;
                CameraManager.Instance.DoZoomIn();
            }

        } else
        {
            playerAnim.SetBool("IsRunning", false);
            myRb.velocity = Vector3.zero;
            walkIndicator.transform.position = new Vector3(transform.position.x, walkIndicator.transform.position.y, transform.position.z);
            if (!cameraZoomed)
            {
                cameraZoomed = true;
                CameraManager.Instance.DoZoomOut();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (IsActive)
        {
            if(other.gameObject.tag == "Key")
            {
                Destroy(other.gameObject);
                CheckKeyCount();
            } else if(other.gameObject.tag == "Speed")
            {
                Destroy(other.gameObject);
                StartCoroutine(SpeedBoost());
            } else if(other.gameObject.tag == "Trap")
            {
                StartCoroutine(DeathSequence("Dead"));
            } else if (other.gameObject.tag == "Death")
            {
                //Might be ragdoll death
                StartCoroutine(DeathSequence("Dead"));
            } else if(other.gameObject.tag == "Hole")
            {
                other.GetComponent<BlackHole>().PlayerCatched();
                StartCoroutine(DeathSequence("Dead3")); 
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (IsActive)
        {
            if(collision.gameObject.tag == "Death")
            {
                StartCoroutine(DeathSequence("Dead"));
            }
        }
    }
    private void CheckKeyCount()
    {
        collectedKeyCount++;
        UIManager.Instance.UpdateKeys();
        if (collectedKeyCount == keyRequirement)
        {
            StartCoroutine(WinSequence());
        }
    }
    public void TimesUp()
    {
        StartCoroutine(DeathSequence("Crying"));
    }
    IEnumerator SpeedBoost()
    {
        playerSpeed = speedBoosted;
        playerAnim.speed *= 1.5f;
        yield return new WaitForSeconds(boostDuration);
        playerSpeed = speedNormal;
        playerAnim.speed /= 1.5f;
    }
    IEnumerator DeathSequence(string animStyle)
    {
        IsActive = false;
        playerAnim.Play(animStyle);
        yield return new WaitForSeconds(3f);
        GameManager.Instance.GameOver();
    }
    IEnumerator WinSequence()
    {
        IsActive = false;
        isCollectedKeys = true;
        playerAnim.Play("Dance");
        yield return new WaitForSeconds(3f);
        GameManager.Instance.WinGame();
    }
}
 