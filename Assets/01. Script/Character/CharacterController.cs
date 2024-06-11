using DG.Tweening;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveDistance = 1f; // �̵� �Ÿ�
    public float moveTime = 0.5f; // �̵� �ð�

    public float jumpDistance = 2f; // ���� ����
    public float jumpTime = 0.5f; // ���� �� ���� �������� �ð�

    private bool isMoving = false; // �̵� ���� ��
    private bool isJumping = false; // ���� ���� ��

    void Update()
    {
        // ���� ȭ��ǥ Ű�� ������ ��
        if (!isMoving && Input.GetKeyDown(KeyCode.LeftArrow)) 
        {
            MoveLeft();
        }

        // ������ ȭ��ǥ Ű�� ������ ��
        if (!isMoving && Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }

        // �����̽� �� Ű�� ������ ��
        if (!isJumping && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void MoveLeft()
    {
    // float canMove = totalmoveDistacne + moveDistance;
        if (transform.position.x > -1)
        {
            isMoving = true; // �̵� ����
            transform.DOMoveX(transform.position.x - moveDistance, moveTime). // position ������ �̵��Ÿ� ���� (�������� ���ϱ� x-)
                SetEase(Ease.Unset). // �̵� ���
                OnComplete(() => isMoving = false); // �̵� �� isMoving false ����
        }
    }

    void MoveRight()
    {
    // float canMove = totalmoveDistacne + moveDistance;
        if (transform.position.x < 1)
        {
            isMoving = true; // �̵� ����
            transform.DOMoveX(transform.position.x + moveDistance, moveTime). // position ������ �̵��Ÿ� ���� (���������� ���ϱ� x+)
                SetEase(Ease.Unset). // �̵� ���
                OnComplete(() => isMoving = false); // �̵� �� isMoving false ����
        }
    }

    void Jump()
    {
        isJumping = true; // ��������
        transform.DOMoveY(transform.position.y + jumpDistance, jumpTime).
            SetEase(Ease.Unset).
            OnComplete(() =>
            {
             // ���� �� ���� ��ġ�� ���ƿ�
             transform.DOMoveY(0, jumpTime).
             SetEase(Ease.InQuad).
             OnComplete(() => isJumping = false); // ���� �Ϸ� �� isJumping�� false�� ����
            }
         );
        AudioSource jumpSound = GetComponent<AudioSource>();
        jumpSound.Play();
    }
}
