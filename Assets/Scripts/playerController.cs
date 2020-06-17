using UnityEngine;

namespace Player
{
    public class playerController : MonoBehaviour
    {
        private Animator animatorPlayer;
        private float speed;
        private Vector3 scale;
        private BoxCollider2D collider;

        private void Start()
        {
            scale = transform.localScale;
            animatorPlayer = GetComponent<Animator>();
            collider = GetComponent<BoxCollider2D>();
        }
        private void Update()
        {
            speed = Input.GetAxisRaw("Horizontal");
            animatorPlayer.SetFloat("Speed", Mathf.Abs(speed));
            if (speed < 0)
            {
                scale.x = -1f * Mathf.Abs(scale.x);
                transform.localScale = scale;
            }
            else if (speed > 0)
            {
                scale.x = Mathf.Abs(scale.x);
                transform.localScale = scale;
            }

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                //play corch animation
                collider.offset = new Vector2(-0.05f , 0.5f);
                collider.size = new Vector2(0.7f, 1.2f);
                animatorPlayer.SetBool("Crouch", true);
            }
            else if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                //stop corch animation
                collider.offset = new Vector2(0f, 1f);
                collider.size = new Vector2(0.5f, 2f);
                animatorPlayer.SetBool("Crouch", false);
            }
        }
    }
}