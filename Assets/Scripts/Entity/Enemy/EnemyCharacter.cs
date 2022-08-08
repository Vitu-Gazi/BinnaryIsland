using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : MonoBehaviour, IDamagable
{
    [SerializeField] private Bonus bonus;
    [SerializeField] [Range(0, 1f)] private float percent;
    [SerializeField] private int pointForDie = 200;

    public void GetDamage()
    {
        Score.Instance.AddScore(pointForDie);

        if (Random.value <= percent)
        {
            Instantiate(bonus, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
