using UnityEngine;

namespace Player
{
    public class playerController : MonoBehaviour
    {
        private Animator animatorPlayer;
        private new BoxCollider2D collider;
        private new Rigidbody2D rigidbody;
        private bool isCrouch;
        private Vector3 scale;
        public Vector2 minColliderOffset, minColliderSize, maxColliderOffset , maxColliderSize;
        public float speed , Jump;

        private void Start()
        {
            scale = transform.localScale;
            animatorPlayer = GetComponent<Animator>();
            rigidbody = GetComponent<Rigidbody2D>();
            collider = GetComponent<BoxCollider2D>();
        }
        private void Update()
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Jump");
            PlayerMove(horizontalInput , verticalInput);
            PlayerAnimation(horizontalInput, verticalInput);
        }
        private void PlayerAnimation(float horizontal , float vertical)
        {
            animatorPlayer.SetFloat("Speed", Mathf.Abs(horizontal));
            if (horizontal < 0)
            {
                scale.x = -1f * Mathf.Abs(scale.x);
                transform.localScale = scale;
            }
            else if (horizontal > 0)
            {
                scale.x = Mathf.Abs(scale.x);
                transform.localScale = scale;
            }
            if (vertical > 0)
            {
                animatorPlayer.SetBool("Jump", true);
            }
            else
            {
                animatorPlayer.SetBool("Jump", false);
            }
        }
        private void PlayerMove(float horizontal, float vertical)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                //play corch animation
                isCrouch = true;
                collider.offset = minColliderOffset;
                collider.size = minColliderSize;
                animatorPlayer.SetBool("Crouch", true);
            }
            else if(Input.GetKeyUp(KeyCode.LeftControl))
            {
                collider.offset = maxColliderOffset;
                collider.size = maxColliderSize;
                animatorPlayer.SetBool("Crouch", false);
                isCrouch = false;
            }
            else if (vertical > 0)
            {
               rigidbody.AddForce(Vector2.up * Jump, ForceMode2D.Force);
            }
            else if (horizontal > 0 || horizontal < 0)
            {
                if(!isCrouch)
                {
                  Vector3 position = transform.position;
                  position.x += horizontal * speed * Time.deltaTime;
                  transform.position = position;
                }
            }
        }
    }
}