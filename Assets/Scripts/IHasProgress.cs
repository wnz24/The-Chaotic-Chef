using System;
using UnityEngine;

public interface IHasProgress
{

    public event EventHandler<OnProgressChangedEventArgs> OnProgressChanged;

    public class OnProgressChangedEventArgs : EventArgs
    {
        // Progress value normalized between 0 and 1
        public float progressNormalized;
    }

}
