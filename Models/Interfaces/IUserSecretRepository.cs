namespace SnippetsApplication.Models.Interfaces
{
    public interface IUserSecretRepository
    {
        UserSecret AddUserSecret(UserSecret inputSecret);
    }
}
