## Start plugin
### Description


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
