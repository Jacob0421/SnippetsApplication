using SnippetsApplication.Models.Interfaces;
using System.Diagnostics;

namespace SnippetsApplication.Models.Repositories
{
    public class UserSecretRepository : IUserSecretRepository
    {

        public UserSecretRepository()
        {

        }

        public UserSecret AddUserSecret(UserSecret inputSecret)
        {
            if(inputSecret == null)
            {
                throw new ArgumentNullException(nameof(inputSecret));
            }

            string cmd = "";

             if(String.IsNullOrEmpty(inputSecret.ProjectLocation))
             {
                inputSecret.ProjectLocation = Environment.CurrentDirectory;
             }


             cmd = String.Format("/C dotnet user-secrets set \"{0}\" \"{1}\" --project \"{2}\"",
                 inputSecret.SecretKey,
                 inputSecret.SecretValue,
                 inputSecret.ProjectLocation
                 );

            Debug.WriteLine(cmd);
            Process newCmdProcess = new Process();
            ProcessStartInfo cmdStartInfo = new ProcessStartInfo();
                cmdStartInfo.WindowStyle = ProcessWindowStyle.Normal;
                cmdStartInfo.FileName = "CMD.exe";
                cmdStartInfo.Arguments = cmd;

            newCmdProcess.StartInfo = cmdStartInfo;
            newCmdProcess.Start();

            return inputSecret;

        }

        public IEnumerable<UserSecret> GetUserSecrets()
        {
            string cmd;
            List<UserSecret> UserSecrets = new List<UserSecret>();

            cmd = "/C dotnet user-secrets list";

            Debug.WriteLine(cmd);
            Process newCmdProcess = new Process();
            ProcessStartInfo cmdStartInfo = new ProcessStartInfo();
                cmdStartInfo.WindowStyle = ProcessWindowStyle.Normal;
                cmdStartInfo.FileName = "CMD.exe";
                cmdStartInfo.Arguments = cmd;
                cmdStartInfo.RedirectStandardOutput = true;


            newCmdProcess.StartInfo = cmdStartInfo;
            newCmdProcess.Start();

            string output = newCmdProcess.StandardOutput.ReadToEnd();
            newCmdProcess.WaitForExit();

            string[] secrets = output.Trim().Split('\n');

            foreach(string secret in secrets)
            {
                UserSecret userSecret = new UserSecret();
                userSecret.UserSecretID = "4dd2d9d5-d5c3-4d88-b94b-6c8569072ea9";
                userSecret.SecretKey = secret.Split('=')[0];
                userSecret.SecretValue = secret.Split('=')[1];
                userSecret.ProjectLocation = Environment.CurrentDirectory;

                UserSecrets.Add(userSecret);
            }

            return UserSecrets.AsEnumerable();
        }
    }
}
