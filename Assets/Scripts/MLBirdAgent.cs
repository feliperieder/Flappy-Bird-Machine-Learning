using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;


[RequireComponent(typeof(Rigidbody2D))]
public class MLBirdAgent : Agent
{
    [SerializeField] private PipeSpawner pipeSpawner;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public override void OnEpisodeBegin()
    {
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;

        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
        pipeSpawner.ResetPipes();
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position.y);

        sensor.AddObservation(rb.linearVelocity.y);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        int action = actions.DiscreteActions[0];

        if (action == 1)
        {
            rb.GetComponent<FlyBehaviour>().FlyUp();
            AddReward(0.01f);
        }
        Debug.Log($"Action: {action}");

    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        actionsOut.DiscreteActions.Array[0] =
            Input.GetMouseButton(0) ? 1 : 0;
    }

    public void Die()
    {
        AddReward(-10f);
        ScoreScript.instance.ResetScore();
        EndEpisode();
    }

    public void PassedPipe()
    {
        AddReward(1f);
    }

}
