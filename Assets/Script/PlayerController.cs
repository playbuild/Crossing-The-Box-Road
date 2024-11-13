
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    private Vector2 curMovementInput;
    public Animator animator;
    public GameObject GameOver;

    public AudioClip[] footstepClips;
    private AudioSource audioSource;
    private Rigidbody _rigidbody;
    public float footstepThreashold;
    public float footstepRate;
    private float footStepTime;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Move();

        if (Mathf.Abs(_rigidbody.velocity.y) < 0.1f)
        {
            if (_rigidbody.velocity.magnitude > footstepRate)
            {
                if (Time.time - footStepTime > footstepRate)
                {
                    footStepTime = Time.time;
                    audioSource.PlayOneShot(footstepClips[Random.Range(0, footstepClips.Length)]);
                }
            }
        }
    }
    void Move()
    {
        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
        dir *= moveSpeed;
        dir.y = _rigidbody.velocity.y;

        _rigidbody.velocity = dir;
        //������ �̵��� ������ �Լ�
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            curMovementInput = context.ReadValue<Vector2>();
            //�̵� Ű�� ������ ������ �̵��ϵ��� ��� �Է½�����
            animator.SetBool("Walk", true);
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;
            animator.SetBool("Walk", false);
            //�̵� Ű ���� ���̻� �νĵ��� ������ �̵����� �ʰ� ����
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            animator.SetTrigger("Crash");
            GameOver.SetActive(true);
            SoundManager.Instance.PlayEffect(SoundManager.SoundEffect.EffectCrash);
            Time.timeScale = 0.0f;
        }
        else if (collision.gameObject.CompareTag("Coin"))
        {
            SoundManager.Instance.PlayEffect(SoundManager.SoundEffect.EffectCoin);
        }
    }

}
