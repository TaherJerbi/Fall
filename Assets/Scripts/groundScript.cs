using System.Collections;
using UnityEngine;

public class groundScript : MonoBehaviour {
    public float currCountdownValue;

    public IEnumerator StartCountdown(float countdownValue = 10)
    {
        currCountdownValue = countdownValue;
        while (currCountdownValue > 0)
        {
            currCountdownValue -= .01f;
            yield return new WaitForSeconds(.01f);
        }
        GetComponent<Rigidbody2D>().isKinematic = false;
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
}
