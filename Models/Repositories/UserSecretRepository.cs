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
    }
}
