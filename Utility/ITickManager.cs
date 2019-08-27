using System;
using System.Collections.Generic;
using OQ.MineBot.PluginBase.Classes;

namespace OQ.MineBot.PluginBase.Utility
{
    public interface ITickManager
    {
        /// <summary>
        /// Registers an action to the tick counter,
        /// which will execute the action once enough
        /// ticks are reached.
        /// (Runs on physics thread)
        /// </summary>
        /// <param name="count">How many ticks need to pass until the action will be executed.</param>
        /// <param name="action">Action that will be executed after the amount of ticks.</param>
        void Register(int count, Action action);
        /// <summary>
        /// Registers an action to the tick counter,
        /// which will execute the action once enough
        /// ticks are reached.
        /// (Runs on physics thread)
        /// </summary>
        /// <param name="count">How many ticks need to pass until the action will be executed.</param>
        /// <param name="action">Action that will be executed after the amount of ticks.</param>
        /// <param name="canTick">Called between a tick is added to the counter.</param>
        void Register(int count, Action action, Func<IBotContext, bool> canTick);

        /// <summary>
        /// Registers an action to the tick counter,
        /// which will execute the action once enough
        /// ticks are reached.
        /// * Will reoccur until IStopToken is set to `Stopped`.
        /// (Runs on physics thread)
        /// </summary>
        /// <param name="count">How many ticks need to pass until the action will be executed.</param>
        /// <param name="action">Action that will be executed after the amount of ticks is reached.</param>
        /// <returns>Token used to remove recurrence.</returns>
        IStopToken RegisterReocurring(int count, Action action);
        /// <summary>
        /// Registers an action to the tick counter,
        /// which will execute the action once enough
        /// ticks are reached.
        /// Ticks will only be added cumulatively only when canTick returns true. 
        /// * Will reoccur until IStopToken is set to `Stopped`.
        /// (Runs on physics thread)
        /// </summary>
        /// <param name="count">How many ticks need to pass until the action will be executed.</param>
        /// <param name="action">Action that will be executed after the amount of ticks.</param>
        /// <param name="canTick">Called between a tick is added to the counter.</param>
        /// <returns>Token used to remove recurrence.</returns>
        IStopToken RegisterReocurring(int count, Action action, Func<IBotContext, bool> canTick);

        /// <summary>
        /// Registers an action to the tick counter,
        /// which will execute the action once enough
        /// ticks are reached for 'times' times.
        /// * Will stop if IStopToken is set to `Stopped`.
        /// </summary>
        /// <param name="count">How many ticks do we wait until we call action.</param>
        /// <param name="times">How many times will action be called.</param>
        /// <param name="action">Action that will be executed after the amount of ticks is reached, this will contain the current time (starting from 0).</param>
        /// <param name="done">Instantly called after action has been executed 'times' times.</param>
        /// <returns>Token used to remove recurrence.</returns>
        IStopToken For(int count, int times, Action<int> action, Action done);

        /// <summary>
        /// Registers an action to the tick counter,
        /// which will execute the action once enough
        /// ticks are reached for each element in the array.
        /// * Will stop if IStopToken is set to `Stopped`.
        /// </summary>
        /// <param name="count">How many ticks do we wait until we call action.</param>
        /// <param name="array">The array that we will loop through.</param>
        /// <param name="action">Action that will be executed after the amount of ticks is reached, this will contain the current array element.</param>
        /// <param name="done">Instantly called after action has been executed 'times' times.</param>
        /// <returns>Token used to remove recurrence.</returns>
        IStopToken ForEach<T>(int count, IEnumerable<T> array, Action<T> action, Action done);
    }

    /// <summary>
    /// Example use of functions in this class:
    /// player.tickManager.Register(3, ()=>{/*callback*/}, TickManagerExtensionFunctions.NotEating);
    /// </summary>
    public static class TickManagerExtensionFunctions
    {
        public static bool NotEating(IBotContext context) { return !context.Status.eating; }
    }
}