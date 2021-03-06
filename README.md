## Check out https://docs.minecraftbot.com for documentation!
## Check out https://docs.minecraftbot.com for documentation!
## Check out https://docs.minecraftbot.com for documentation!
#### The documentation below is outdated and should no longer be used as reference. Please go to https://docs.minecraftbot.com for the up to date documentation.

##
## 
## 

# Plugin attribute
### Description
The plugin attribute is used to define the name, description and current version of the plugin. The version is also used for plugin update notifications, thus increasing the version by 1 every update is a good idea. The following code snippet shows the snippet of the plugin attribute:
`[Plugin(<version>, <name>, <description>, <[optional] showcase url>)]`

### Example
```c#
  [Plugin(1, "Plugin Name", "Plugin Description", "https://youtube.com/.. (optional)")]
  public class Core {
    ...
  }
```
###### *[see examples in official plugins](https://github.com/OnlyQubes/OQ.MineBot.Plugins)*

# Request plugin
### Description
When creating a request plugin the main class should implement the [IRequestPlugin interface](https://github.com/OnlyQubes/OQ.MineBot.PluginBase/blob/master/Base/Plugin/IRequestPlugin.cs). This class should also have the Plugin attribute (explained above) and there should only one class of this type per plugin. This type of plugins are enabled through right clicking bots in the accounts tab (see gif below) and don't have a checkbox in the plugins tab, where as the *IStartPlugin* is enabled through the plugin tab.
When right clicking an account a single plugin can have more than one functions [(see picture)](https://i.imgur.com/wYvFZIM.png).

The functions have to implement [IRequestFunction](https://github.com/OnlyQubes/OQ.MineBot.PluginBase/blob/master/Base/Plugin/IRequestPlugin.cs). This gives the plugin access to the bots player entity.

### Inherited method
* `IRequestFunction[] GetFunctions()` (IRequestPlugin): should return all the functions that will be displayed in the right click menu.
* `PluginResponse OnRequest(IPlayer player)`(IRequestFunction): called once a single account is right click in the accounts tab and this plugins function gets selected. This should execute a specific function on the player.
* `PluginResponse OnRequest(IPlayer player)`(IRequestFunction): called once more than one accounts are selected and this plugins function gets selected.

### Code example
```c#
  [Plugin(1, "Example plugin", "This is a description for this plugin.")]
  public class ExamplePlugin : IRequestPlugin {
  
    // Must be overriden, should be used to define settings if there are any.
    public override void OnLoad(int version, int subversion, int buildversion) {}
  
    // Must return all requestable functions.
    // (all functions that will be displayed once an account is right clicked)
    public override IRequestFunction[] GetFunctions() {
      return new IRequestFunction[] {
        new EnableFunction(), 
      };
    }
    
    public class EnableFunction : IRequestFunction
    {
      public string GetName() {
        return "Enable";
      }
      
      // Called once a single account is selected.
      public PluginResponse OnRequest(IPlayer player) {
        Console.WriteLine("Action requested for " + player.status.username);
        return new PluginResponse(true);
      }
      
      // Calle if more than one account is selected.
      public PluginResponse OnRequest(IPlayer[] players) {
        Console.WriteLine("Action requested for " + players.Length + " bots");
        return new PluginResponse(true);
      }
    }
  }
```

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
    
    // Must be overriden by every plugin.
    public override void OnLoad(int version, int subversion, int buildversion) {
      // Should be used to define all the settings.
      this.Settings.Add(new StringSetting("Message", "explanation", "default message"));
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
      RegisterTask(new DeathMessage(Setting.At(0).Get<string>()));
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


# Plugin settings
### Description
Plugins can have settings that the plugin users are able to edit, the plugin setting menu can be opened by double clicking the plugin in the bot. If a plugin doesn't have any settings double clicking a plugin won't do anything.

### Types
* `BlockCollectionSetting` - returns `BlockIdCollection` which is a list of block ids and metadatas. [Preview](https://i.imgur.com/4rr8IPG.png)
* `BoolSetting` - returns a boolean value.
* `ComboSetting` - returns index of selected item.
* `LinkSetting` - displays a hyperlink that when clicked will open the browser and redirect to specified url.
* `LocationSetting` - returns an ILocation.
* `NumberSetting` - returns a number.
* `PathSetting` - allows the user to select a path to a file on his computer (E.g.: C:\hello.txt).
* `StringListSetting` - returns a string value which should be split by SPACE (control has ',.' blacklisted, so the user is forced to use a space).
* `StringSetting` - returns a string value.

### Code example
```c#
  // Adding a plugin setting:
  ...
    public override void OnLoad(int version, int subversion, int buildversion) {
      // Should be used to define all the settings.
      this.Settings.Add(new StringSetting("Message", "explanation", "default message"));
    }
  ...
  
  // Reading plugin setting:
    public override void OnStart() {
      RegisterTask(new DeathMessage(Setting.At(0).Get<string>()));  // '0' is index number of the settings 'Message'.
    }
  ...
```

```c#
  // Settings can be grouped:
  ...
    public override void OnLoad(int version, int subversion, int buildversion) {
      // Should be used to define all the settings.
      var group = new GroupSetting("My group", "Group description");
      group.Add(new StringSetting("Message", "explanation", "default message"));
      group.Add(new StringSetting("Message 2", "explanation", "default message"));
      this.Settings.Add(group);
    }
  ...
  
    // Reading group plugin setting:
    public override void OnStart() {
    
      var group = Setting.Get("My group") as IParentSetting; // Get group.
      RegisterTask(new DeathMessage(blocks.GetValue<string>("Message"))); 
    }
  ...
```
```c#
  // Settings can be shown depending on other setting values:
  // This only works with 'BoolSetting' and 'ComboSetting'!
  ...
    public override void OnLoad(int version, int subversion, int buildversion) {
      // Should be used to define all the settings.
      var mySetting = new BoolSetting("Show?", "Should the plugin setting 'Message' be shown?", "show");
      group.Add(new StringSetting("Message", "explanation", "default message"), mysetting, true); // Shown when mySetting is true.
      group.Add(new StringSetting("Message", "explanation", "default message"), mysetting, false); // Shown when mySetting is false.
      this.Settings.Add(group);
    }
  ...
  
    // Reading group plugin setting:
    public override void OnStart() {
    
      var group = Setting.Get("My group") as IParentSetting; // Get group.
      RegisterTask(new DeathMessage(blocks.GetValue<string>("Message"))); 
    }
  ...
```



# Tasks
### Description
Plugin tasks should be seperated in different classes, e.g.: Sugarcane farmer: Farm task, Store items task. All plugin tasks should be registered by *IStartPlugin OnStart()* method. When registering tasks the plugin should pass all the settings as to the constructor (see official plugins). Tasks should implement different listeners, instead of registering events manually (add events only if a pre-made listener isn't available). ITask classes have to override `bool Exec()`, which will determined if the listener events get triggered. If `Exec()` returns false then no listener events will be called until true is returned.
### Listeners
* ITickListener: `OnTick()`
  * The method 'OnTick' will be called each tick (~50ms) until the bot gets disconnected or the plugin is stopped.
* IDeathListener: `OnDeath()`
  * The method 'OnDeath()' will be called once the bots health is equal or below 0.
* IHealthListener: `OnHealthChanged(int health)`
  * The method 'OnHealthChanged' will be called once the bots health is changed.
* IHungerListener: `OnHungerChanged(int hunger)`
  * The method 'OnHungerChanged' will be called once the bots health is changed.
* IInventoryListener: `OnInventoryChanged()`, `OnSlotChanged(ISlot slot)`, `OnItemAdded(ISlot slot)`, `OnItemRemoved(ISlot slot)`
  * 'OnInventoryChanged' - called everytime the players inventory changes.
  * 'OnItemChanged' - called every time a slot changes (e.g.: item picked up, item removed, item count incremented)
  * 'OnItemAdded' - called once an item gets added to the inventory. (has to be a new item, does not get called if item is put into an existing stack)
  * 'OnItemRemoved' - called once an item gets removed from the inventory.
### Code example
```c#
  public class Eat : ITask, IHungerListener {
    private readonly int minFood;
    public Eat(int minFood) {
      this.mindFood = minFood;
    }
    
    // Exec only if not dead and not eating.
    public override bool Exec() {
      return !status.entity.isDead && !status.eating;
    }
    
    public void OnHungerChanged(int hunger) {
      if (hunger > m_minFood) return;
      EatFood();
    }
    
    private void EatFood() {
      ...
    }
  }
```

### Examples
* [Sugarcane farmer - Farm task](https://github.com/OnlyQubes/OQ.MineBot.Plugins/blob/master/SugarcaneFarmerPlugin/Tasks/Farm.cs)
* [Sugarcane farmer - Store task](https://github.com/OnlyQubes/OQ.MineBot.Plugins/blob/master/SugarcaneFarmerPlugin/Tasks/Store.cs)
###### *[all official plugins](https://github.com/OnlyQubes/OQ.MineBot.Plugins)*
