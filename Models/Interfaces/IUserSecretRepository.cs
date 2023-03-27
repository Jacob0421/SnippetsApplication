namespace SnippetsApplication.Models.Interfaces
{
    public interface IUserSecretRepository
    {
        IEnumerable<UserSecret> GetUserSecrets();
        UserSecret AddUserSecret(UserSecret inputSecret);
    }
}
