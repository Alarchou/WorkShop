using System;
using System.Collections;
using UnityEngine;

public  class Lerp 
{

    public static IEnumerator LerpPose(Transform transform, Pose start, Pose target, float duration)
    {
        float timeElapsed = 0f;
        while (timeElapsed < duration)
        {
            float t = timeElapsed / duration;
            transform.position = Vector3.Lerp(start.position, target.position, t);
            transform.rotation = Quaternion.Slerp(start.rotation, target.rotation, t);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = target.position;
        transform.rotation = target.rotation;
    }

    public static IEnumerator LerpPose(Transform transform, Pose start, Pose target, float duration, Action callback)
    {
        float timeElapsed = 0f;
        while (timeElapsed < duration)
        {
            float t = timeElapsed / duration;
            transform.position = Vector3.Lerp(start.position, target.position, t);
            transform.rotation = Quaternion.Slerp(start.rotation, target.rotation, t);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = target.position;
        transform.rotation = target.rotation;
        callback?.Invoke();
    }
}
