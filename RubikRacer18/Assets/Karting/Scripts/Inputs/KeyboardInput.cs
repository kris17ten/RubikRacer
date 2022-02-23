using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KartGame.KartSystems
{
    /// <summary>
    /// A basic keyboard implementation of the IInput interface for all the input information a kart needs.
    /// </summary>
    public class KeyboardInput : MonoBehaviour, IInput
    {
        [Tooltip("A reference to the particle system.")]
        public GameObject ps;

        public float Acceleration
        {
            get { return m_Acceleration; }
        }
        public float Steering
        {
            get { return m_Steering; }
        }
        public bool BoostPressed
        {
            get { return m_BoostPressed; }
        }
        public bool FirePressed
        {
            get { return m_FirePressed; }
        }
        public bool HopPressed
        {
            get { return m_HopPressed; }
        }
        public bool HopHeld
        {
            get { return m_HopHeld; }
        }

        float m_Acceleration;
        float m_Steering;
        bool m_HopPressed;
        bool m_HopHeld;
        bool m_BoostPressed;
        bool m_FirePressed;

        bool m_FixedUpdateHappened;

        void Update ()
        {
            if (Input.GetKey(KeyCode.UpArrow) || GameObject.Find("Accelerate").GetComponent<accelerate>().isFound)
            {
                m_Acceleration = 1f;
                ps.SetActive(true);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                m_Acceleration = -1f;
                ps.SetActive(false);
            }
            else
            {
                m_Acceleration = 0f;
                ps.SetActive(false);
            }

            if (Input.GetKey (KeyCode.LeftArrow) && !Input.GetKey (KeyCode.RightArrow) || (GameObject.Find("TurnLeft").GetComponent<turnLeft>().isFound && !GameObject.Find("TurnRight").GetComponent<turnRight>().isFound))
                m_Steering = -1f;
            else if (!Input.GetKey (KeyCode.LeftArrow) && Input.GetKey (KeyCode.RightArrow) || (!GameObject.Find("TurnLeft").GetComponent<turnLeft>().isFound && GameObject.Find("TurnRight").GetComponent<turnRight>().isFound))
                m_Steering = 1f;
            else
                m_Steering = 0f;

            m_HopHeld = Input.GetKey (KeyCode.Space);

            if (m_FixedUpdateHappened)
            {
                m_FixedUpdateHappened = false;

                m_HopPressed = false;
                m_BoostPressed = false;
                m_FirePressed = false;
            }

            m_HopPressed |= Input.GetKeyDown (KeyCode.Space);
            m_BoostPressed |= Input.GetKeyDown (KeyCode.RightShift);
            m_FirePressed |= Input.GetKeyDown (KeyCode.RightControl);
        }

        void FixedUpdate ()
        {
            m_FixedUpdateHappened = true;
        }
    }
}