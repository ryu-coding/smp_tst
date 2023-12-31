using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Lean.Touch
{
	// This script will hook into event LeanTouch event, and spam the console with the information
	public class LeanTouchEvents : MonoBehaviour
	{

        public Text mText;
        bool isActiveText;
        public GameObject obj;

        protected virtual void OnEnable()
		{
			// Hook into the events we need
			LeanTouch.OnFingerDown  += OnFingerDown;
			LeanTouch.OnFingerSet   += OnFingerSet;
			LeanTouch.OnFingerUp    += OnFingerUp;
			LeanTouch.OnFingerTap   += OnFingerTap;
			LeanTouch.OnFingerSwipe += OnFingerSwipe;
			LeanTouch.OnGesture     += OnGesture;
		}

		protected virtual void OnDisable()
		{
			// Unhook the events
			LeanTouch.OnFingerDown  -= OnFingerDown;
			LeanTouch.OnFingerSet   -= OnFingerSet;
			LeanTouch.OnFingerUp    -= OnFingerUp;
			LeanTouch.OnFingerTap   -= OnFingerTap;
			LeanTouch.OnFingerSwipe -= OnFingerSwipe;
			LeanTouch.OnGesture     -= OnGesture;
		}

		public void OnFingerDown(LeanFinger finger)
		{
			//Debug.Log("Finger " + finger.Index + " began touching the screen");
            isActiveText = !isActiveText;
            if (isActiveText)
            {
                obj.SetActive(true);
                mText.text = "내 이름은 파형동기야~.\n방패꾸미개로 사용되었지.\n나는 김해 대성동에서 출토되었어~.";
            }
        }
		public void OnFingerSet(LeanFinger finger)
		{
			Debug.Log("Finger " + finger.Index + " is still touching the screen");
		}

		public void OnFingerUp(LeanFinger finger)
		{
			Debug.Log("Finger " + finger.Index + " finished touching the screen");
		}

		public void OnFingerTap(LeanFinger finger)
		{
			Debug.Log("Finger " + finger.Index + " tapped the screen");
		}

		public void OnFingerSwipe(LeanFinger finger)
		{
			Debug.Log("Finger " + finger.Index + " swiped the screen");
		}

		public void OnGesture(List<LeanFinger> fingers)
		{
			Debug.Log("Gesture with " + fingers.Count + " finger(s)");
			Debug.Log("    pinch scale: " + LeanGesture.GetPinchScale(fingers));
			Debug.Log("    twist degrees: " + LeanGesture.GetTwistDegrees(fingers));
			Debug.Log("    twist radians: " + LeanGesture.GetTwistRadians(fingers));
			Debug.Log("    screen delta: " + LeanGesture.GetScreenDelta(fingers));
		}
	}
}