using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCollider : MonoBehaviour
{
    string status;
    Vector3 contact;
    Vector3 normal;
    [SerializeField] GameObject fx;

    private void OnCollisionEnter(Collision collision)
    {
        status = "Collision enter " + collision.gameObject.name;

        contact = collision.contacts[0].point;
        normal = collision.GetContact(0).normal;

        if (fx) Instantiate(fx,contact,Quaternion.LookRotation(normal));
    }
    private void OnCollisionStay(Collision collision)
    {
        status = "Collision stay " + collision.gameObject.name;

    }
    private void OnCollisionExit(Collision collision)
    {
        status = "Collision exit " + collision.gameObject.name;

    }
    private void OnTriggerEnter(Collider other)
    {
        status = "Trigger enter " + other.gameObject.name;
    }
    private void OnTriggerStay(Collider other)
    {
        status = "Trigger stay " + other.gameObject.name;

    }
    private void OnTriggerExit(Collider other)
    {
        status = "Trigger exit " + other.gameObject.name;

    }

    private void OnGUI()
    {
        GUI.skin.label.fontSize = 16;
        Vector2 screen = Camera.main.WorldToScreenPoint(transform.position);
        GUI.Label(new Rect(screen.x,Screen.height-screen.y,250,70),status);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(contact, 0.2f);
        Gizmos.DrawLine(contact, contact + normal);
    }
}
