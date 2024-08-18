using System.Diagnostics;
using System.Speech.Recognition;
using System.Speech.Synthesis;

if (!OperatingSystem.IsWindows()) return;

SpeechRecognitionEngine recognizer = new();
SpeechSynthesizer synthesizer = new();

bool isListening = false;

Choices commands = new();
commands.Add("jarvis");
commands.Add("open powershell");
commands.Add("create");
commands.Add("open project");
commands.Add("stop listening");

GrammarBuilder grammarBuilder = new(commands);
Grammar grammar = new(grammarBuilder);
recognizer.LoadGrammar(grammar);

recognizer.SpeechRecognized += Recognizer_SpeechRecognized;
//recognizer.SpeechRecognitionRejected += Recognizer_SpeechRecognizedRejected;

recognizer.SetInputToDefaultAudioDevice();
recognizer.RecognizeAsync(RecognizeMode.Multiple);

Console.WriteLine("Waiting for the 'jarvis' command....");

Console.ReadLine();
void Recognizer_SpeechRecognized(object? sender, SpeechRecognizedEventArgs e)
{
    if (!OperatingSystem.IsWindows()) return;

    string text = e.Result.Text;

    if (!isListening && text != "jarvis") return;


    if (text == "jarvis")
    {
        isListening = true;
        Console.WriteLine("How can I help you sir!");
        synthesizer.Speak("How can I help you sir!");
    }
    else if (text == "open powershell")
    {
        Console.WriteLine("Opening powershell...");
        synthesizer.Speak("Opening powershell...");
        OpenPowerShell();
    }
    else if (text == "create")
    {
        Console.WriteLine("Creating a web application in your test folder...");
        synthesizer.Speak("Creating a web application in your test folder...");
        CreateAWebApplication();
    }
    else if (text == "open project")
    {
        Console.WriteLine("Opening new project with Visual studio...");
        synthesizer.Speak("Opening new project with Visual studio...");
        OpenProject();
    }
    else if (text == "stop listening")
    {
        Console.WriteLine("I will be around sir");
        synthesizer.Speak("I will be around sir");
        isListening = false;
    }
}

void OpenProject()
{
    var psi = new ProcessStartInfo()
    {
        FileName = "devenv.exe",
        Arguments = "c:/test/test2/test2.csproj",
        CreateNoWindow = true,
        UseShellExecute = true,
    };

    Process.Start(psi);
}

void Recognizer_SpeechRecognizedRejected(object? sender, SpeechRecognitionRejectedEventArgs e)
{
    Console.WriteLine("Command not recognized!");
}

void OpenPowerShell()
{
    var psi = new ProcessStartInfo
    {
        FileName = "powershell.exe",
        //Arguments = $"-NoExit -Command \"cd C:/eMuhasebe/eMuhasebeClient; ng serve\"",
        UseShellExecute = true,
        CreateNoWindow = false
    };

    Process.Start(psi);
}

void CreateAWebApplication()
{
    ProcessStartInfo psi = new ProcessStartInfo
    {
        FileName = "powershell.exe",
        Arguments = $"/c dotnet new web -o c:/test/test2 -n test2 -f net8.0",
        CreateNoWindow = true,
        UseShellExecute = false
    };

    Process.Start(psi);
}