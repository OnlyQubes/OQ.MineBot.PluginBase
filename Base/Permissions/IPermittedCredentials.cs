namespace OQ.MineBot.PluginBase.Base.Permissions
{
    public interface IPermittedCredentials
    {
        string Email { get; }
        string Username { get; }
        string Password { get; }
        string Token { get; set; }

        /// <summary>
        /// Could be used to change
        /// the account before it joins.
        /// </summary>
        /// <param name="token"></param>
        void SetToken(string token);
    }
}