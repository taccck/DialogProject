using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest", order = 1)]
public class Quest : ScriptableObject
{
    /*[NonSerialized]*/ public bool Completed = false;
    /*[NonSerialized]*/ public bool Accepted = false;

    public int id;
    public string[] checkpoints;
    
    /*private*/ public int state;

    public void IncrementState()
    {
        if (!Accepted) return;
        
        state++;
        if (state > checkpoints.Length - 1)
        {
            Completed = true;
            state = checkpoints.Length - 1;
        }
    }

    public void ReduceState()
    {
        if (!Accepted) return;
        
        state--;
        if (state < 0)
            state = 0;
    }

    public string GetCheckpoint()
    {
        if (Completed) return "Completed: " + name;
        return checkpoints[state];
    }

    public int GetState()
    {
        return state;
    }

    public void Reset()
    {
        state = 0;
        Completed = false;
    }
}

