using System.Diagnostics;
using System.IO;
using UnityEngine;

public class PythonIntegration : MonoBehaviour
{
    public void RunPythonScript(string participantId, string condition, float reactionTime, string accuracy, float errorDistance, string feedback)
    {
        string pythonScriptPath = Path.Combine(Application.dataPath, "Scripts", "Python", "experiment_data.py");
        string arguments = $"\"{pythonScriptPath}\" {participantId} {condition} {reactionTime} {accuracy} {errorDistance} {feedback}";

        UnityEngine.Debug.Log($"Python script path: {pythonScriptPath}");
        UnityEngine.Debug.Log($"Arguments: {arguments}");

        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = "python",
            Arguments = arguments,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        Process process = Process.Start(startInfo);
        string output = process.StandardOutput.ReadToEnd();
        string error = process.StandardError.ReadToEnd();
        process.WaitForExit();

        UnityEngine.Debug.Log($"Python Output: {output}");
        if (!string.IsNullOrEmpty(error))
        {
            UnityEngine.Debug.LogError($"Python Error: {error}");
        }
    }

    void Start()
    {
        RunPythonScript("1", "A", 2.5f, "Yes", 0.0f, "No noticeable delay");
    }
}
