using UnityEngine;

public class Gunsmith : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player._currentWeapon = _weapon;
            Destroy(gameObject);
        }
    }

}
