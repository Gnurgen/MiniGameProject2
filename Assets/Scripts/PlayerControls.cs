using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerControls : MonoBehaviour {


    public GameObject playerCamera;
    public GameObject joystick;
    private Rigidbody rgd;
    private string PAR_STAMINA;

    [Header("Player")]
    public float walkingSpeed = 150.0f;
    public float sprintSpeed = 300.00f;
    public float maxSprintTime = 10.0f;
    public float minSprintTime = 4.0f; 
    public float fullSprintRechargeTime = 20.0f; 
    public float frozenWalkingSpeed = 50.0f;
    public float frozenSprintSpeed = 100.0f;
    public float timeFrozen = 5.0f;

    [Header("Joystick")]
    public bool joystickEnable = false;
    public float joystickSensitivity = 1;
    public float joystickSensitivityIdle = 1;
    public float joystickDeadZone= 0.2f;

	public float idleFieldOfView;
	public float runFieldOfView;
	public float fieldOfViewTimer;

    public bool canSprint = false;

    private Camera camera;

    private float initialYAngle = 0f;
    private float appliedGyroYAngle = 0f;
    private float calibrationYAngle = 0f;

    enum PlayerState { Idle, Walk, Sprint };
    private PlayerState playerState = PlayerState.Idle;
    private PlayerState prevPlayerState;

    private bool exhausted = false, _isSprinting = false;
    private bool prevExhausted;
    [SerializeField]
    private float stamina, stamNormalization;
    private float hori;
    private float verti;
    private float currentJoystickSensitivity;
    private float currentWalkingSpeed;
    private float currentSprintSpeed;
    private float currentFreeze;
    private bool frozen = false;

    void Start()
    {
        if (!Application.isEditor)
            joystickEnable = GameManager.instance.debug.usingJoystick;
        rgd = GetComponent<Rigidbody>();
        Input.gyro.enabled = true;
        Application.targetFrameRate = 60;
        initialYAngle = transform.eulerAngles.y;
        stamina = 100;
        stamNormalization = 100.0f / maxSprintTime;
        currentWalkingSpeed = walkingSpeed;
        currentSprintSpeed = sprintSpeed;

		camera = transform.GetChild(0).GetComponent<Camera> ();
		camera.fieldOfView = idleFieldOfView;
 
        GameManager.instance.OnEnemyAttackHit += PlayerFrozen;

    }

    void Update()
    {
        //SET STAMINA EVERY FUCKING FRAME BRO!
        GameManager.instance.audioManager.StaminaChange(stamina);
        //controls
        if (!joystickEnable) {
            joystick.SetActive(false);
            applyGyroRotation();
            applyCalibration();
        }
        else
        {
            joystick.SetActive(true);
            useJoystick();
        }
        updatePlayerState();
        newStamina();
        
        //speed
        if (currentFreeze > 0) {
            updatePlayerSpeed();
            currentFreeze -= Time.deltaTime;
        }
        else
        {
            currentWalkingSpeed = walkingSpeed;
            currentSprintSpeed = sprintSpeed;
        }
       
    }

    void FixedUpdate()
    {
        switch (playerState)
        {
		case PlayerState.Walk:
				if (camera.fieldOfView > idleFieldOfView) {
					camera.fieldOfView -= (runFieldOfView - idleFieldOfView) * fieldOfViewTimer * Time.deltaTime;
				}
                rgd.velocity = playerCamera.transform.forward * currentWalkingSpeed * Time.deltaTime;
                break;
            case PlayerState.Sprint:
				if (camera.fieldOfView < runFieldOfView) {
					camera.fieldOfView += (runFieldOfView - idleFieldOfView) * fieldOfViewTimer * Time.deltaTime;
				}
                rgd.velocity = playerCamera.transform.forward * currentSprintSpeed * Time.deltaTime;
                break;
            default:
				if (camera.fieldOfView > idleFieldOfView) {
					camera.fieldOfView -= (runFieldOfView - idleFieldOfView) * fieldOfViewTimer * Time.deltaTime;
				}
                rgd.velocity = Vector3.zero;
                break;
        }
        if (joystickEnable)
        {
            rgd.velocity = playerCamera.transform.right * Input.GetAxis("Horizontal") * currentWalkingSpeed * Time.deltaTime;
            rgd.velocity = playerCamera.transform.forward * Input.GetAxis("Vertical") * currentWalkingSpeed * Time.deltaTime;
        }
    }

    private void updatePlayerState() {
        prevPlayerState = playerState;

        if (!joystickEnable)
        {
            if (Input.touchCount == 1 || Input.touchCount > 1 && exhausted)
                playerState = PlayerState.Walk;
            else if (Input.touchCount > 1 && canSprint)
                playerState = PlayerState.Sprint;
            else
                playerState = PlayerState.Idle;
        }
        else
        {
            if (Input.touchCount == 2 || Input.touchCount > 2 && exhausted)
                playerState = PlayerState.Walk;
            else if (Input.touchCount > 2 && canSprint)
                playerState = PlayerState.Sprint;
            else
                playerState = PlayerState.Idle;
        }

        if (prevPlayerState != playerState)
        {
            switch (playerState)
            { 
                case PlayerState.Idle:
                    GameManager.instance.PlayerIdle();
                    AkSoundEngine.PostEvent("Idle", GameManager.instance.player);
                    AkSoundEngine.RenderAudio();
                    break;
                case PlayerState.Walk:
                    GameManager.instance.PlayerWalk();
                    AkSoundEngine.PostEvent("Walk", GameManager.instance.player);
                    AkSoundEngine.RenderAudio();
                    break;
                case PlayerState.Sprint:
                    GameManager.instance.PlayerSprint();
                    AkSoundEngine.PostEvent("Run", GameManager.instance.player);
                    AkSoundEngine.RenderAudio();
                    break;
            }
        }
    }

    private void newStamina()
    {
        _isSprinting = (playerState == PlayerState.Sprint);
      
        if(!_isSprinting && stamina<=100.0f)
            stamina += Time.deltaTime * (100 / fullSprintRechargeTime);
        else
        {
            stamina -= Time.deltaTime*stamNormalization;
            if (stamina <= 0)
            {
                GameManager.instance.PlayerFatigue(); 
                exhausted = true;
                stamina = 0;
            }
        }
        if (stamina >= 100.0f)
            stamina = 100.0f;
        if (stamina >= 100 / minSprintTime)
            exhausted = false;
      
    }


    private void PlayerFrozen(int i){
        currentFreeze = timeFrozen;
      
    }
    private void updatePlayerSpeed() {
        currentWalkingSpeed = walkingSpeed - ((currentFreeze / timeFrozen) * (walkingSpeed - frozenWalkingSpeed));
        currentSprintSpeed = sprintSpeed - ((currentFreeze / timeFrozen) * (sprintSpeed - frozenSprintSpeed));
    }

    private void useJoystick() {
        currentJoystickSensitivity = playerState == PlayerState.Idle ? joystickSensitivityIdle : joystickSensitivity;
        hori = CrossPlatformInputManager.GetAxis("Horizontal") <= joystickDeadZone && CrossPlatformInputManager.GetAxis("Horizontal") >= -joystickDeadZone ? 0 : CrossPlatformInputManager.GetAxis("Horizontal") * currentJoystickSensitivity;
        verti = CrossPlatformInputManager.GetAxis("Vertical") <= joystickDeadZone && CrossPlatformInputManager.GetAxis("Vertical") >= -joystickDeadZone ? 0 : CrossPlatformInputManager.GetAxis("Vertical") * currentJoystickSensitivity;
        playerCamera.transform.eulerAngles += new Vector3(-verti, hori, 0);
    }

    private void calibrateYAngle()
    {
        calibrationYAngle = appliedGyroYAngle - initialYAngle; // Offsets the y angle in case it wasn't 0 at edit time.
    }

    private void applyGyroRotation()
    {
        playerCamera.transform.rotation = Input.gyro.attitude;
        playerCamera.transform.Rotate(0f, 0f, 180f, Space.Self);    // Swap "handedness" of quaternion from gyro.
        playerCamera.transform.Rotate(90f, 0f, 0f, Space.World);    // Rotate to make sense as a camera pointing out the back of your device.
        appliedGyroYAngle = transform.eulerAngles.y;                // Save the angle around y axis for use in calibration.
    }

    private void applyCalibration()
    {
        playerCamera.transform.Rotate(0f, -calibrationYAngle, 0f, Space.World); // Rotates y angle back however much it deviated when calibrationYAngle was saved.
    }
}
