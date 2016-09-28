using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerControls : MonoBehaviour {

    public GameObject playerCamera;
    public GameObject joystick;
    private Rigidbody rid;
    [Header("Player")]
    [SerializeField]
    float walkingSpeed = 150.0f;
    [SerializeField]
    float sprintSpeed = 300.00f;
    [SerializeField]
    float maxStamina = 10.0f;
    [SerializeField]
    float minimalNeedStamina = 4.0f;
    [Header("Joystick")]
    [SerializeField]
    bool joystickEnable = false;
    [SerializeField]
    float joystickSensitivity = 1;
    [SerializeField]
    float joystickSensitivityIdle = 1;
    [SerializeField]
    float joystickDeadZone= 0.2f;


    private float initialYAngle = 0f;
    private float appliedGyroYAngle = 0f;
    private float calibrationYAngle = 0f;
    enum PlayerState { idle, walk, sprint };
    private PlayerState myPlayerState = PlayerState.idle;
    private float currentStamina;
    private bool exhausted = false;
    private float hori;
    private float verti;
    private float currentJoystickSensitivity; 




    void Start()
    {
        rid = GetComponent<Rigidbody>();
        Input.gyro.enabled = true;
        Application.targetFrameRate = 60;
        initialYAngle = transform.eulerAngles.y;
        currentStamina = maxStamina;
    }

    void Update()
    {
        if (joystickEnable == false)
        {
            joystick.SetActive(false);
            ApplyGyroRotation();
            ApplyCalibration();
        }
        else
        {
            joystick.SetActive(true);
            useJoystick();
        }

        UpdatePlayerState();
        UpdatePlayerStamina();
    }

    void FixedUpdate()
    {

        if (myPlayerState == PlayerState.walk)        
            rid.velocity = playerCamera.transform.forward * walkingSpeed * Time.deltaTime;
        else if (myPlayerState == PlayerState.sprint)
            rid.velocity = playerCamera.transform.forward * sprintSpeed *Time.deltaTime;
        else if (myPlayerState == PlayerState.idle)
            rid.velocity = Vector3.zero;
        

     
    }

    private void UpdatePlayerState() {
        if (joystickEnable == false)
        {
            if (Input.touchCount == 1 || Input.touchCount > 1 && exhausted == true)
                myPlayerState = PlayerState.walk;
            else if (Input.touchCount > 1)
                myPlayerState = PlayerState.sprint;
            else
                myPlayerState = PlayerState.idle;
        }
        else
        {
            if (Input.touchCount == 2 || Input.touchCount > 2 && exhausted == true)
                myPlayerState = PlayerState.walk;
            else if (Input.touchCount > 2)
                myPlayerState = PlayerState.sprint;
            else
                myPlayerState = PlayerState.idle;
        }
    }

    private void UpdatePlayerStamina() {
        if (exhausted == true) {
            if (currentStamina <= minimalNeedStamina)
                currentStamina += Time.deltaTime;
            else
                exhausted = false;
        }
        else if (exhausted == false)
        {
            if (myPlayerState == PlayerState.idle || myPlayerState == PlayerState.walk)
            {
                if (currentStamina >= maxStamina)
                    currentStamina = maxStamina;
                else
                    currentStamina += Time.deltaTime;
            }
            else if (myPlayerState == PlayerState.sprint)
            {
                if (currentStamina <= 0)
                {
                    currentStamina = 0;
                    exhausted = true;
                }
                else
                    currentStamina -= Time.deltaTime;
            }
        }
    }
    public void useJoystick() {

        if (myPlayerState == PlayerState.idle)
            currentJoystickSensitivity = joystickSensitivityIdle;
        else
            currentJoystickSensitivity = joystickSensitivity;

        if (CrossPlatformInputManager.GetAxis("Horizontal") <= joystickDeadZone && CrossPlatformInputManager.GetAxis("Horizontal") >= -joystickDeadZone)
            hori = 0;
        else 
            hori = CrossPlatformInputManager.GetAxis("Horizontal") * currentJoystickSensitivity;        

        if (CrossPlatformInputManager.GetAxis("Vertical") <= joystickDeadZone && CrossPlatformInputManager.GetAxis("Vertical") >= -joystickDeadZone)
            verti = 0;
        else
            verti = CrossPlatformInputManager.GetAxis("Vertical") * currentJoystickSensitivity;
        
        playerCamera.transform.eulerAngles += new Vector3(-verti, hori, 0);
    }

    public void CalibrateYAngle()
    {
        calibrationYAngle = appliedGyroYAngle - initialYAngle; // Offsets the y angle in case it wasn't 0 at edit time.
    }

    void ApplyGyroRotation()
    {
        playerCamera.transform.rotation = Input.gyro.attitude;
        playerCamera.transform.Rotate(0f, 0f, 180f, Space.Self); // Swap "handedness" of quaternion from gyro.
        playerCamera.transform.Rotate(90f, 0f, 0f, Space.World); // Rotate to make sense as a camera pointing out the back of your device.
        appliedGyroYAngle = transform.eulerAngles.y; // Save the angle around y axis for use in calibration.
    }

    void ApplyCalibration()
    {
        playerCamera.transform.Rotate(0f, -calibrationYAngle, 0f, Space.World); // Rotates y angle back however much it deviated when calibrationYAngle was saved.
    }

}
