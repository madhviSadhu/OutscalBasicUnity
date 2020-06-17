using UnityEngine;

namespace Player
{
    public class playerController : MonoBehaviour
    {
        private Animator animatorPlayer;
        private float speed;
        private Vector3 scale;

        private void Start()
        {
            scale = transform.localScale;
            animatorPlayer = GetComponent<Animator>();
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
        }
    }
}