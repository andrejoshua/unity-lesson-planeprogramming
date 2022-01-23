using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    [SerializeField]
    public float Speed;

    private const float TiltSpeed = 70.0f;
    private float _verticalInput;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // get the user's vertical input
        _verticalInput = GetKeyHold();
        Debug.Log($"CONTROL_INPUT_VERTICAL: {_verticalInput.ToString(CultureInfo.CurrentCulture)}");
        
        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * Time.deltaTime * Speed);

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Vector3.right, _verticalInput * TiltSpeed * Time.deltaTime);
    }

    private float GetKeyHold()
    {
        var input = Input.GetAxis("Vertical");
        if (input != 0) return input;

        Debug.Log($"CONTROL_INPUT_KEYUP: {Input.GetKey(KeyCode.UpArrow).ToString(CultureInfo.CurrentCulture)}");
        
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            return -1;
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            return 1;
        }
        
        Debug.Log($"CONTROL_INPUT_DOWN_KEYUP: {Input.GetKeyDown(KeyCode.UpArrow).ToString(CultureInfo.CurrentCulture)}");

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            return -1;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            return 1;
        }
        
        return 0;
    }
}
