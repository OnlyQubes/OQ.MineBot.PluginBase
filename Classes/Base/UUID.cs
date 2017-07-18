using System.Collections.Concurrent;
using System.Collections.Generic;
using OQ.MineBot.PluginBase.Utility;

namespace OQ.MineBot.PluginBase.Classes.Base
{
    public class UUID
    {
        public string Name;
        public string Uuid;

        //public string uuid {
        //    get {
        //        //If already resolved return the name.
        //        if (resolved)
        //            return _uuid;

        //        //Check if the name the user has given
        //        //is already the uuid.
        //        if (name.Length == 32 || name.Length == 36) {
        //            _uuid = name;
        //            resolved = true;
        //            return _uuid;
        //        }

        //        //Check if resolving.

        //        //Not uuid, attempt to resolve the name.
        //        resolving = true;
        //        var temp = NameHelper.NameToUUID(name);
        //        if (string.IsNullOrWhiteSpace(_uuid) && !string.IsNullOrWhiteSpace(temp))
        //            _uuid = temp;

        //        //Update states.
        //        resolving = false;
        //        resolved = true;

        //        return _uuid;
        //    }
        //}
        //private string _uuid;
        //public bool resolved;
        //public bool resolving;

        public UUID(string Uuid, string Name) {

            this.Name = Name;
            this.Uuid = Uuid;
        }
    }
}