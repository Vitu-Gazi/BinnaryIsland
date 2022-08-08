using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer : MonoBehaviour
{
    [SerializeField] protected EntityState playerState;
    [SerializeField] private GameObject attackZone;
    [SerializeField] private bool negativeDirectionX;
    [SerializeField] private bool negativeDirectionY;

    private Vector3 direction = new Vector3(1, 0, 0);

    private void Start()
    {
        InputRegister.Instance.MovePlayer += SetDirection;
        InputRegister.Instance.Shooting += Shoot;
    }
    private void OnDisable()
    {
        InputRegister.Instance.MovePlayer -= SetDirection;
        InputRegister.Instance.Shooting -= Shoot;
    }

    private void SetDirection(Vector3 direction)
    {
        if (direction.x == 0 && direction.y == 0)
        {
            return;
        }

        this.direction.x = !negativeDirectionX ? direction.x : (direction.x * -1);
        this.direction.y = !negativeDirectionY ? direction.y : (direction.y * -1);
        attackZone.transform.localPosition = Vector3.zero + this.direction;
    }

    private void Shoot (float state)
    {
        if (playerState.State == CharacterState.NONACTIVE)
        {
            return;
        }

        attackZone.SetActive(state != 0 ? true : false);
    }
}
