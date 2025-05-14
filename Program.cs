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

        