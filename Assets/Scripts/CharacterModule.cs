using UnityEngine;
using UnityEngine.UI;

public class CharacterModule : MonoBehaviour
{
    public Rigidbody2D rigid = null;
    public float runSpeed = 1f;
    public float jumpPower = 10f;
    public CircleCollider2D bottomCollider = null;
    public Text coinCountText = null;
    public int coinCount = 0;

    private bool isJumping = false;
    private int jumpCount = 1;

    private void AddCoin()
    {
        coinCount++;
        coinCountText.text =
            string.Format("Coin : {0}", coinCount.ToString());
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (!isJumping)
            {
                isJumping = true;
                bottomCollider.enabled = false;
                rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            }
            else if (jumpCount > 0)
            {
                jumpCount--;
                rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            }
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.right * runSpeed * Time.fixedDeltaTime);

        if (rigid.velocity.y < 0f)
        {
            bottomCollider.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tiles"))
        {
            bottomCollider.enabled = false;
            isJumping = false;

            jumpCount = 1;
        }

        if (collision.CompareTag("Items"))
        {
            collision.enabled = false;
            Destroy(collision.gameObject);
            AddCoin();
        }
    }


}
