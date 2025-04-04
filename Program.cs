using System;
using System.Windows.Media;
using System.Media.SoundPlayer;
using System.Threading;

class CyberSecurityChatbot
{
    static void Main() { PlayVoiceGreeting(); DisplayASCIIArt(); InteractWithUser(); }

    static void PlayVoiceGreeting()
    {
        try
        {
            // Ensure the "greeting.wav" file is placed in the same directory or update the path.
            using (SoundPlayer player = new SoundPlayer("johnny.wav"))
            {
                player.PlaySync();  // Play the sound synchronously
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
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        name = string.IsNullOrWhiteSpace(name) ? "User" : name;

        Console.WriteLine($"\nHello, {name}! Welcome to the Cybersecurity Awareness Bot.");
        Console.WriteLine("Ask me about password safety, phishing, or safe browsing.");

        while (true)
        {
            Console.Write("\nYou: ");
            string input = Console.ReadLine()?.Trim().ToLower();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Bot: Please enter a valid question.");
                continue;
            }
            else if (input.Contains("password"))
            {
                Console.WriteLine("Bot: Use strong passwords with a mix of letters, numbers, and symbols.");
            }
            else if (input.Contains("phishing"))
            {
                Console.WriteLine("Bot: Never click on suspicious links or provide personal information online.");
            }
            else if (input.Contains("browsing"))
            {
                Console.WriteLine("Bot: Always use HTTPS websites and keep your software updated.");
            }
            else if (input == "exit")
            {
                Console.WriteLine("Bot: Goodbye!");
                break;
            }
            else
            {
                Console.WriteLine("Bot: I didn't quite understand that. Could you rephrase?");
            }
        }
    }

}