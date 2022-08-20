using System;
using UnityEngine;

namespace InputService
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