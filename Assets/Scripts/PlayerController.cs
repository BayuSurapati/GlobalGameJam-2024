using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] AudioClip bulletShotEffects;

    public Rigidbody2D playerRB;
    public float playerMoveSpeed;
    public float playerJumpForce;

    public Transform groundPoint;
    public bool isOnGround;
    private bool isRunning;
    public bool isGunReady;
    public LayerMask whatIsGround;

    public BulletController shotToFire;
    public Transform shotPoint;

    public Animator playerAnim;

    public string sceneSpeed, sceneRoket, sceneHomeUFO2;

    public GameObject portalOn;
    public GameObject portalOff;

    public GameObject pause;

    public int bulletMaxAmount;
    public int bulletCurrentAmount;

    public TMP_Text bulletText;

    private AudioSource sourceWeaponShoot;
    public AudioClip clipWeaponShoot;

    // Start is called before the first frame update
    void Start()
    {
        isRunning = true;
        bulletCurrentAmount = bulletMaxAmount;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Speedrun")
        {
            SceneManager.LoadScene(sceneSpeed);
        }

        if (other.gameObject.tag == "Jetpack")
        {
            SceneManager.LoadScene(sceneRoket);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Plug")
        {
                Destroy(other.gameObject);
                portalOn.SetActive(true);
                portalOff.SetActive(false);
                //AudioSource.PlayClipAtPoint(heartPickupEffects, Camera.main.transform.position);
        }
        if(other.tag == "Portal1")
        {
            SceneManager.LoadScene(sceneHomeUFO2);
        }
    }

    public void PlayerMovement()
    {
        if (isRunning)
        {
            playerRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * playerMoveSpeed, playerRB.velocity.y);
            AudioManager.instance.playSFX(8);
            if (playerRB.velocity.x < 0)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            else if (playerRB.velocity.x > 0)
            {
                transform.localScale = Vector3.one;
            }
        }
        else
        {
            playerRB.velocity = Vector2.zero;
        }

        isOnGround = Physics2D.OverlapCircle(groundPoint.position, .2f, whatIsGround);

        if (Input.GetButtonDown("Jump") && isOnGround == true)
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, playerJumpForce);
            AudioManager.instance.playSFX(5);
        }

        if (Input.GetMouseButtonDown(0) && playerRB.velocity== Vector2.zero && bulletCurrentAmount != 0)
        {
            bulletCurrentAmount -= 1;
            bulletText.text = bulletCurrentAmount.ToString();
            Instantiate(shotToFire, shotPoint.position, shotPoint.rotation).moveDir = new Vector2(transform.localScale.x,0f);
            
            playerAnim.SetTrigger("shotFired");
            Debug.Log("fire");

            AudioManager.instance.playSFX(6);
        }
        bulletText.text = bulletCurrentAmount.ToString();
        playerAnim.SetBool("isOnGround", isOnGround);
        playerAnim.SetFloat("speed",Mathf.Abs(playerRB.velocity.x));
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pause.SetActive(false);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
