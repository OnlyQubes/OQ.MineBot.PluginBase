
<h2>Start plugin</h2>
<h3>Description</h3>
```
function test() {
  console.log("notice the blank line before this function?");
}
```
<h3>Code sample</h3>
`
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
`
