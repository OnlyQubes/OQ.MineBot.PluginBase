using System.Collections.Generic;

namespace OQ.MineBot.PluginBase.Classes.Entity
{
    public interface IEffectContainer
    {
        /// <summary>
        /// List of all effects on the entity.
        ///
        /// Format: 
        /// byte - id
        /// IEffect - effect
        /// </summary>
        Dictionary<Effects, Effect> List { get; set; }

        /// <summary>
        /// Adds an effect to the entity.
        /// </summary>
        /// <param name="effect"></param>
        void Add(Effect effect);
        /// <summary>
        /// Removes an effect with the id.
        /// </summary>
        /// <param name="id"></param>
        void Remove(Effects id);

        /// <summary>
        /// Get an effect by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>NULL if not found.</returns>
        Effect Get(Effects id);

        /// <summary>
        /// Clears all the effects.
        /// </summary>
        void Clear();
    }

    public enum Effects
    {
        Speed = 1,
        Slowness = 2,
        Haste = 3,
        Mining_Fatigue = 4,
        Strength = 5,
        Instant_Health = 6,
        Instant_Damage = 7,
        Jump_Boost = 8,
        Nausea = 9,
        Regeneration = 10,
        Resistance = 11,
        Fire_Resistance = 12,
        Water_Breathing = 13,
        Invisibility = 14,
        Blindness = 15,
        Night_Vision = 16,
        Hunger = 17,
        Weakness = 18,
        Poison = 19,
        Wither = 20,
        Health_Boost = 21,
        Absorption = 22,
        Saturation = 23,
        Glowing = 24,
        Levitation = 25,
        Luck = 26,
        Bad_Luck = 27
    }
}