using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Common.Scripts
{
    public class BasicCharacter : MonoBehaviour
    {



        #region Constants

        public Transform attackPoint;
        public float attackRange = 0.7f;
        public LayerMask enemyLayers;
        public int attackDamage = 20;
        public float attackRate = 2f;

        float nextAttackTime = 0f;
        public Slider PlayerLife;

        private static readonly int WALK_PROPERTY = Animator.StringToHash("Walk");

        #endregion


        #region Inspector

        [SerializeField]
        private float speed = 20;

        [Header("Relations")]
        [SerializeField]
        private Animator animator = null;

        [SerializeField]
        private Rigidbody physicsBody = null;

        [SerializeField]
        private SpriteRenderer spriteRenderer = null;

        public GameObject player;
        #endregion


        #region Fields

        private Vector3 _movement;

        #endregion


        #region MonoBehaviour

        private void Update()
        {
            StartCoroutine(CounterLife());
            // Vertical
            float inputY = 0;
            if (Input.GetKey(KeyCode.UpArrow))
                inputY = 1;
            else if (Input.GetKey(KeyCode.DownArrow))
                inputY = -1;

            // Horizontal
            float inputX = 0;
            if (Input.GetKey(KeyCode.RightArrow))
            {
                inputX = 1;
                spriteRenderer.flipX = false;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                inputX = -1;
                spriteRenderer.flipX = true;
            }

            // Normalize
            _movement = new Vector3(inputX, 0, inputY).normalized;

            animator.SetBool(WALK_PROPERTY,
                             Math.Abs(_movement.sqrMagnitude) > Mathf.Epsilon);

            // attack
            if (Time.time >= nextAttackTime)
            {
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    Attack();
                    nextAttackTime = Time.time + 1f / attackRate;
                }
                if (Input.GetKeyUp(KeyCode.Z))
                {
                    animator.SetBool("Attack", false);
                }
            }

        }

        private void FixedUpdate()
        {
            physicsBody.velocity = _movement * speed;
        }

        #endregion


        void Attack()
        {

            //Play attack animation
            animator.SetBool("Attack", true);
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Enemy")
            {
                PlayerLife.value--;

                animator.SetBool("Hurt", true);

                if (PlayerLife.value == 0)
                {
                    animator.Play("Death");
                }
            }
            animator.SetBool("Hurt", false);

        }

        IEnumerator CounterLife()
        {
            if (PlayerLife.value == 0)
            {
                yield return new WaitForSeconds(4);
                SceneManager.LoadScene("Over");
                Destroy(player);
            }

        }
    }
  }



