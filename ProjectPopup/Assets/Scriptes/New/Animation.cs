using System;
using UnityEngine;

namespace Scriptes.New
{
    public abstract class Animation : ScriptableObject
    {
        public abstract void PlayInward(GameObject gameObject);
        public abstract void PlayBackwards(GameObject gameObject, Action doneAction = null);
        // public abstract void Kill();
    }
}