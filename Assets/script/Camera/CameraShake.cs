using System.Collections;
using UnityEngine;

//カメラを揺らすスクリプト

public class CameraShake : MonoBehaviour
{
    public void Shake(float dur, float mag)
    {
        StartCoroutine(DoShake(dur, mag));
    }

    private IEnumerator DoShake(float dur, float mag)
    {
        var pos = transform.localPosition;

        var elapsed = 0f;

        while (elapsed < dur)
        {
            var x = pos.x + Random.Range(-1.1f, 1.2f) * mag;
            var y = pos.y + Random.Range(-1.1f, 1.2f) * mag;

            transform.localPosition = new Vector3(x, y, pos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = pos;
    }
}