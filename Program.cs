using System;
using System.Collections.Generic;
using System.Media;

class CyberSecurityChatbot
{
    static void Main()
    {
        PlayVoiceGreeting();
        DisplayASCIIArt();
        InteractWithUser();
    }

    static void PlayVoiceGreeting()
    {
        try
        {
            using (SoundPlayer player = new SoundPlayer("johnny.wav"))
            {
                player.PlaySync();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("[Error] Unable to play voice greeting: " + ex.Message);
        }
    }

    static void DisplayASCIIArt()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("====================================");
        Console.WriteLine(" CYBERSECURITY AWARENESS BOT ");
        Console.WriteLine("====================================");
        Console.ResetColor();
    }

    static void InteractWithUser()
    {
        var userMemory = new Dictionary<string, string>();
        var phishingTips = new List<string>
        {
            "Be cautious of emails asking for personal information.",
            "Check the sender’s email address carefully before clicking links.",
            "Avoid clicking on suspicious links or downloading unexpected attachments.",
            "Phishing emails often create a sense of urgency – stay calm and verify first."
        };
        Random random = new Random();

        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        name = string.IsNullOrWhiteSpace(name) ? "User" : name;
        userMemory["name"] = name;

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"\nBot: Hello, {name}! Welcome to the Cybersecurity Awareness Bot.");
        Console.WriteLine("Bot: Ask me about password safety, phishing, or safe browsing. Type 'exit' to leave.");
        Console.ResetColor();

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"\n{name}: ");
            Console.ResetColor();
            string input = Console.ReadLine()?.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Bot: Please enter a valid question.");
                Console.ResetColor();
                continue;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;

            if (input == "exit" || input == "quit")
            {
                Console.WriteLine("Bot: Goodbye! Stay safe online.");
                Console.ResetColor();
                break;
            }
            else if (input.Contains("password"))
            {
                Console.WriteLine("Bot: Use strong passwords with a mix of letters, numbers, and symbols.");
            }
            else if (input.Contains("phishing"))
            {
                string tip = phishingTips[random.Next(phishingTips.Count)];
                Console.WriteLine($"Bot: {tip}");
            }
            else if (input.Contains("browsing"))
            {
                Console.WriteLine("Bot: Always use HTTPS websites and keep your software updated.");
            }
            else if (input.StartsWith("my name is "))
            {
                string newName = input.Substring(11).Trim();
                userMemory["name"] = newName;
                Console.WriteLine($"Bot: Nice to meet you, {newName}!");
                name = newName;
            }
            else if (input.Contains("interested in"))
            {
                int index = input.IndexOf("interested in") + 13;
                string topic = input.Substring(index).Trim();
                userMemory["interest"] = topic;
                Console.WriteLine($"Bot: Great! I'll remember that you're interested in {topic}.");
            }
            else if (input.Contains("what did i say"))
            {
                if (userMemory.ContainsKey("interest"))
                {
                    Console.WriteLine($"Bot: You mentioned that you're interested in {userMemory["interest"]}.");
                }
                else
                {
                    Console.WriteLine("Bot: I don't remember you mentioning an interest yet.");
                }
            }
            else if (input.Contains("worried") || input.Contains("scared") || input.Contains("nervous"))
            {
                Console.WriteLine("Bot: It's completely understandable to feel that way. Let's walk through some tips together.");
            }
            else if (input.Contains("frustrated") || input.Contains("angry"))
            {
                Console.WriteLine("Bot: I hear your frustration. Cybersecurity can be tough, but you're not alone.");
            }
            else if (input.Contains("curious") || input.Contains("interested"))
            {
                Console.WriteLine("Bot: Curiosity is great! Let me know what you'd like to learn about.");
            }
            else if (input.Contains("scam") || input.Contains("scams"))
            {
                Console.WriteLine("Bot: Scammers may pose as legitimate companies. Always verify before acting.");
            }
            else if (input.Contains("privacy"))
            {
                Console.WriteLine("Bot: Review your privacy settings regularly and limit personal info shared online.");
            }
            else if (input.Contains("help"))
            {
                Console.WriteLine("Bot: I can assist with topics like password safety, scams, phishing, and privacy. Try asking me!");
            }
            else
            {
                Console.WriteLine("Bot: I didn't quite understand that. Could you rephrase or ask about a cybersecurity topic?");
            }

            Console.ResetColor();
        }
    }
}
