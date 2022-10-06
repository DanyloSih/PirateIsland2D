using System.Collections;
using UnityEngine;

namespace PirateIsland.Core
{
    public class CoroutineExecutor : MonoBehaviour, ICoroutineExecutor
    {
        public Coroutine ExecuteCoroutine(IEnumerator coroutine)
        {
            return StartCoroutine(coroutine);
        }

        public void BreakCoroutine(Coroutine coroutine)
        {
            StopCoroutine(coroutine);
        }
    }
}
