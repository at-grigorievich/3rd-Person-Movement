using System;
using PlayerLogic.Interfaces;
using UnityEngine;

namespace PlayerLogic.Services
{
    public class PlayerInputService : MonoBehaviour, IInputable
    {
        [SerializeField] private Joystick _joystick;
        
        public event EventHandler<Vector2> OnStartInput;
        public event EventHandler<Vector2> OnContinueInput;
        public event EventHandler<Vector2> OnEndInput;
        public Vector2 JoystickValue => new Vector2(_joystick.Horizontal, _joystick.Vertical);

        private void Update()
        {
#if UNITY_EDITOR
            if(Input.GetMouseButton(0))
            {
                OnContinueInput?.Invoke(this,Input.mousePosition);
            }

            if (Input.GetMouseButtonDown(0))
            {
                OnStartInput?.Invoke(this,Input.mousePosition);
            }
            if (Input.GetMouseButtonUp(0))
            {
                OnEndInput?.Invoke(this,Input.mousePosition);
            }

            return;
#endif
            
            if (Input.touchCount > 0)
            {
                var touch = Input.GetTouch(0);
                var touchPhase = touch.phase;
                
                switch (touchPhase)
                {
                    case TouchPhase.Began:
                        OnStartInput?.Invoke(this,touch.position);
                        break;
                    
                    case TouchPhase.Moved:
                    case TouchPhase.Stationary:
                        OnContinueInput?.Invoke(this,touch.position);
                        break;
                    
                    case TouchPhase.Ended:
                        OnEndInput?.Invoke(this,touch.position);
                        break;
                }
            }
        }


        public void SetEnableInput(bool isEnable) =>
            _joystick.gameObject.SetActive(isEnable);
        
    }
}