namespace OQ.MineBot.PluginBase.Base
{
    /*
        To be loaded plugins have
        to inherite from: 
          - IRequestPlugin
          - IStartPlugin
    */
    public interface IPlugin
    {
        /// <summary>
        /// Name of the plugin.
        /// </summary>
        /// <returns></returns>
        string GetName();
        /// <summary>
        /// Description of what the plugin does.
        /// </summary>
        /// <returns></returns>
        string GetDescription();
        /// <summary>
        /// Author of the plugin.
        /// </summary>
        /// <returns></returns>
        PluginAuthor GetAuthor();
        /// <summary>
        /// Version of the plugin.
        /// </summary>
        /// <returns></returns>
        string GetVersion();

        /// <summary>
        /// All settings should be stored here.
        /// (NULL if there shouldn't be any settings)
        /// </summary>
        IPluginSetting[] Setting { get; set; }

        /// <summary>
        /// Called once the plugin is loaded.
        /// (Params are the version of the program)
        /// (This is not reliable as if "Load plugins" 
        /// isn't enabled this will not be called)
        /// </summary>
        /// <param name="version"></param>
        /// <param name="subversion"></param>
        /// <param name="buildversion"></param>
        void OnLoad(int version, int subversion, int buildversion);

        /// <summary>
        /// Called once the plugin is enabled.
        /// Meaning the start methods will be
        /// called when needed.
        /// </summary>
        void OnEnabled();
        /// <summary>
        /// Called once the plugin is disabled.
        /// Meaning the start methods will not be
        /// called.
        /// </summary>
        void OnDisabled();

        /// <summary>
        /// The plugin should be stopped.
        /// </summary>
        void Stop();

        /// <summary>
        /// Return an instance of this plugin.
        /// </summary>
        /// <returns></returns>
        IPlugin Copy();
    }
}