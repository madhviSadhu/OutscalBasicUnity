using UnityEngine;

namespace PlayerAnim
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimation : MonoBehaviour
    {
        private Animator animatorPlayer;
        private void Start()
        {
            animatorPlayer = GetComponent<Animator>();
        }
        private void Update()
        {
            
            if (Input.GetKeyDown(KeyCode.W))
            {
                //play run animation
                animatorPlayer.SetFloat("Speed", 1f);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                //play Idle animation
                animatorPlayer.SetFloat("Speed" , 0f);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                //play corch animation
                animatorPlayer.SetBool("Crouch", true);
            }
            else if (Input.GetKeyUp(KeyCode.D))
            {
                //stop corch animation
                animatorPlayer.SetBool("Crouch", false);
            }
        }
    }
}