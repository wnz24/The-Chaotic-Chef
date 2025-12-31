using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    private Player player;
    private float footStepTimer;
    private float footStepTimerMax = 0.1f;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    void Update()
    {
        footStepTimer += Time.deltaTime;

        if (footStepTimer >= footStepTimerMax)
        {
            footStepTimer = 0f;

            if (player.IsWalking())
            {
                SoundManager.Instance.PlayFootStepSound(player.transform.position);
            }
        }
    }
}
