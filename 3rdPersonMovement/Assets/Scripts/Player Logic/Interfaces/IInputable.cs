using System;
using UnityEngine;

namespace PlayerLogic.Interfaces
{
    public interface IInputable
    {
        event EventHandler<Vector2> OnStartInput;
        event EventHandler<Vector2> OnContinueInput;
        event EventHandler<Vector2> OnEndInput;
        
        Vector2 JoystickValue { get; }

        void SetEnableInput(bool isEnable);
    }
}