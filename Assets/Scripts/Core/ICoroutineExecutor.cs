using System.Collections;
using UnityEngine;

namespace PirateIsland.Core
{
    public interface ICoroutineExecutor
    {
        void BreakCoroutine(Coroutine coroutine);
        Coroutine ExecuteCoroutine(IEnumerator coroutine);
    }
}