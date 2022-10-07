using JetBrains.Annotations;
using System.Collections;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private int playerIndex;
    public float cooldownTime = 2;
    private float canShoot = 0;
    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask crossHair = new LayerMask();
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firePoint;
    private Vector3 mousePosition = Vector3.zero;

    public void Update()
    {
        Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
        Ray ray = cam.ScreenPointToRay(screenCenter);

        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, crossHair))
        {
            mousePosition = raycastHit.point;
        } 

        if (TurnManager.GetInstance().PlayerIsActive(playerIndex))
        {
            Shoot();
        }
    }
    public void Shoot()
    {
        if (Time.time > canShoot)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Vector3 aimDir = (mousePosition - firePoint.position).normalized;
                Instantiate(projectilePrefab, firePoint.position, Quaternion.LookRotation(aimDir, Vector3.up));
                canShoot = Time.time + cooldownTime;
            }
        }
    }
}
