# Plugin attribute
### Description
The plugin attribute is used to define the name, description and current version of the plugin. The version is also used for plugin update notifications, thus increasing the version by 1 every update is a good idea. The following code snippet shows the snippet of the plugin attribute:
`[Plugin(<version>, <name>, <description>)]`

### Example
```c#
  [Plugin(1, "Plugin Name", "Plugin Description")]
  public class Core {
    ...
  }
```
###### *[see examples in official plugins](https://github.com/OnlyQubes/OQ.MineBot.Plugins)*

# Request plugin
### Description
### Code example
### Examples
* [Chat spy](https://github.com/OnlyQubes/OQ.MineBot.Plugins/tree/master/ChatSpyPlugin)
  * [Chat spy main class](https://github.com/OnlyQubes/OQ.MineBot.Plugins/blob/master/ChatSpyPlugin/PluginCore.cs)
###### *[all official plugins](https://github.com/OnlyQubes/OQ.MineBot.Plugins)*

# Start plugin
### Description
A Start plugin class is the one that implement [IStartPlugin](https://github.com/OnlyQubes/OQ.MineBot.PluginBase/blob/master/Base/Plugin/IStartPlugin.cs), this is the main class of the plugin, meaning it should be marked with the attribute *\[Plugin\]* (explained above), and there should be only one of these per plugin. Plugins of this type use the [ITask interface](https://github.com/OnlyQubes/OQ.MineBot.PluginBase/blob/master/Base/Plugin/Tasks/ITask.cs) to control each bot once it logs in to the server. The class that implements *IStartPlugin* it self does not have any reference or control over the bot, thus *ITask* classes are necessary and should be registered in 'OnStart()' with the method 'RegisterTask()' (see example below).

Start plugins have checkmarks in the plugins tab. Once the checkmark is ticket 'OnEnable()' gets called, an instance copy of this plugin is created for each currently connected bot (and later for the bots that connected) and lastly 'OnStart()' gets called, which should register all its Tasks. The checkmark can be unticked, which in turn will call 'OnDisable()' on the main instance of the plugin and will call 'OnStop' on each instance copy and 'Stop' on each registered task.
### Inherited methods
* `PluginResponse OnEnable (IBotSettings botSettings)`: called only when the checkbox in the plugins tab is ticked. By overriding this method you can cancel the enablance of this plugin by returning the following piece of code `new PluginResponse(false, "error message")`, this would display an error message to the user and would untick the checkbox. However if you want the plugin to continue its normal flow then `new PluginResponse(true)` should be returned.
(In official plugins this is used to check if all the required settings are enabled)
* `void OnDisable()`: called only when the plugin is disabled through the plugins tab. This will not get called if the plugin is disabled through macros or any other source.
* `void OnStart()`: called when the plugin is started. This gets called after 'OnEnable', once per connected bot (whereas 'OnEnable' gets called only once). This should register all the tasks that will control the bot, as this class has no access to the bot entity it self. (for examples see official plugins)
* `void OnStop()`: called when the plugin is stopped. This gets called after 'OnStop', once per connected bot (whereas 'OnDisable' gets called only once).
### Code example
```c#
  [Plugin(1, "Example plugin", "This is a description for this plugin.")]
  public class ExamplePlugin : IStartPlugin {
    
    public override void OnLoad(int version, int subversion, int buildversion) {
      this.Setting = new IPluginSetting[1];
      Setting[0] = new StringSetting("Message", "explanation", "default message");
    }
    
    public override PluginResponse OnEnable(IBotSettings botSettings) {
      // Called once the plugin is ticked in the plugin tab.
      return new PluginResponse(false, "Error has occured");
    }
    
    public override void OnDisable() {
      // Called once the plugin is unticked.
      // (Note: does not get called if the plugin is stopped from different sources, such as macros)
      Console.WriteLine("Plugin disabled");
    }
    
    public override void OnStart() {
      // This should be used to register the tasks for the bot, see below.
      // (Note: called after 'OnEnable')
      RegisterTask(new DeathMessage(Setting[0].Get<string>()));
    }
    
    public override void OnStop() {
      // Called once the plugin is stopped.
      // (Note: unlike 'OnDisabled' this gets triggered from other sources, not only plugins tab)
    }
  }
  
  public class DeathMessage : ITask, IDeathListener {
    
    private readonly string message;
    
    public SayHello(string message) {
      this.message = message;
    }
    
    public override bool Exec() {
      // Determines if the listener events get called.
      // (e.g.: if Exec returns false then 'OnDeath' would not be called when the bot dies)
      return true;
    }
    
    public void OnDeath() {
      actions.Chat(message);
    }
  }
```
### Examples
* [Area miner](https://github.com/OnlyQubes/OQ.MineBot.Plugins/blob/master/AreaMiner)
  * [Area miner main class](https://github.com/OnlyQubes/OQ.MineBot.Plugins/blob/master/AreaMiner/PluginCore.cs)
  * [Area miner tasks](https://github.com/OnlyQubes/OQ.MineBot.Plugins/tree/master/AreaMiner/Tasks)
* [Sugarcane farmer](https://github.com/OnlyQubes/OQ.MineBot.Plugins/tree/master/SugarcaneFarmerPlugin)
  * [Sugarcane farmer main class](https://github.com/OnlyQubes/OQ.MineBot.Plugins/blob/master/SugarcaneFarmerPlugin/PluginCore.cs)
  * [Sugarcane farmer tasks](https://github.com/OnlyQubes/OQ.MineBot.Plugins/tree/master/SugarcaneFarmerPlugin/Tasks)
* [Auto eat](https://github.com/OnlyQubes/OQ.MineBot.Plugins/blob/master/AutoEatPlugin/)
  * [Auto eat main class](https://github.com/OnlyQubes/OQ.MineBot.Plugins/blob/master/AutoEatPlugin/PluginCore.cs)
  * [Auto eat tasks](https://github.com/OnlyQubes/OQ.MineBot.Plugins/tree/master/AutoEatPlugin/Tasks)
* [Shield aura](https://github.com/OnlyQubes/OQ.MineBot.Plugins/tree/master/ShieldPlugin)
  * [Shield aura main class](https://github.com/OnlyQubes/OQ.MineBot.Plugins/blob/master/ShieldPlugin/PluginCore.cs)
  * [Shield aura tasks](https://github.com/OnlyQubes/OQ.MineBot.Plugins/tree/master/ShieldPlugin/Tasks)
###### *[all official plugins](https://github.com/OnlyQubes/OQ.MineBot.Plugins)*



# Tasks
### Description
### Listeners
### Code example
### Examples
