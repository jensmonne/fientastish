using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Gun_Aimer : MonoBehaviour
{
    [SerializeField] private Image Crosshair;
    [SerializeField] private Image Bullet;

    void Update()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();
        mousePos.z = 10f;

        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
        //transform.LookAt(worldMousePos);

        if (Crosshair != null)
        {
            Crosshair.transform.position = mousePos;
        }

        //Click to shoot at cursor position
        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (Bullet != null)
        {
            //Instantiate a bullet at the gun's position and shoot it towards the mouse position
            GameObject bullet = Instantiate(Bullet.gameObject, transform.position, Quaternion.identity);
            Vector3 direction = (Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()) - transform.position).normalized;
            bullet.GetComponent<Rigidbody2D>().linearVelocity = direction * 10f; //speed
        }
        
    }
}