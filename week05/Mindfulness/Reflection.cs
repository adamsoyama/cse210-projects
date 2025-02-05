using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectionActivity : Activity
{
    private List<string> usedPrompts = new List<string>();
    private List<string> usedQuestions = new List<string>();

    private static readonly List<string> prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

    private static readonly List<string> questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

    public ReflectionActivity() : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    public void StartReflection()
    {
        StartActivity();

        int duration = GetDuration();
        string prompt = GetRandomPrompt();
        Console.WriteLine(prompt);
        DisplayCountdown(5);

        int elapsedTime = 0;
        while (elapsedTime < duration)
        {
            string question = GetRandomQuestion();
            Console.WriteLine(question);
            DisplayCountdown(5);
            elapsedTime += 5;
        }

        EndActivity();
        Log.LogActivity("Reflection Activity", duration);
    }

    private string GetRandomPrompt()
    {
        if (usedPrompts.Count == prompts.Count)
        {
            usedPrompts.Clear();
        }

        Random random = new Random();
        string prompt;
        do
        {
            prompt = prompts[random.Next(prompts.Count)];
        } while (usedPrompts.Contains(prompt));

        usedPrompts.Add(prompt);
        return prompt;
    }

    private string GetRandomQuestion()
    {
        if (usedQuestions.Count == questions.Count)
        {
            usedQuestions.Clear();
        }

        Random random = new Random();
        string question;
        do
        {
            question = questions[random.Next(questions.Count)];
        } while (usedQuestions.Contains(question));

        usedQuestions.Add(question);
        return question;
    }
}