# SnippetsApplication
This is an application where the goal is to get more familiar with C#, .net core, Javascript, Ajax, and potentially more.

NOTE: Anything related to 'User Secrets' will only work while the project is on your local computer.
Below is the following functionality:

Add User Secrets ID to User Secrets (Automatic):
- This is currently set to run on project initialization. this will take your UserID from 'SnippetsApplication' and add it to UserSecrets where it will be referenced at soem points.

Add User Secrets (Manual):
- You can manually add a user secret as long as you know your User SecretID
NOTE: Chances are I will make the UserID section automatic.

List User Secrets:
- This grabs all User Secrets for the current context and lists them out in a table.

Get User Secret:
- Here you can type into the text box and if you type in a correct user secret key, it will show boxes containing the UserID, Key, and value for the input key.

Future  Plans:
- Create a way to crawl the current system and find other .sln files.
  - prompt the user if they would like to add these secrets to be shown in this application
    - if User Secrets ID is not found, prompt the user and ask if they would like to initialize User Secrets on that project.
