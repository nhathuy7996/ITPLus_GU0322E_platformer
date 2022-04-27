using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    Rigidbody2D Rigi;

    [SerializeField] float jumpForce;
    [SerializeField] float speed;

    [SerializeField]
    bool isGround = false, isOnSlope = false;

    [SerializeField] PhysicsMaterial2D[] friction;

    [SerializeField] Vector2 slopeForce;

    [SerializeField] PLAYER_STATE playerState = PLAYER_STATE.IDLE;

    public enum PLAYER_STATE
    {
        IDLE,
        WALK,
        FALL,
        JUMP
    }

  
    // Start is called before the first frame update
    void Start()
    {
        Rigi = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        move();
        UpdateState();

        isOnSlope = slopeCheck();

    }

    void move()
    {

        if (isOnSlope && isGround)
        {
            Rigi.AddForce(slopeForce);
        }

        Vector2 movement = Vector2.zero;

        movement.x = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        movement.y = Rigi.velocity.y;

        if (isOnSlope)
        {
            if (movement.x != 0)
                Rigi.sharedMaterial = friction[0];
            else
                Rigi.sharedMaterial = friction[1];

        }

        Rigi.velocity = movement;

        if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
        {
            if (isOnSlope)
                Rigi.AddForce(new Vector2(0, jumpForce * 5));
            else
                Rigi.AddForce(new Vector2(0, jumpForce));
        }
    }


    void UpdateState()
    {
        if (isGround)
        {
            if (Rigi.velocity.x != 0)
            {
                playerState = PLAYER_STATE.WALK;

            }
            else
            {
                playerState = PLAYER_STATE.IDLE;
            }
        }
        else
        {

            if(Rigi.velocity.y >= 0)
                playerState = PLAYER_STATE.JUMP;
            else
                playerState = PLAYER_STATE.FALL;

        }
    }


    bool slopeCheck()
    {

        if (!isGround)
        {
            return false;
        }

        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.down,10);

        Debug.DrawRay(this.transform.position, Vector2.down, Color.red);

        if (hit.collider == null)
        {
            return false;
        }

        Debug.DrawRay(hit.point, hit.normal, Color.yellow);

        if (hit.normal == Vector2.up)
        {
            return false;
        }

        return true;
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        isGround = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGround = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGround = false;
    }
}
