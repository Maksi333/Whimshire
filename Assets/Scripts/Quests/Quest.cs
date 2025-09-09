using UnityEngine;

public abstract class Quest
{
    public string QuestName { get; private set; }
    public string Description { get; private set; }
    public bool IsCompleted { get; private set; }
    protected Quest(string questName, string description)
    {
        QuestName = questName;
        Description = description;
        IsCompleted = false;
    }
    public abstract void StartQuest();
    public abstract void CompleteQuest();
    protected void MarkAsCompleted()
    {
        IsCompleted = true;
        Debug.Log($"{QuestName} has been completed!");
    }

}
