using UnityEngine;

public class PipeIncreaseScore : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ScoreScript.instance.UpdateScore();

            MLBirdAgent agent = collision.GetComponent<MLBirdAgent>();

            if (agent != null)
            {
                agent.PassedPipe();
            }
        }
    }
}
