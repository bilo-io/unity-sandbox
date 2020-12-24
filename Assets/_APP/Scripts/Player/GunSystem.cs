using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunSystem : MonoBehaviour
{
    [Header("Gun Stats")]
    public float damage;
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public bool allowButtonHold;

    [Header("Bullets ")]
    public int magazineSize, bulletsPerTap;
    [SerializeField]
    int bulletsLeft, bulletsShot;
    [SerializeField]
    private GameObject bulletWholeGraphic;
    public AudioSource shotSound;

    // TODO: hide
    [Header("States")]
    [SerializeField]
    private bool shooting, readyToShoot, reloading;

    public Camera fpsCam;
    public Transform attackPoint;
    public GameObject attackGameObject;
    public RaycastHit raycastHit;
    public LayerMask whatIsEnemy;

    [Header("UI")]
    public TextMeshProUGUI ammoCount;


    void Start()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
        fpsCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
        UpdateAmmoCount();
    }

    void UpdateAmmoCount()
    {
        ammoCount.SetText(bulletsLeft + " / " + magazineSize);
    }

    void PlayerInput()
    {
        if(allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        // Reloading
        if(Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) Reload();

        // Shooting
        if(readyToShoot && shooting && !reloading && bulletsLeft > 0) {
            bulletsShot = bulletsPerTap;
            Shoot();
        }
    }

    void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

    void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }

    void Shoot()
    {
        readyToShoot = false;

        // spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);
        Vector3 direction = fpsCam.transform.forward + new Vector3(x, y, 0);

        // Raycast
        if(Physics.Raycast(fpsCam.transform.position, direction, out raycastHit, range, whatIsEnemy))
        {
            Debug.Log($"Shoot collision: {raycastHit.collider.tag}");

            if(raycastHit.collider.tag == "Enemy") {
                Debug.Log("Hit Enemy ... apply damage logic");
                // raycastHit.collider.GetComponent<ShootingAi>().TakeDamage(damage)
            }

            Debug.Log("Hit Collider: " + raycastHit.collider.tag);
        }

        attackGameObject = Instantiate(bulletWholeGraphic, raycastHit.point, Quaternion.Euler(0,180,0));

        bulletsLeft--;
        bulletsShot--;
        shotSound.Play();
        Invoke("ResetShot", timeBetweenShooting);

        if(bulletsShot > 0 && bulletsLeft > 0) {
            Invoke("Shoot", timeBetweenShots);
        }
    }

    void ResetShot()
    {
        readyToShoot = true;
    }
}
