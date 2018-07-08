using System.Collections;
using UnityEngine;

public class groundScript : MonoBehaviour {
    public float currCountdownValue;

    public IEnumerator StartCountdown(float countdownValue = 10)
    {
        currCountdownValue = countdownValue;
        while (currCountdownValue > 0)
        {
            
            yield return new WaitForSeconds(.01f);
            currCountdownValue -= .01f;
        }
        Destroy(this.gameObject);
    }
}
