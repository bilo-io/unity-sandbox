using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunInventory : MonoBehaviour
{
    [SerializeField]
    private GunSystem[] guns;

    [SerializeField]
    private int activeIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        activeIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        WeaponSwitcher();
    }

    void WeaponSwitcher()
    {

        // Pick new weapon
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetWeaponActive(false);
            activeIndex = 0;
            SetWeaponActive(true);
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetWeaponActive(false);
            activeIndex = 1;
            SetWeaponActive(true);
        }

        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetWeaponActive(false);
            activeIndex = 2;
            SetWeaponActive(true);
        }

        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            SetWeaponActive(false);
            activeIndex = 3;
            SetWeaponActive(true);
        }
        // Enable new weapon
    }

    void SetWeaponActive(bool isActive)
    {
        var weapon = guns[activeIndex];
        if(weapon) {
            weapon.gameObject.SetActive(isActive);
        }
    }
}
