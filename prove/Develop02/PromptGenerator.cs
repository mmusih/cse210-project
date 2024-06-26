public class PromptGenerator
{
    public List<string> _prompts = new List<string>
    {
        "What was the best thing that happened to you today?",
      "What steps did you take today towards a goal you're working on?",
      "What are three things you're grateful for today?",
      "What country would you like to visit for the first time?",
      "What magic power would you like to have?",
      "What do you feel is your purpose in life, and has that answer changed in the last five years?",
      "What is your happy place? Describe it in detail",
      "Where do you see yourself in 5 years?",
      "What negative emotions am I holding onto? How can I let them go?",
      "What goals have you lost sight of? Are you interested in picking them up again?",
      "What do you want to be remembered for?"
    };

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}