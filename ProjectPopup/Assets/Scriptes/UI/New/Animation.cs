using System;
using UnityEngine;
using DG.Tweening;

namespace Scriptes.New
{
    public abstract class Animation : ScriptableObject
    {
        public abstract void PlayInward(GameObject gameObject , Action doneAction = null);
        public abstract void PlayBackwards(GameObject gameObject, Action doneAction = null);
        public abstract void KillAnimation();

    }
}