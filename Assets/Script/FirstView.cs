using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
using Random = UnityEngine.Random;

namespace UnityStandardAssets.Characters.FirstPerson
{
	[RequireComponent(typeof (CharacterController))]

	public class FirstView : MonoBehaviour
	{

		//For person
		[SerializeField] private bool m_IsWalking;
		[SerializeField] private float m_WalkSpeed;
		[SerializeField] private float m_RunSpeed;
		[SerializeField] [Range(0f, 1f)] private float m_RunstepLenghten;
		[SerializeField] private float m_JumpSpeed;
		[SerializeField] private float m_StickToGroundForce;
		[SerializeField] private float m_GravityMultiplier;
		[SerializeField] private MouseLook m_MouseLook;
		[SerializeField] private bool m_UseFovKick;
		[SerializeField] private FOVKick m_FovKick = new FOVKick();
		[SerializeField] private bool m_UseHeadBob;
		[SerializeField] private CurveControlledBob m_HeadBob = new CurveControlledBob();
		[SerializeField] private LerpControlledBob m_JumpBob = new LerpControlledBob();
		[SerializeField] private float m_StepInterval;


		//For camera and rotation
		private Camera m_Camera;
		private bool m_Jump;
		private float m_YRotation;
		private Vector2 m_Input;
		private Vector3 m_MoveDir = Vector3.zero;
		private CharacterController m_CharacterController;
		private CollisionFlags m_CollisionFlags;
		private bool m_PreviouslyGrounded;
		private Vector3 m_OriginalCameraPosition;
		private float m_StepCycle;
		private float m_NextStep;
		private bool m_Jumping;



		//To control fly mode
		private bool fly;
		private bool down;
		private bool freeMode;

		//To control person's position
		public GameObject gamePerson;
		
		// Use this for initialization
		private void Start()
		{
			m_CharacterController = GetComponent<CharacterController>();
			m_Camera = Camera.main;
			m_OriginalCameraPosition = m_Camera.transform.localPosition;
			m_FovKick.Setup(m_Camera);
			m_HeadBob.Setup(m_Camera, m_StepInterval);
			m_StepCycle = 0f;
			m_NextStep = m_StepCycle/2f;
			m_Jumping = false;

			m_MouseLook.Init(transform , m_Camera.transform);
			
			freeMode = false;
			fly = false;
			down = false;
		}
		
		
		// Update is called once per frame
		private void Update()
		{

			//To lock or release cursor
			if(Input.GetKeyDown(KeyCode.LeftAlt))
			{
				if(Cursor.lockState == CursorLockMode.Locked)
				{
					Cursor.lockState = CursorLockMode.None;
					Cursor.visible = true;
				}
				else if(Cursor.lockState == CursorLockMode.None)
				{
					Cursor.lockState = CursorLockMode.Locked;
					Cursor.visible = false;
				}
				
			}

			//Zoom out field
			if (Input.GetAxis ("Mouse ScrollWheel") < 0) {
				if(Camera.main.fieldOfView <= 70)
				{
					Camera.main.fieldOfView += 2;
				}
				if(Camera.main.orthographicSize <= 20)
				{
					Camera.main.orthographicSize += 0.5f;
				}
			}

			//Zoom in field
			if (Input.GetAxis ("Mouse ScrollWheel") > 0) {
				if(Camera.main.fieldOfView > 20)
				{
					Camera.main.fieldOfView -= 2;
				}
				if(Camera.main.orthographicSize >= 1 )
				{	
					Camera.main.orthographicSize -= 0.5f;
				}
			}

			//Lock the view when cursor unlocked
			if(Cursor.lockState == CursorLockMode.Locked)
			{
				RotateView();

			}
			
			// the jump state needs to read here to make sure it is not missed
			if (!m_Jump)
			{
				m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
			}
			
			if (!m_PreviouslyGrounded && m_CharacterController.isGrounded)
			{
				StartCoroutine(m_JumpBob.DoBobCycle());


				m_MoveDir.y = 0f;
				m_Jumping = false;
			}
			if (!m_CharacterController.isGrounded && !m_Jumping && m_PreviouslyGrounded)
			{
				m_MoveDir.y = 0f;
			}
			
			m_PreviouslyGrounded = m_CharacterController.isGrounded;
			

			//To fly or fall dowm
			if(Input.GetKeyDown(KeyCode.X))
			{
				if(fly == false)
				{
					fly = true;
					down = false;
				}
				else if(fly == true)
				{
					fly = false;
				}
				
			}
			if(Input.GetKeyDown(KeyCode.Z))
			{
				if(down == false)
				{
					down = true;
					fly = false;
				}
				else if(down == true)
				{
					down = false;
				}
			}

			//To enter free mode
			if(Input.GetKeyDown(KeyCode.LeftControl))
			{
				fly = false;
				down = false;
				if(freeMode == false)
				{
					freeMode = true;
				}
				else if( freeMode == true)
				{
					freeMode = false;
				}
			}

		}
		



		private void FixedUpdate()
		{
			float speed;
			GetInput(out speed);
			// always move along the camera forward as it is the direction that it being aimed at
			Vector3 desiredMove = transform.forward*m_Input.y + transform.right*m_Input.x;
			
			// get a normal for the surface that is being touched to move along it
			RaycastHit hitInfo;
			Physics.SphereCast(transform.position, m_CharacterController.radius, Vector3.down, out hitInfo,
			                   m_CharacterController.height/2f);
			desiredMove = Vector3.ProjectOnPlane(desiredMove, hitInfo.normal).normalized;
			
			m_MoveDir.x = desiredMove.x*speed;
			m_MoveDir.z = desiredMove.z*speed;
			
			//To check free mode or not
			if (freeMode == true) {
				if(fly == true)
				{
					m_MoveDir.y = m_JumpSpeed;
				}
				else if(down == true)
				{
					m_MoveDir.y = -m_JumpSpeed;
				}
				else
				{
					m_MoveDir.y = 0;
				}
			} else 
			{
				if (m_CharacterController.isGrounded)
				{
					m_MoveDir.y = -m_StickToGroundForce;
					
					if (m_Jump)
					{
						m_MoveDir.y = m_JumpSpeed;
						m_Jump = false;
						m_Jumping = true;
					}
				}
				else
				{
					m_MoveDir += Physics.gravity*m_GravityMultiplier*Time.fixedDeltaTime;
				}
			}
			if (gamePerson.transform.position.y > 180 && m_MoveDir.y> 0) {
				m_MoveDir.y = 0;
			}
			m_CollisionFlags = m_CharacterController.Move(m_MoveDir*Time.fixedDeltaTime);
		
			
			ProgressStepCycle(speed);
			
			UpdateCameraPosition(speed);

			//to control the person not to out of the scene
			if (gamePerson.transform.position.y < -10 ) {
			gamePerson.transform.position = new Vector3 (250, 10, 250);

			} 
			float xFrom = 0;
			float xTo = 0;
			float zFrom = 0;
			float zTo = 0;

			if (GetInfo.zone == 0) {
				xTo = 500;
				xFrom = 0;
				zTo = 500;
				zFrom = 0;
			} else if (GetInfo.zone == 1) {
				xTo = 0;
				xFrom = -500;
				zTo = 0;
				zFrom = -500;
			} else if (GetInfo.zone == 2) {
				xTo = 500;
				xFrom = 0;
				zTo = 0;
				zFrom = -500;
			} else if (GetInfo.zone == 3) {
				xTo = 0;
				xFrom = -500;
				zTo = 500;
				zFrom = 0;
			}

			//To control player not to go out of the zone
			if (gamePerson.transform.position.x <= xFrom) {
				gamePerson.transform.position = new Vector3 (xFrom, gamePerson.transform.position.y, gamePerson.transform.position.z);
			} else if (gameObject.transform.position.x >= xTo) {
				gamePerson.transform.position = new Vector3 (xTo, gamePerson.transform.position.y, gamePerson.transform.position.z);
			}
			if (gamePerson.transform.position.z <= zFrom) {
				gamePerson.transform.position = new Vector3 (gamePerson.transform.position.x, gamePerson.transform.position.y, zFrom);
			} else if (gamePerson.transform.position.z >= zTo) {
				gamePerson.transform.position = new Vector3 (gamePerson.transform.position.x, gamePerson.transform.position.y, zTo);
			}


				



			
			
			
		}
		
		



		private void ProgressStepCycle(float speed)
		{
			if (m_CharacterController.velocity.sqrMagnitude > 0 && (m_Input.x != 0 || m_Input.y != 0))
			{
				m_StepCycle += (m_CharacterController.velocity.magnitude + (speed*(m_IsWalking ? 1f : m_RunstepLenghten)))*
					Time.fixedDeltaTime;
			}
			
			if (!(m_StepCycle > m_NextStep))
			{
				return;
			}
			
			m_NextStep = m_StepCycle + m_StepInterval;



		}
		


		//To update camera's position
		private void UpdateCameraPosition(float speed)
		{
			Vector3 newCameraPosition;
			if (!m_UseHeadBob)
			{
				return;
			}
			if (m_CharacterController.velocity.magnitude > 0 && m_CharacterController.isGrounded)
			{
				m_Camera.transform.localPosition =
					m_HeadBob.DoHeadBob(m_CharacterController.velocity.magnitude +
					                    (speed*(m_IsWalking ? 1f : m_RunstepLenghten)));
				newCameraPosition = m_Camera.transform.localPosition;
				newCameraPosition.y = m_Camera.transform.localPosition.y - m_JumpBob.Offset();
			}
			else
			{
				newCameraPosition = m_Camera.transform.localPosition;
				newCameraPosition.y = m_OriginalCameraPosition.y - m_JumpBob.Offset();
			}
			m_Camera.transform.localPosition = newCameraPosition;
		}
		
		
		private void GetInput(out float speed)
		{
			// Read input
			float horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
			float vertical = CrossPlatformInputManager.GetAxis("Vertical");
			
			bool waswalking = m_IsWalking;
			
			#if !MOBILE_INPUT
			// On standalone builds, walk/run speed is modified by a key press.
			// keep track of whether or not the character is walking or running
			m_IsWalking = !Input.GetKey(KeyCode.LeftShift);
			#endif
			// set the desired speed to be walking or running
			speed = m_IsWalking ? m_WalkSpeed : m_RunSpeed;
			m_Input = new Vector2(horizontal, vertical);
			
			// normalize input if it exceeds 1 in combined length:
			if (m_Input.sqrMagnitude > 1)
			{
				m_Input.Normalize();
			}
			
			// handle speed change to give an fov kick
			// only if the player is going to a run, is running and the fovkick is to be used
			if (m_IsWalking != waswalking && m_UseFovKick && m_CharacterController.velocity.sqrMagnitude > 0)
			{
				StopAllCoroutines();
				StartCoroutine(!m_IsWalking ? m_FovKick.FOVKickUp() : m_FovKick.FOVKickDown());
			}
		}
		
		
		private void RotateView()
		{


			m_MouseLook.LookRotation (transform, m_Camera.transform);

		}
		
		
		private void OnControllerColliderHit(ControllerColliderHit hit)
		{
			Rigidbody body = hit.collider.attachedRigidbody;
			//dont move the rigidbody if the character is on top of it
			if (m_CollisionFlags == CollisionFlags.Below)
			{
				return;
			}
			
			if (body == null || body.isKinematic)
			{
				return;
			}
			body.AddForceAtPosition(m_CharacterController.velocity*0.1f, hit.point, ForceMode.Impulse);
		}
	}
}
