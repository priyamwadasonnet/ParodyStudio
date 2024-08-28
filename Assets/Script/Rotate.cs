using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private Transform character; // Reference to the character's transform
    [SerializeField] private Transform holoBody; // Reference to the holo body's transform
    [SerializeField] private float rotationSpeed = 10f; // Adjust the rotation speed as needed

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Calculate the direction vector from the character to the holo body
            Vector3 direction = holoBody.position - character.position;
            direction.y = 0f; // Ignore the Y-axis for horizontal rotation

            // Calculate the target rotation
            Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);

            // Rotate the character towards the target rotation
            character.rotation = Quaternion.Slerp(character.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}